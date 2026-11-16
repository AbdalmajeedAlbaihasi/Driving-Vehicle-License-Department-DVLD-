using DVLD_Desktop_Net8.Application.Services;
using DVLD_Desktop_Net8.Test.Controls;
using DVLD_Desktop_Net8.Test.Service;
using DVLD_Desktop_Net8.Test.Services;
using DVLDShared.DTOs.TestAppointment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_Desktop_Net8.Test
{
    public partial class fmListTestAppointments : Form
    {
        //members
        private int LocalDrivingID;
        private readonly TestAppointmentService _testAppointmentService = new TestAppointmentService();
        private readonly TestService _testService = new TestService();
        private List<TestAppointmentDTO>? _testAppointments;
        private int _TestType = 1; // 1: Vision, 2: Written, 3: Street



        // constructur
        public fmListTestAppointments()
        {
            InitializeComponent();
        }

        public fmListTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            LocalDrivingID = LocalDrivingLicenseApplicationID;
        }

        public fmListTestAppointments(int LocalDrivingLicenseApplicationID, int TestType)
        {
            InitializeComponent();
            LocalDrivingID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }





        private void _FillRecordsCount()
        {
            labRecordsCount.Text = $"Total Records: {dgvLicenseTestAppointments.Rows.Count.ToString()}";
        }


        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {
                case 1:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = System.Drawing.Image.FromFile(@"\Users\2tita\Desktop\My_Projects\Abalmajeed_DVLD\DVLD_Desktop\DVLD_Desktop\Resources\Vision 512.png");
                        break;
                    }
                case 2:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = System.Drawing.Image.FromFile(@"\Users\2tita\Desktop\My_Projects\Abalmajeed_DVLD\DVLD_Desktop\DVLD_Desktop\Resources\Written Test 512.png");
                        break;
                    }
                case 3:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = System.Drawing.Image.FromFile(@"\Users\2tita\Desktop\My_Projects\Abalmajeed_DVLD\DVLD_Desktop\DVLD_Desktop\Resources\driving-test 512.png");
                        break;
                    }

                    _FillRecordsCount();
            }
        }


        private async void fmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            await ctrlDrivingLicenseApplicationInfo2.LoadData(LocalDrivingID);
            await LoadDataOfAppointments();

        }


        private bool? _GetSelectedIsActive()
        {
            // 1. التأكد من تحديد سطر حالي في الـ DataGridView
            if (dgvLicenseTestAppointments.CurrentRow == null || dgvLicenseTestAppointments.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a row first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // 2. قراءة القيمة من أول عمود (Cells[0]) أو بالاسم
            var cellValue = dgvLicenseTestAppointments.CurrentRow.Cells[3].Value;

            if (cellValue != null && bool.TryParse(cellValue.ToString(), out bool IsActive))
            {
                return IsActive;
            }

            MessageBox.Show("Could not read ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        //private async void frmListTestAppointments_Load(object sender, EventArgs e)
        //{

        //    await LoadDataOfAppointments();
        //}
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task LoadDataOfAppointments()
        {
            _testAppointments = await _testAppointmentService.GetAllTestAppointmentsForPersonAsync(LocalDrivingID, _TestType);
            dgvLicenseTestAppointments.DataSource = _testAppointments;

            _FillRecordsCount();

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 150;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 150;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 100;
            }
        }














        private  void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            bool isHasAppointment = dgvLicenseTestAppointments.ColumnCount > 0;

            bool? hasActive =  _GetSelectedIsActive();
            if(hasActive.Value) 
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fmScheduleTest fm1 = new fmScheduleTest(LocalDrivingID, _TestType);
            fm1.ShowDialog();
            LoadDataOfAppointments();


            var lastTest =  _testAppointmentService.GetLastTestPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            if (lastTest == null)
            {
                fmScheduleTest fm1 = new fmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                fm1.ShowDialog();
                LoadDataOfAppointments();
                return;
            }

            if (lastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake failed test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fmScheduleTest fm2 = new fmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
            fm2.ShowDialog();
            LoadDataOfAppointments();
        }














        //private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (dgvLicenseTestAppointments.CurrentRow == null) return;
        //    int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

        //    frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
        //    frm.ShowDialog();
        //    await LoadDataOfAppointments();
        //}

        //private async void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (dgvLicenseTestAppointments.CurrentRow == null) return;
        //    int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

        //    frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
        //    frm.ShowDialog();
        //    await LoadDataOfAppointments();
        //}


    }
}

