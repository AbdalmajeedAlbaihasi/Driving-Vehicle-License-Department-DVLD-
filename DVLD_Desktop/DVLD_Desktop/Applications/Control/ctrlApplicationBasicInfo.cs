using DVLD_Desktop_Net8.Application.Services;
using DVLD_Desktop_Net8.Applications.Services;
using DVLDShared.DTOs.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.Application.Control
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private readonly ApplicationService? _applicationService = new ApplicationService();
        private int _personId;
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }



        public async Task loadData(int LocalDrivingLicenseApplicationId)
        {

            GetApplicationByLocalDrivingLicenseApplicationIdDTO? dto =
                await _applicationService.GetApplicationByLocalDrivingLicenseApplicationId(LocalDrivingLicenseApplicationId);

            if (dto == null)
            {
                MessageBox.Show("No Application found with this ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = dto.ApplicationId.ToString();
            lblStatus.Text = dto.ApplicationStatus.ToString();
            lblFees.Text = dto.PaidFees.ToString();
            lblType.Text = dto.ApplicationTypeTitle.ToString();
            lblApplicant.Text = dto.Applicant.ToString();
            lblDate.Text = dto.ApplicationDate.ToString();
            lblStatusDate.Text = dto.LastStatusDate.ToString();
            lblCreatedByUser.Text = dto.CreatedByUser.ToString();

            _personId = dto.PersonId;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlApplicationBasicInfo_Load(object sender, EventArgs e)
        {
        }

        private void llViewPersonInfo_Click(object sender, EventArgs e)
        {
            if (_personId <= 0) return;
            fmShowDetails fmShowDetails = new fmShowDetails(_personId);
            fmShowDetails.ShowDialog();
        }
    }
}
