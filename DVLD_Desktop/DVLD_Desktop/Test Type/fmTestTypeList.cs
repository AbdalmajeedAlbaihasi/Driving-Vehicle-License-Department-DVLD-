using DVLD_Desktop_Net8.Application.Services;
using DVLD_Desktop_Net8.Test_Type.Services;
using DVLDShared.DTOs.ApplicationsType;
using DVLDShared.DTOs.TestType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.Test_Type
{
    public partial class fmTestTypeList : Form
    {
        private readonly TestTypeService _testTypeService = new TestTypeService();
        private List<TestTypeDTO>? testTypeDTOs;


        public fmTestTypeList()
        {
            InitializeComponent();
        }

        private void fmTestTypeList_Load(object sender, EventArgs e)
        {
            LoadDataOfTestTypes();
        }



        private async void LoadDataOfTestTypes()
        {
            testTypeDTOs = await _testTypeService.GetAllTestTypes();
            dgvTestTypes.DataSource = testTypeDTOs;
            dgvTestTypes.Columns[1].Width = 300;



            _FillRecordsCount();
        }

        private void _FillRecordsCount()
        {
            labRecordsCount.Text = $"Total Records: {dgvTestTypes.Rows.Count.ToString()}";
        }

        private int? _GetSelectedTestTypeId()
        {
            // 1. التأكد من تحديد سطر حالي في DataGridView
            if (dgvTestTypes.CurrentRow == null || dgvTestTypes.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select an Test Type from the list first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }


            var cellValue = dgvTestTypes.CurrentRow.Cells["TestTypeId"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int TestTypeId))
            {
                return TestTypeId;
            }

            MessageBox.Show("Could not read Test Type ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }


        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvTestTypes.CurrentRow == null || dgvTestTypes.CurrentRow.Index < 0)
            {
                e.Cancel = true;
            }
        }

        private void dgvApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvTestTypes.ClearSelection();//حذف الخيارات السابقه
                dgvTestTypes.Rows[e.RowIndex].Selected = true;//تحديد السطر
                dgvTestTypes.CurrentCell = dgvTestTypes.Rows[e.RowIndex].Cells[0];//تحديد الخلية
            }
        }



        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? TestTypeId = _GetSelectedTestTypeId();
            if (TestTypeId == null) return;

            fmEditTestType fmEditTestType = new fmEditTestType(TestTypeId.Value);
            fmEditTestType.ShowDialog();

            LoadDataOfTestTypes();
        }

        
    }
}
