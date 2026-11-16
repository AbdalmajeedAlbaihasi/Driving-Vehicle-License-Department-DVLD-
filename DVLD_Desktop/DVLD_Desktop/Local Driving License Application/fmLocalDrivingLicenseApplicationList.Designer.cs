namespace DVLD_Desktop_Net8.Local_Driving_License_Application
{
    partial class fmLocalDrivingLicenseApplicationList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmLocalDrivingLicenseApplicationList));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            dgvLocalDrivingLicenseApplicationList = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteApplicationToolStripMenuItem = new ToolStripMenuItem();
            cancedApplicationToolStripMenuItem = new ToolStripMenuItem();
            secliduleTestsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            scheduleVisionTestToolStripMenuItem = new ToolStripMenuItem();
            scheduleWrittenTestToolStripMenuItem = new ToolStripMenuItem();
            scheduleStreetTestToolStripMenuItem = new ToolStripMenuItem();
            editApplicationToolStripMenuItem = new ToolStripMenuItem();
            fenenTormeHatayToolStripMenuItem = new ToolStripMenuItem();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            labRecordsCount = new Label();
            btClose = new Button();
            panel1 = new Panel();
            txtFilterValue = new TextBox();
            cbFilterBy = new ComboBox();
            label2 = new Label();
            btAddNew = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLocalDrivingLicenseApplicationList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(400, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(154, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(205, 187);
            label1.Name = "label1";
            label1.Size = new Size(525, 40);
            label1.TabIndex = 6;
            label1.Text = "Local Driving License Application List";
            // 
            // dgvLocalDrivingLicenseApplicationList
            // 
            dgvLocalDrivingLicenseApplicationList.BackgroundColor = Color.White;
            dgvLocalDrivingLicenseApplicationList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocalDrivingLicenseApplicationList.ContextMenuStrip = contextMenuStrip1;
            dgvLocalDrivingLicenseApplicationList.Location = new Point(3, 3);
            dgvLocalDrivingLicenseApplicationList.Name = "dgvLocalDrivingLicenseApplicationList";
            dgvLocalDrivingLicenseApplicationList.Size = new Size(1097, 245);
            dgvLocalDrivingLicenseApplicationList.TabIndex = 2;
            dgvLocalDrivingLicenseApplicationList.CellContentClick += dgvLocalDrivingLicenseApplicationList_CellContentClick;
            dgvLocalDrivingLicenseApplicationList.CellMouseDown += dataGridView1_CellMouseDown;
            dgvLocalDrivingLicenseApplicationList.MouseDown += dgvLocalDrivingLicenseApplicationList_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteApplicationToolStripMenuItem, cancedApplicationToolStripMenuItem, secliduleTestsToolStripMenuItem, toolStripMenuItem2, toolStripMenuItem3, editApplicationToolStripMenuItem, fenenTormeHatayToolStripMenuItem, showPersonLicenseHistoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(246, 202);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // deleteApplicationToolStripMenuItem
            // 
            deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            deleteApplicationToolStripMenuItem.Size = new Size(245, 22);
            deleteApplicationToolStripMenuItem.Text = "&Show Application Details";
            // 
            // cancedApplicationToolStripMenuItem
            // 
            cancedApplicationToolStripMenuItem.Name = "cancedApplicationToolStripMenuItem";
            cancedApplicationToolStripMenuItem.Size = new Size(245, 22);
            cancedApplicationToolStripMenuItem.Text = "&Edit Application";
            cancedApplicationToolStripMenuItem.Click += cancedApplicationToolStripMenuItem_Click;
            // 
            // secliduleTestsToolStripMenuItem
            // 
            secliduleTestsToolStripMenuItem.Name = "secliduleTestsToolStripMenuItem";
            secliduleTestsToolStripMenuItem.Size = new Size(245, 22);
            secliduleTestsToolStripMenuItem.Text = "&Delete Application";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(245, 22);
            toolStripMenuItem2.Text = "&Cancel Application";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { scheduleVisionTestToolStripMenuItem, scheduleWrittenTestToolStripMenuItem, scheduleStreetTestToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(245, 22);
            toolStripMenuItem3.Text = "Sechdule &Tests";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            scheduleVisionTestToolStripMenuItem.Size = new Size(187, 22);
            scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            scheduleVisionTestToolStripMenuItem.Click += scheduleVisionTestToolStripMenuItem_Click;
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            scheduleWrittenTestToolStripMenuItem.Size = new Size(187, 22);
            scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            scheduleStreetTestToolStripMenuItem.Size = new Size(187, 22);
            scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            // 
            // editApplicationToolStripMenuItem
            // 
            editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            editApplicationToolStripMenuItem.Size = new Size(245, 22);
            editApplicationToolStripMenuItem.Text = "&Issue Driving License (First Time)";
            // 
            // fenenTormeHatayToolStripMenuItem
            // 
            fenenTormeHatayToolStripMenuItem.Name = "fenenTormeHatayToolStripMenuItem";
            fenenTormeHatayToolStripMenuItem.Size = new Size(245, 22);
            fenenTormeHatayToolStripMenuItem.Text = "Show &License";
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(245, 22);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // labRecordsCount
            // 
            labRecordsCount.AutoSize = true;
            labRecordsCount.Font = new Font("Segoe UI", 11F);
            labRecordsCount.Location = new Point(27, 562);
            labRecordsCount.Name = "labRecordsCount";
            labRecordsCount.Size = new Size(23, 20);
            labRecordsCount.TabIndex = 10;
            labRecordsCount.Text = "??";
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(1013, 556);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 9;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvLocalDrivingLicenseApplicationList);
            panel1.Location = new Point(27, 299);
            panel1.Name = "panel1";
            panel1.Size = new Size(1103, 251);
            panel1.TabIndex = 8;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(221, 259);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(171, 23);
            txtFilterValue.TabIndex = 14;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // cbFilterBy
            // 
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "L.D.L.App ID", "Driving Class", "National No", "Full Name", "Application Date", "Passed Tests", "Status" });
            cbFilterBy.Location = new Point(84, 259);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(121, 23);
            cbFilterBy.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 262);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 12;
            label2.Text = "Filter By:";
            // 
            // btAddNew
            // 
            btAddNew.FlatStyle = FlatStyle.Flat;
            btAddNew.Image = (Image)resources.GetObject("btAddNew.Image");
            btAddNew.Location = new Point(1060, 225);
            btAddNew.Name = "btAddNew";
            btAddNew.Size = new Size(67, 71);
            btAddNew.TabIndex = 11;
            btAddNew.UseVisualStyleBackColor = true;
            btAddNew.Click += btAddNew_Click;
            // 
            // fmLocalDrivingLicenseApplicationList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1177, 600);
            Controls.Add(txtFilterValue);
            Controls.Add(cbFilterBy);
            Controls.Add(label2);
            Controls.Add(btAddNew);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(labRecordsCount);
            Controls.Add(btClose);
            Controls.Add(panel1);
            Name = "fmLocalDrivingLicenseApplicationList";
            Text = "Local Driving License Application List";
            Load += fmLocalDrivingLicenseApplicationList_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLocalDrivingLicenseApplicationList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private DataGridView dgvLocalDrivingLicenseApplicationList;
        private ContextMenuStrip contextMenuStrip1;
        private Label labRecordsCount;
        private Button btClose;
        private Panel panel1;
        private ComboBox cbIsActive;
        private TextBox txtFilterValue;
        private ComboBox cbFilterBy;
        private Label label2;
        private Button btAddNew;
        private ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private ToolStripMenuItem cancedApplicationToolStripMenuItem;
        private ToolStripMenuItem secliduleTestsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem editApplicationToolStripMenuItem;
        private ToolStripMenuItem fenenTormeHatayToolStripMenuItem;
        private ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}