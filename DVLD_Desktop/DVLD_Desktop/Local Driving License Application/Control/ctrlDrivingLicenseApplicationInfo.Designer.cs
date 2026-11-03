namespace DVLD_Desktop_Net8.Local_Driving_License_Application.NewFolder
{
    partial class ctrlDrivingLicenseApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            lblPassedTests = new Label();
            label14 = new Label();
            lblLocalDrivingLicenseApplicationID = new Label();
            lblR = new Label();
            llShowLicenceInfo = new Label();
            label18 = new Label();
            lblAppliedFor = new Label();
            ctrlApplicationBasicInfo1 = new DVLD_Desktop_Net8.Application.Control.ctrlApplicationBasicInfo();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblPassedTests);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(lblLocalDrivingLicenseApplicationID);
            groupBox2.Controls.Add(lblR);
            groupBox2.Controls.Add(llShowLicenceInfo);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(lblAppliedFor);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(848, 134);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Driving License Application Info";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // lblPassedTests
            // 
            lblPassedTests.AutoSize = true;
            lblPassedTests.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblPassedTests.Location = new Point(599, 79);
            lblPassedTests.Name = "lblPassedTests";
            lblPassedTests.Size = new Size(19, 20);
            lblPassedTests.TabIndex = 20;
            lblPassedTests.Text = "0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label14.Location = new Point(39, 45);
            label14.Name = "label14";
            label14.Size = new Size(103, 20);
            label14.TabIndex = 14;
            label14.Text = "D.L.App ID:";
            // 
            // lblLocalDrivingLicenseApplicationID
            // 
            lblLocalDrivingLicenseApplicationID.AutoSize = true;
            lblLocalDrivingLicenseApplicationID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblLocalDrivingLicenseApplicationID.Location = new Point(179, 45);
            lblLocalDrivingLicenseApplicationID.Name = "lblLocalDrivingLicenseApplicationID";
            lblLocalDrivingLicenseApplicationID.Size = new Size(49, 20);
            lblLocalDrivingLicenseApplicationID.TabIndex = 15;
            lblLocalDrivingLicenseApplicationID.Text = "[???]";
            // 
            // lblR
            // 
            lblR.AutoSize = true;
            lblR.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblR.Location = new Point(394, 45);
            lblR.Name = "lblR";
            lblR.Size = new Size(173, 20);
            lblR.TabIndex = 16;
            lblR.Text = "Applied For License:";
            // 
            // llShowLicenceInfo
            // 
            llShowLicenceInfo.AutoSize = true;
            llShowLicenceInfo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            llShowLicenceInfo.ForeColor = Color.Blue;
            llShowLicenceInfo.Location = new Point(179, 79);
            llShowLicenceInfo.Name = "llShowLicenceInfo";
            llShowLicenceInfo.Size = new Size(140, 20);
            llShowLicenceInfo.TabIndex = 17;
            llShowLicenceInfo.Text = "Show License Info";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label18.Location = new Point(394, 79);
            label18.Name = "label18";
            label18.Size = new Size(122, 20);
            label18.TabIndex = 18;
            label18.Text = "Passed Tests:";
            // 
            // lblAppliedFor
            // 
            lblAppliedFor.AutoSize = true;
            lblAppliedFor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblAppliedFor.Location = new Point(599, 45);
            lblAppliedFor.Name = "lblAppliedFor";
            lblAppliedFor.Size = new Size(49, 20);
            lblAppliedFor.TabIndex = 19;
            lblAppliedFor.Text = "[???]";
            // 
            // ctrlApplicationBasicInfo1
            // 
            ctrlApplicationBasicInfo1.BackColor = Color.White;
            ctrlApplicationBasicInfo1.Location = new Point(3, 143);
            ctrlApplicationBasicInfo1.Name = "ctrlApplicationBasicInfo1";
            ctrlApplicationBasicInfo1.Size = new Size(873, 242);
            ctrlApplicationBasicInfo1.TabIndex = 3;
            // 
            // ctrlDrivingLicenseApplicationInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ctrlApplicationBasicInfo1);
            Controls.Add(groupBox2);
            Name = "ctrlDrivingLicenseApplicationInfo";
            Size = new Size(883, 391);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label label14;
        private Label lblLocalDrivingLicenseApplicationID;
        private Label lblR;
        private Label llShowLicenceInfo;
        private Label label18;
        private Label lblAppliedFor;
        private Label lblPassedTests;
        private Application.Control.ctrlApplicationBasicInfo ctrlApplicationBasicInfo1;
    }
}
