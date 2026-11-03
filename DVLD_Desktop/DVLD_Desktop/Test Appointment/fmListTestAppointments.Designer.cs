namespace DVLD_Desktop_Net8.Test
{
    partial class fmListTestAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmListTestAppointments));
            lblTitle = new Label();
            pbTestTypeImage = new PictureBox();
            label1 = new Label();
            labRecordsCount = new Label();
            btnAddNewAppointment = new Button();
            dgvLicenseTestAppointments = new DataGridView();
            btClose = new Button();
            ctrlDrivingLicenseApplicationInfo2 = new DVLD_Desktop_Net8.Local_Driving_License_Application.NewFolder.ctrlDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLicenseTestAppointments).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(224, 100);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(406, 37);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Vision Test Appointments";
            // 
            // pbTestTypeImage
            // 
            pbTestTypeImage.Image = (Image)resources.GetObject("pbTestTypeImage.Image");
            pbTestTypeImage.Location = new Point(365, 12);
            pbTestTypeImage.Name = "pbTestTypeImage";
            pbTestTypeImage.Size = new Size(134, 88);
            pbTestTypeImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbTestTypeImage.TabIndex = 3;
            pbTestTypeImage.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label1.Location = new Point(27, 529);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 6;
            label1.Text = "Appointments:";
            // 
            // labRecordsCount
            // 
            labRecordsCount.AutoSize = true;
            labRecordsCount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            labRecordsCount.Location = new Point(21, 720);
            labRecordsCount.Name = "labRecordsCount";
            labRecordsCount.Size = new Size(29, 20);
            labRecordsCount.TabIndex = 7;
            labRecordsCount.Text = "??";
            // 
            // btnAddNewAppointment
            // 
            btnAddNewAppointment.FlatStyle = FlatStyle.Flat;
            btnAddNewAppointment.Image = (Image)resources.GetObject("btnAddNewAppointment.Image");
            btnAddNewAppointment.Location = new Point(824, 518);
            btnAddNewAppointment.Name = "btnAddNewAppointment";
            btnAddNewAppointment.Size = new Size(47, 37);
            btnAddNewAppointment.TabIndex = 8;
            btnAddNewAppointment.UseVisualStyleBackColor = true;
            btnAddNewAppointment.Click += btnAddNewAppointment_Click;
            // 
            // dgvLicenseTestAppointments
            // 
            dgvLicenseTestAppointments.BackgroundColor = Color.White;
            dgvLicenseTestAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLicenseTestAppointments.Location = new Point(21, 561);
            dgvLicenseTestAppointments.Name = "dgvLicenseTestAppointments";
            dgvLicenseTestAppointments.Size = new Size(850, 142);
            dgvLicenseTestAppointments.TabIndex = 9;
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(754, 714);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 10;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btnClose_Click;
            // 
            // ctrlDrivingLicenseApplicationInfo2
            // 
            ctrlDrivingLicenseApplicationInfo2.BackColor = Color.White;
            ctrlDrivingLicenseApplicationInfo2.Location = new Point(4, 140);
            ctrlDrivingLicenseApplicationInfo2.Name = "ctrlDrivingLicenseApplicationInfo2";
            ctrlDrivingLicenseApplicationInfo2.Size = new Size(883, 372);
            ctrlDrivingLicenseApplicationInfo2.TabIndex = 11;
            // 
            // fmListTestAppointments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(892, 749);
            ControlBox = false;
            Controls.Add(ctrlDrivingLicenseApplicationInfo2);
            Controls.Add(btClose);
            Controls.Add(dgvLicenseTestAppointments);
            Controls.Add(btnAddNewAppointment);
            Controls.Add(labRecordsCount);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(pbTestTypeImage);
            Name = "fmListTestAppointments";
            Text = "List Test Appointments";
            Load += fmListTestAppointments_Load;
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLicenseTestAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private PictureBox pbTestTypeImage;
        private Local_Driving_License_Application.NewFolder.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private Label label1;
        private Label labRecordsCount;
        private Button btnAddNewAppointment;
        private DataGridView dgvLicenseTestAppointments;
        private Button btClose;
        private Local_Driving_License_Application.NewFolder.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo2;
    }
}