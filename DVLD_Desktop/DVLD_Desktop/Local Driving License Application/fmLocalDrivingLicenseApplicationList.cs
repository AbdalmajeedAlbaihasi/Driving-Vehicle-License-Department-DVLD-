using DVLD_Desktop_Net8.Local_Driving_License_Application.Services;
using DVLD_Desktop_Net8.Test;
using DVLD_Desktop_Net8.User;
using DVLD_Desktop_Net8.User.Services;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
using DVLDShared.DTOs.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.Local_Driving_License_Application
{
    public partial class fmLocalDrivingLicenseApplicationList : Form
    {
        //members
        private readonly LocalDrivingLicenseApplicationService _localDriving = new LocalDrivingLicenseApplicationService();
        private List<LocalDrivingLicenseApplicationListDTO>? _localDrivingLicensesDTO;
        public enum enMode { AddNew = 0, Update = 1 }




        //constructor
        public fmLocalDrivingLicenseApplicationList()
        {
            InitializeComponent();
        }




        private void fmLocalDrivingLicenseApplicationList_Load(object sender, EventArgs e)
        {
            LoadDataOfLocalDriving();
        }


        //methods
        private void _FillRecordsCount()
        {
            labRecordsCount.Text = $"Total Records: {dgvLocalDrivingLicenseApplicationList.Rows.Count.ToString()}";
        }

        private void WhictTest()
        {
            var cellValue = dgvLocalDrivingLicenseApplicationList.CurrentRow.Cells["PassedTests"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int lDLAppID))
            {
                if(lDLAppID == 0)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = true;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                }
                else if(lDLAppID == 1)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                }
                else
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                }
            }

        }

        private async void LoadDataOfLocalDriving()
        {
            _localDrivingLicensesDTO = await _localDriving.GetAllLocalDrivingLicenseApplication();
            dgvLocalDrivingLicenseApplicationList.DataSource = _localDrivingLicensesDTO;
            dgvLocalDrivingLicenseApplicationList.Columns[1].Width = 250;
            dgvLocalDrivingLicenseApplicationList.Columns[3].Width = 250;


            cbFilterBy.SelectedIndex = 0;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;

            _FillRecordsCount();
        }

        private int? _GetSelectedLocalDrivingID()
        {
            // 1. التأكد من تحديد سطر حالي في DataGridView
            if (dgvLocalDrivingLicenseApplicationList.CurrentRow == null || dgvLocalDrivingLicenseApplicationList.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a Local Driving License Application from the list first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // 2. قراءة UserID بأمان
            var cellValue = dgvLocalDrivingLicenseApplicationList.CurrentRow.Cells["lDLAppID"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int lDLAppID))
            {
                return lDLAppID;
            }

            MessageBox.Show("Could not read Local Driving License Application ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }













        //handlers

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvLocalDrivingLicenseApplicationList.ClearSelection();//حذف الخيارات السابقه
                dgvLocalDrivingLicenseApplicationList.Rows[e.RowIndex].Selected = true;//تحديد السطر
                dgvLocalDrivingLicenseApplicationList.CurrentCell = dgvLocalDrivingLicenseApplicationList.Rows[e.RowIndex].Cells[0];//تحديد الخلية
            }
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            fmNewLocalDrivingLicenseApplication fmNewLocal = new fmNewLocalDrivingLicenseApplication();
            fmNewLocal.ShowDialog();
            LoadDataOfLocalDriving();
        }


        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_localDrivingLicensesDTO == null || !_localDrivingLicensesDTO.Any()) return;

            string selectedFilter = cbFilterBy.Text;
            string filterValue = txtFilterValue.Text.Trim().ToLower();

            // إذا كانت خانة البحث فارغة أو الخيار None، اعرض القائمة كاملة
            if (string.IsNullOrEmpty(filterValue) || selectedFilter == "None")
            {
                dgvLocalDrivingLicenseApplicationList.DataSource = _localDrivingLicensesDTO;
                _FillRecordsCount();
                return;
            }

            // تطبيق الفلترة باستخدام LINQ حسب الخيار المختار
            IEnumerable<LocalDrivingLicenseApplicationListDTO> filteredResult = selectedFilter switch
            {
                "L.D.L.App ID" => _localDrivingLicensesDTO.Where(p => p.LDLAppID.ToString().StartsWith(filterValue)),

                "Driving Class" => _localDrivingLicensesDTO.Where(p => !string.IsNullOrEmpty(p.DrivingClass) &&
                                                                       p.DrivingClass.ToLower().Contains(filterValue)),

                "National No" => _localDrivingLicensesDTO.Where(p => !string.IsNullOrEmpty(p.NationalNo) &&
                                                                     p.NationalNo.ToLower().StartsWith(filterValue)),

                "Full Name" => _localDrivingLicensesDTO.Where(p => !string.IsNullOrEmpty(p.FullName) &&
                                                                   p.FullName.ToLower().Contains(filterValue)),

                // ✅ تحويل التاريخ لنص بنفس التنسيق المعروض قبل المقارنة
                "Application Date" => _localDrivingLicensesDTO.Where(p => p.ApplicationDate.ToString("yyyy-MM-dd").Contains(filterValue) ||
                                                                           p.ApplicationDate.ToShortDateString().Contains(filterValue)),

                // ✅ تحويل عدد الاختبارات الممتنازة إلى نص أولاً
                "Passed Tests" => _localDrivingLicensesDTO.Where(p => p.PassedTests.ToString().StartsWith(filterValue)),

                "Status" => _localDrivingLicensesDTO.Where(p => !string.IsNullOrEmpty(p.Status) &&
                                                                p.Status.ToLower().StartsWith(filterValue)),

                _ => _localDrivingLicensesDTO
            };

            // إسناد القائمة المفلترة للـ DataGridView
            dgvLocalDrivingLicenseApplicationList.DataSource = filteredResult.ToList();
            // تحديث عداد السجلات الظاهرة
            _FillRecordsCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Passed Tests" || cbFilterBy.Text == "L.D.L.App ID")
            {
                // السماح بالأرقام فقط (IsDigit) وزر المسح Backspace (IsControl)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // منع إدخال الحروف والرموز
                }
            }
        }


        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvLocalDrivingLicenseApplicationList.CurrentRow == null || dgvLocalDrivingLicenseApplicationList.CurrentRow.Index < 0)
            {
                e.Cancel = true;
            }
            WhictTest();
        }

        private async void cancedApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? lDLAppID = _GetSelectedLocalDrivingID();
            if (lDLAppID == null) return;

            // 1. تأكيد عملية الإلغاء مع صياغة النص بشكل صحيح
            if (MessageBox.Show($"Are you sure you want to cancel Local Driving License Application [{lDLAppID.Value}]?",
                                "Confirm Cancel",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /// <summary>
                /// 1-New 2-Cancelled 3-Completed
                /// </summary>
                byte cancelledStatus = 2;
                UpdateStatusDTO statusDTO = new UpdateStatusDTO(lDLAppID.Value, cancelledStatus);
                var result = await _localDriving.UpdateLocalDrivingLicenseApplicationStatus(lDLAppID.Value, statusDTO);

                // 3. التحقق من نجاح عملية التحديث
                if (result != null && result.Success)
                {
                    MessageBox.Show("Local driving license application cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // إعادة تحميل البيانات لجدول الـ DataGridView
                    LoadDataOfLocalDriving();
                }
                else
                {
                    // عرض رسالة الخطأ القادمة من السيرفر أو LastError
                    MessageBox.Show(result?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? Id = _GetSelectedLocalDrivingID();
            if (Id == null) return;
            fmListTestAppointments fmListTestAppointments = new fmListTestAppointments(Id.Value);
            fmListTestAppointments.ShowDialog();
        }







        //empty handlers
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void dgvLocalDrivingLicenseApplicationList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLocalDrivingLicenseApplicationList_MouseDown(object sender, MouseEventArgs e)
        {

        }
















        //private async void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int? userId = _GetSelectedUserID();
        //    if (userId == null) return;

        //    if (MessageBox.Show($"Are you sure you want to delete User [{userId.Value}]?", "Confirm Delete",
        //        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        if (await _userService.DeleteUser(userId.Value))
        //        {
        //            MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadDataOfUsers();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int? userId = _GetSelectedUserID();
        //    int? personId = _GetSelectedPersonID();

        //    if (userId == null || personId == null) return;

        //    fmAddUpdateUser fmUpdateUser = new fmAddUpdateUser(userId.Value, personId.Value);
        //    fmUpdateUser.ShowDialog();
        //    LoadDataOfUsers();
        //}

        //private void AddNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    fmAddUpdateUser fmAddNewUser = new fmAddUpdateUser();
        //    fmAddNewUser.ShowDialog();
        //    LoadDataOfUsers();
        //}

        //private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int? userId = _GetSelectedUserID();
        //    if (userId == null) return;
        //    MessageBox.Show("Phone Call functionality is not implemented yet.");
        //}

        //private void ChangePasswordPersonToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int? userId = _GetSelectedUserID();
        //    if (userId == null) return;

        //    fmChangePassword fmChangePassword = new fmChangePassword(userId.Value);
        //    fmChangePassword.ShowDialog();
        //    LoadDataOfUsers();
        //}

        //private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int? userId = _GetSelectedUserID();
        //    if (userId == null) return;


        //    fmShowUserDetails fmShowUserDetails = new fmShowUserDetails(userId.Value);
        //    fmShowUserDetails.ShowDialog();
        //}
    }
}
