namespace DVLD_Desktop_Net8.Local_Driving_License_Application
{
    partial class fmNewLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmNewLocalDrivingLicenseApplication));
            btSave = new Button();
            btClose = new Button();
            lbApplicationID = new Label();
            tabPage1 = new TabPage();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            comboBox1 = new ComboBox();
            lbCreatedBy = new Label();
            lbApplicationFees = new Label();
            lbApplicationDate = new Label();
            label6 = new Label();
            label1 = new Label();
            ucPersonCardWithFilter1 = new DVLD_Desktop_Net8.People.Control.ucPersonCardWithFilter();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // btSave
            // 
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI", 10F);
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageAlign = ContentAlignment.MiddleLeft;
            btSave.Location = new Point(757, 462);
            btSave.Name = "btSave";
            btSave.Size = new Size(117, 32);
            btSave.TabIndex = 7;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(612, 462);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 6;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // lbApplicationID
            // 
            lbApplicationID.AutoSize = true;
            lbApplicationID.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbApplicationID.Location = new Point(189, 65);
            lbApplicationID.Name = "lbApplicationID";
            lbApplicationID.Size = new Size(42, 20);
            lbApplicationID.TabIndex = 5;
            lbApplicationID.Text = "[???]";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ucPersonCardWithFilter1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(864, 373);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Personal Info";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label5.Location = new Point(33, 176);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 3;
            label5.Text = "Application Fees:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.Location = new Point(33, 139);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 2;
            label4.Text = "License Class:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(33, 102);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 1;
            label3.Text = "Application Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(33, 65);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 0;
            label2.Text = "D.L.Application ID:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, 57);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(872, 401);
            tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(lbCreatedBy);
            tabPage2.Controls.Add(lbApplicationFees);
            tabPage2.Controls.Add(lbApplicationDate);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(lbApplicationID);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(864, 373);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Application Info";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(189, 139);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 23);
            comboBox1.TabIndex = 13;
            // 
            // lbCreatedBy
            // 
            lbCreatedBy.AutoSize = true;
            lbCreatedBy.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbCreatedBy.Location = new Point(189, 210);
            lbCreatedBy.Name = "lbCreatedBy";
            lbCreatedBy.Size = new Size(42, 20);
            lbCreatedBy.TabIndex = 12;
            lbCreatedBy.Text = "[???]";
            // 
            // lbApplicationFees
            // 
            lbApplicationFees.AutoSize = true;
            lbApplicationFees.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbApplicationFees.Location = new Point(189, 176);
            lbApplicationFees.Name = "lbApplicationFees";
            lbApplicationFees.Size = new Size(42, 20);
            lbApplicationFees.TabIndex = 11;
            lbApplicationFees.Text = "[???]";
            // 
            // lbApplicationDate
            // 
            lbApplicationDate.AutoSize = true;
            lbApplicationDate.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbApplicationDate.Location = new Point(189, 102);
            lbApplicationDate.Name = "lbApplicationDate";
            lbApplicationDate.Size = new Size(42, 20);
            lbApplicationDate.TabIndex = 10;
            lbApplicationDate.Text = "[???]";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label6.Location = new Point(33, 210);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 9;
            label6.Text = "Created By:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(189, 9);
            label1.Name = "label1";
            label1.Size = new Size(540, 40);
            label1.TabIndex = 4;
            label1.Text = "New Local Driving License Application";
            label1.Click += label1_Click;
            // 
            // ucPersonCardWithFilter1
            // 
            ucPersonCardWithFilter1.BackColor = Color.White;
            ucPersonCardWithFilter1.Location = new Point(3, 3);
            ucPersonCardWithFilter1.Name = "ucPersonCardWithFilter1";
            ucPersonCardWithFilter1.Size = new Size(801, 362);
            ucPersonCardWithFilter1.TabIndex = 0;
            // 
            // fmNewLocalDrivingLicenseApplication
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 514);
            ControlBox = false;
            Controls.Add(btSave);
            Controls.Add(btClose);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Name = "fmNewLocalDrivingLicenseApplication";
            Text = "New Local Driving License Application";
            Load += fmNewLocalDrivingLicenseApplication_Load;
            tabPage1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btSave;
        private Button btClose;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private People.Control.ucPersonCardWithFilter ucPersonCardWithFilter1;
        private TabPage tabPage2;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label lbApplicationID;
        private CheckBox chkBoxIsActive;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private ComboBox comboBox1;
        private Label lbCreatedBy;
        private Label lbApplicationFees;
        private Label lbApplicationDate;
    }
}