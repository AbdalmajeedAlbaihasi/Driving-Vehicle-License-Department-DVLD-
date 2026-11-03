using DVLD_Desktop_Net8.Local_Driving_License_Application.Services;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.Local_Driving_License_Application.NewFolder
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private int _DLAppID;
            
        private readonly LocalDrivingLicenseApplicationService?  _localDriving = new LocalDrivingLicenseApplicationService();

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public async Task LoadData(int DLAppId)
        {
            await ctrlApplicationBasicInfo1.loadData(DLAppId);

            GetOneLocalDrivingLicenseApplicationDTO? dto = await _localDriving.GetOneLocalDrivingLicenseApplicationsAsync(DLAppId);
            if (dto == null)
            {
                MessageBox.Show("No Local Driving License Application found with this ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingLicenseApplicationID.Text = dto.LDLAppID.ToString();
            lblAppliedFor.Text = dto.DrivingClass.ToString();
            lblPassedTests.Text = dto.PassedTests.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
