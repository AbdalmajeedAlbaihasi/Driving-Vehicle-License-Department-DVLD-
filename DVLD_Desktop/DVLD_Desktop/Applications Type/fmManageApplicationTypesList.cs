using DVLD_Desktop_Net8.Application.Services;
using DVLD_Desktop_Net8.User.Services;
using DVLDShared.DTOs.ApplicationsType;
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

namespace DVLD_Desktop_Net8.Application
{
    public partial class fmManageApplicationTypesList : Form
    {
        private readonly ManageApplicationTypesService _manageApplicationTypesService = new ManageApplicationTypesService();
        private List<ApplicationsTypeDTO>? applicationsTypeDTOs;
        public fmManageApplicationTypesList()
        {
            InitializeComponent();
        }

        private async void LoadDataOfApplicationTypes()
        {
            applicationsTypeDTOs = await _manageApplicationTypesService.GetAllApplicationTypesAsync();
            dgvApplicationTypes.DataSource = applicationsTypeDTOs;
            dgvApplicationTypes.Columns[1].Width = 300;



            _FillRecordsCount();
        }

        private void _FillRecordsCount()
        {
            labRecordsCount.Text = $"Total Records: {dgvApplicationTypes.Rows.Count.ToString()}";
        }

        private int? _GetSelectedApplicationTypeId()
        {
            // 1. التأكد من تحديد سطر حالي في DataGridView
            if (dgvApplicationTypes.CurrentRow == null || dgvApplicationTypes.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select an Application Type from the list first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }


            var cellValue = dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeId"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int ApplicationTypeId))
            {
                return ApplicationTypeId;
            }

            MessageBox.Show("Could not read Application Type ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void fmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            LoadDataOfApplicationTypes();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? ApplicationTypeId = _GetSelectedApplicationTypeId();
            if (ApplicationTypeId == null) return;

            fmEditApplicationType fmEditApplicationType = new fmEditApplicationType(ApplicationTypeId.Value);
            fmEditApplicationType.ShowDialog();

            LoadDataOfApplicationTypes();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvApplicationTypes.CurrentRow == null || dgvApplicationTypes.CurrentRow.Index < 0)
            {
                e.Cancel = true;
            }
        }

        private void dgvApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvApplicationTypes.ClearSelection();//حذف الخيارات السابقه
                dgvApplicationTypes.Rows[e.RowIndex].Selected = true;//تحديد السطر
                dgvApplicationTypes.CurrentCell = dgvApplicationTypes.Rows[e.RowIndex].Cells[0];//تحديد الخلية
            }
        }
    }
}
