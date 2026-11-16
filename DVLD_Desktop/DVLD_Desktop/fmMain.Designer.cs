namespace DVLD_Desktop_Net8
{
    partial class fmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            menuStrip1 = new MenuStrip();
            ApplicationsToolStripMenuItem = new ToolStripMenuItem();
            drivingLicensesServicesToolStripMenuItem = new ToolStripMenuItem();
            newDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            localLicenseToolStripMenuItem = new ToolStripMenuItem();
            internationalLicenseToolStripMenuItem = new ToolStripMenuItem();
            renewDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            replacementForLostOrDamagedLicenseToolStripMenuItem = new ToolStripMenuItem();
            releaseDetainedDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            retakeTestToolStripMenuItem = new ToolStripMenuItem();
            manageApplicationsToolStripMenuItem = new ToolStripMenuItem();
            localDrivingLicenseApplicationsToolStripMenuItem = new ToolStripMenuItem();
            internationalLicenseApplicationsToolStripMenuItem = new ToolStripMenuItem();
            detainLicensesToolStripMenuItem = new ToolStripMenuItem();
            manageTestTypesToolStripMenuItem = new ToolStripMenuItem();
            manageTestTypesToolStripMenuItem1 = new ToolStripMenuItem();
            PeopletoolStripMenuItem = new ToolStripMenuItem();
            driversToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            accountSettingsToolStripMenuItem = new ToolStripMenuItem();
            currentUserInfoToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            signOutToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ApplicationsToolStripMenuItem, PeopletoolStripMenuItem, driversToolStripMenuItem, usersToolStripMenuItem, accountSettingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1301, 72);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // ApplicationsToolStripMenuItem
            // 
            ApplicationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { drivingLicensesServicesToolStripMenuItem, manageApplicationsToolStripMenuItem, detainLicensesToolStripMenuItem, manageTestTypesToolStripMenuItem, manageTestTypesToolStripMenuItem1 });
            ApplicationsToolStripMenuItem.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            ApplicationsToolStripMenuItem.Image = Properties.Resources.Applications_64;
            ApplicationsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            ApplicationsToolStripMenuItem.Name = "ApplicationsToolStripMenuItem";
            ApplicationsToolStripMenuItem.Size = new Size(166, 68);
            ApplicationsToolStripMenuItem.Text = "Applications";
            ApplicationsToolStripMenuItem.Click += applToolStripMenuItem_Click;
            // 
            // drivingLicensesServicesToolStripMenuItem
            // 
            drivingLicensesServicesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newDrivingLicenseToolStripMenuItem, renewDrivingLicenseToolStripMenuItem, replacementForLostOrDamagedLicenseToolStripMenuItem, releaseDetainedDrivingLicenseToolStripMenuItem, retakeTestToolStripMenuItem });
            drivingLicensesServicesToolStripMenuItem.Name = "drivingLicensesServicesToolStripMenuItem";
            drivingLicensesServicesToolStripMenuItem.Size = new Size(251, 22);
            drivingLicensesServicesToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localLicenseToolStripMenuItem, internationalLicenseToolStripMenuItem });
            newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            newDrivingLicenseToolStripMenuItem.Size = new Size(347, 22);
            newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            localLicenseToolStripMenuItem.Size = new Size(209, 22);
            localLicenseToolStripMenuItem.Text = "Local License";
            localLicenseToolStripMenuItem.Click += localLicenseToolStripMenuItem_Click;
            // 
            // internationalLicenseToolStripMenuItem
            // 
            internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            internationalLicenseToolStripMenuItem.Size = new Size(209, 22);
            internationalLicenseToolStripMenuItem.Text = "International License";
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            renewDrivingLicenseToolStripMenuItem.Size = new Size(347, 22);
            renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            // 
            // replacementForLostOrDamagedLicenseToolStripMenuItem
            // 
            replacementForLostOrDamagedLicenseToolStripMenuItem.Name = "replacementForLostOrDamagedLicenseToolStripMenuItem";
            replacementForLostOrDamagedLicenseToolStripMenuItem.Size = new Size(347, 22);
            replacementForLostOrDamagedLicenseToolStripMenuItem.Text = "Replacement for Lost or Damaged License";
            // 
            // releaseDetainedDrivingLicenseToolStripMenuItem
            // 
            releaseDetainedDrivingLicenseToolStripMenuItem.Name = "releaseDetainedDrivingLicenseToolStripMenuItem";
            releaseDetainedDrivingLicenseToolStripMenuItem.Size = new Size(347, 22);
            releaseDetainedDrivingLicenseToolStripMenuItem.Text = "Release Detained Driving License";
            // 
            // retakeTestToolStripMenuItem
            // 
            retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            retakeTestToolStripMenuItem.Size = new Size(347, 22);
            retakeTestToolStripMenuItem.Text = "Retake Test";
            // 
            // manageApplicationsToolStripMenuItem
            // 
            manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localDrivingLicenseApplicationsToolStripMenuItem, internationalLicenseApplicationsToolStripMenuItem });
            manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            manageApplicationsToolStripMenuItem.Size = new Size(251, 22);
            manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingLicenseApplicationsToolStripMenuItem
            // 
            localDrivingLicenseApplicationsToolStripMenuItem.Name = "localDrivingLicenseApplicationsToolStripMenuItem";
            localDrivingLicenseApplicationsToolStripMenuItem.Size = new Size(298, 22);
            localDrivingLicenseApplicationsToolStripMenuItem.Text = "Local Driving License Applications";
            localDrivingLicenseApplicationsToolStripMenuItem.Click += localDrivingLicenseApplicationsToolStripMenuItem_Click;
            // 
            // internationalLicenseApplicationsToolStripMenuItem
            // 
            internationalLicenseApplicationsToolStripMenuItem.Name = "internationalLicenseApplicationsToolStripMenuItem";
            internationalLicenseApplicationsToolStripMenuItem.Size = new Size(298, 22);
            internationalLicenseApplicationsToolStripMenuItem.Text = "International License Applications";
            // 
            // detainLicensesToolStripMenuItem
            // 
            detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            detainLicensesToolStripMenuItem.Size = new Size(251, 22);
            detainLicensesToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageTestTypesToolStripMenuItem
            // 
            manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            manageTestTypesToolStripMenuItem.Size = new Size(251, 22);
            manageTestTypesToolStripMenuItem.Text = "Manage Application Types";
            manageTestTypesToolStripMenuItem.Click += manageTestTypesToolStripMenuItem_Click;
            // 
            // manageTestTypesToolStripMenuItem1
            // 
            manageTestTypesToolStripMenuItem1.Name = "manageTestTypesToolStripMenuItem1";
            manageTestTypesToolStripMenuItem1.Size = new Size(251, 22);
            manageTestTypesToolStripMenuItem1.Text = "Manage Test Types";
            manageTestTypesToolStripMenuItem1.Click += manageTestTypesToolStripMenuItem1_Click;
            // 
            // PeopletoolStripMenuItem
            // 
            PeopletoolStripMenuItem.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            PeopletoolStripMenuItem.Image = Properties.Resources.People_64;
            PeopletoolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            PeopletoolStripMenuItem.Name = "PeopletoolStripMenuItem";
            PeopletoolStripMenuItem.Size = new Size(127, 68);
            PeopletoolStripMenuItem.Text = "People";
            PeopletoolStripMenuItem.Click += peopleToolStripMenuItem_Click;
            // 
            // driversToolStripMenuItem
            // 
            driversToolStripMenuItem.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            driversToolStripMenuItem.Image = Properties.Resources.Drivers_64;
            driversToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            driversToolStripMenuItem.Size = new Size(127, 68);
            driversToolStripMenuItem.Text = "Drivers";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            usersToolStripMenuItem.Image = Properties.Resources.Users_2_64;
            usersToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(116, 68);
            usersToolStripMenuItem.Text = "Users";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click_1;
            // 
            // accountSettingsToolStripMenuItem
            // 
            accountSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { currentUserInfoToolStripMenuItem, changePasswordToolStripMenuItem, signOutToolStripMenuItem });
            accountSettingsToolStripMenuItem.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            accountSettingsToolStripMenuItem.Image = Properties.Resources.account_settings_64;
            accountSettingsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            accountSettingsToolStripMenuItem.Size = new Size(191, 68);
            accountSettingsToolStripMenuItem.Text = "Account Settings";
            accountSettingsToolStripMenuItem.Click += accountSettingsToolStripMenuItem_Click;
            // 
            // currentUserInfoToolStripMenuItem
            // 
            currentUserInfoToolStripMenuItem.Image = (Image)resources.GetObject("currentUserInfoToolStripMenuItem.Image");
            currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            currentUserInfoToolStripMenuItem.Size = new Size(190, 22);
            currentUserInfoToolStripMenuItem.Text = "Current User Info";
            currentUserInfoToolStripMenuItem.Click += currentUserInfoToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Image = (Image)resources.GetObject("changePasswordToolStripMenuItem.Image");
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(190, 22);
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Image = (Image)resources.GetObject("signOutToolStripMenuItem.Image");
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(190, 22);
            signOutToolStripMenuItem.Text = "Sign Out";
            signOutToolStripMenuItem.Click += signOutToolStripMenuItem_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // fmMain
            // 
            BackColor = Color.Black;
            ClientSize = new Size(1301, 749);
            ControlBox = false;
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "fmMain";
            WindowState = FormWindowState.Maximized;
            Load += fmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PeopletoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem signOutToolStripMenuItem;
        private ToolStripMenuItem drivingLicensesServicesToolStripMenuItem;
        private ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private ToolStripMenuItem detainLicensesToolStripMenuItem;
        private ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private ToolStripMenuItem manageTestTypesToolStripMenuItem1;
        private ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem localLicenseToolStripMenuItem;
        private ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem replacementForLostOrDamagedLicenseToolStripMenuItem;
        private ToolStripMenuItem releaseDetainedDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem retakeTestToolStripMenuItem;
        private ToolStripMenuItem localDrivingLicenseApplicationsToolStripMenuItem;
        private ToolStripMenuItem internationalLicenseApplicationsToolStripMenuItem;
    }
}

