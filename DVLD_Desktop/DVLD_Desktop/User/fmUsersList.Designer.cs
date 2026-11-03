namespace DVLD_Desktop_Net8.User
{
    partial class fmUsersList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmUsersList));
            dgvUsers = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ShowDetailsToolStripMenuItem = new ToolStripMenuItem();
            AddNewPersonToolStripMenuItem = new ToolStripMenuItem();
            updatePersonToolStripMenuItem = new ToolStripMenuItem();
            ChangePasswordPersonToolStripMenuItem = new ToolStripMenuItem();
            deletePersonToolStripMenuItem = new ToolStripMenuItem();
            sendEmailToolStripMenuItem = new ToolStripMenuItem();
            phoneCallToolStripMenuItem = new ToolStripMenuItem();
            labRecordsCount = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            btAddNewUser = new Button();
            label2 = new Label();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            btClose = new Button();
            cbIsActive = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToOrderColumns = true;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.ContextMenuStrip = contextMenuStrip1;
            dgvUsers.Location = new Point(3, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.Size = new Size(708, 199);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellMouseDown += dataGridView1_CellMouseDown;
            dgvUsers.MouseDown += dgvUsers_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { ShowDetailsToolStripMenuItem, AddNewPersonToolStripMenuItem, updatePersonToolStripMenuItem, ChangePasswordPersonToolStripMenuItem, deletePersonToolStripMenuItem, sendEmailToolStripMenuItem, phoneCallToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(169, 158);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // ShowDetailsToolStripMenuItem
            // 
            ShowDetailsToolStripMenuItem.Name = "ShowDetailsToolStripMenuItem";
            ShowDetailsToolStripMenuItem.Size = new Size(168, 22);
            ShowDetailsToolStripMenuItem.Text = "Show Details";
            ShowDetailsToolStripMenuItem.Click += ShowDetailsToolStripMenuItem_Click;
            // 
            // AddNewPersonToolStripMenuItem
            // 
            AddNewPersonToolStripMenuItem.Name = "AddNewPersonToolStripMenuItem";
            AddNewPersonToolStripMenuItem.Size = new Size(168, 22);
            AddNewPersonToolStripMenuItem.Text = "Add New User";
            AddNewPersonToolStripMenuItem.Click += AddNewPersonToolStripMenuItem_Click;
            // 
            // updatePersonToolStripMenuItem
            // 
            updatePersonToolStripMenuItem.Name = "updatePersonToolStripMenuItem";
            updatePersonToolStripMenuItem.Size = new Size(168, 22);
            updatePersonToolStripMenuItem.Text = "Edit";
            updatePersonToolStripMenuItem.Click += updatePersonToolStripMenuItem_Click;
            // 
            // ChangePasswordPersonToolStripMenuItem
            // 
            ChangePasswordPersonToolStripMenuItem.Name = "ChangePasswordPersonToolStripMenuItem";
            ChangePasswordPersonToolStripMenuItem.Size = new Size(168, 22);
            ChangePasswordPersonToolStripMenuItem.Text = "Change Password";
            ChangePasswordPersonToolStripMenuItem.Click += ChangePasswordPersonToolStripMenuItem_Click;
            // 
            // deletePersonToolStripMenuItem
            // 
            deletePersonToolStripMenuItem.Name = "deletePersonToolStripMenuItem";
            deletePersonToolStripMenuItem.Size = new Size(168, 22);
            deletePersonToolStripMenuItem.Text = "Delete";
            deletePersonToolStripMenuItem.Click += deletePersonToolStripMenuItem_Click;
            // 
            // sendEmailToolStripMenuItem
            // 
            sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            sendEmailToolStripMenuItem.Size = new Size(168, 22);
            sendEmailToolStripMenuItem.Text = "Send Email";
            sendEmailToolStripMenuItem.Click += sendEmailToolStripMenuItem_Click;
            // 
            // phoneCallToolStripMenuItem
            // 
            phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            phoneCallToolStripMenuItem.Size = new Size(168, 22);
            phoneCallToolStripMenuItem.Text = "Phone Call";
            phoneCallToolStripMenuItem.Click += phoneCallToolStripMenuItem_Click;
            // 
            // labRecordsCount
            // 
            labRecordsCount.AutoSize = true;
            labRecordsCount.Font = new Font("Segoe UI", 11F);
            labRecordsCount.Location = new Point(12, 418);
            labRecordsCount.Name = "labRecordsCount";
            labRecordsCount.Size = new Size(23, 20);
            labRecordsCount.TabIndex = 1;
            labRecordsCount.Text = "??";
            labRecordsCount.Click += labRecordsCount_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(302, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 97);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(265, 112);
            label1.Name = "label1";
            label1.Size = new Size(212, 40);
            label1.TabIndex = 3;
            label1.Text = "Manage Users";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvUsers);
            panel1.Location = new Point(9, 210);
            panel1.Name = "panel1";
            panel1.Size = new Size(714, 205);
            panel1.TabIndex = 4;
            // 
            // btAddNewUser
            // 
            btAddNewUser.FlatStyle = FlatStyle.Flat;
            btAddNewUser.Image = (Image)resources.GetObject("btAddNewUser.Image");
            btAddNewUser.Location = new Point(667, 151);
            btAddNewUser.Name = "btAddNewUser";
            btAddNewUser.Size = new Size(56, 53);
            btAddNewUser.TabIndex = 5;
            btAddNewUser.UseVisualStyleBackColor = true;
            btAddNewUser.Click += btAddNewUser_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 179);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 6;
            label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "User ID", "UserName", "Person ID", "Full Name", "Is Active" });
            cbFilterBy.Location = new Point(67, 176);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(121, 23);
            cbFilterBy.TabIndex = 7;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(204, 176);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(171, 23);
            txtFilterValue.TabIndex = 8;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = Properties.Resources.Close_32;
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(606, 421);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 9;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // cbIsActive
            // 
            cbIsActive.FormattingEnabled = true;
            cbIsActive.Items.AddRange(new object[] { "All", "Yes", "No" });
            cbIsActive.Location = new Point(204, 176);
            cbIsActive.Name = "cbIsActive";
            cbIsActive.Size = new Size(76, 23);
            cbIsActive.TabIndex = 10;
            cbIsActive.SelectedIndexChanged += cbIsActive_SelectedIndexChanged;
            // 
            // fmUsersList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(765, 465);
            ControlBox = false;
            Controls.Add(cbIsActive);
            Controls.Add(btClose);
            Controls.Add(txtFilterValue);
            Controls.Add(cbFilterBy);
            Controls.Add(label2);
            Controls.Add(btAddNewUser);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(labRecordsCount);
            Name = "fmUsersList";
            Text = "Users List";
            Load += fmUsersList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsers;
        private Label labRecordsCount;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private Button btAddNewUser;
        private Label label2;
        private ComboBox cbFilterBy;
        private TextBox txtFilterValue;
        private Button btClose;
        private ComboBox cbIsActive;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ShowDetailsToolStripMenuItem;
        private ToolStripMenuItem AddNewPersonToolStripMenuItem;
        private ToolStripMenuItem updatePersonToolStripMenuItem;
        private ToolStripMenuItem ChangePasswordPersonToolStripMenuItem;
        private ToolStripMenuItem deletePersonToolStripMenuItem;
        private ToolStripMenuItem sendEmailToolStripMenuItem;
        private ToolStripMenuItem phoneCallToolStripMenuItem;
    }
}