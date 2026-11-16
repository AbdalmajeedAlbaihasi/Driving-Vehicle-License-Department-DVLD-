using DVLD_Desktop_Net8.Application;
using DVLD_Desktop_Net8.Local_Driving_License_Application;
using DVLD_Desktop_Net8.Test_Type;
using DVLD_Desktop_Net8.User;
using System.ComponentModel;

namespace DVLD_Desktop_Net8
{
    public partial class fmMain : Form
    {
        private readonly int _userID;

        //constructors
        public fmMain()
        {
            InitializeComponent();
        }

        public fmMain(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }






        //handlers
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmPeopleList fmPeople = new fmPeopleList();
            fmPeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fmUsersList fmUsers = new fmUsersList();
            fmUsers.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser.ClearCurrentUser();
            this.Close();
            fmLogin fmLogin = new fmLogin();
            fmLogin.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChangePassword fmChangePassword = new fmChangePassword(_userID);
            fmChangePassword.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmShowUserDetails fmShowUserDetails = new fmShowUserDetails(_userID);
            fmShowUserDetails.ShowDialog();
        }






        //Empty event handlers for the controls in the form
        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void accountSetngsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void applToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fmMain_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmManageApplicationTypesList fmManageApplicationTypes = new fmManageApplicationTypesList();
            fmManageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmTestTypeList fmTestTypeList = new fmTestTypeList();
            fmTestTypeList.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmNewLocalDrivingLicenseApplication fmNewLocal = new fmNewLocalDrivingLicenseApplication();
            fmNewLocal.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmLocalDrivingLicenseApplicationList fmLocalDrivingLicenseApplicationList = new fmLocalDrivingLicenseApplicationList();
            fmLocalDrivingLicenseApplicationList.ShowDialog();
        }
    }
}
