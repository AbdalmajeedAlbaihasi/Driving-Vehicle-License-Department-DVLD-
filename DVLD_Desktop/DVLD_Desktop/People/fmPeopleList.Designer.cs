namespace DVLD_Desktop_Net8

{
    partial class fmPeopleList
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
            dgvPeople = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ShowDetailsToolStripMenuItem = new ToolStripMenuItem();
            AddNewPersonToolStripMenuItem = new ToolStripMenuItem();
            updatePersonToolStripMenuItem = new ToolStripMenuItem();
            deletePersonToolStripMenuItem = new ToolStripMenuItem();
            sendEmailToolStripMenuItem = new ToolStripMenuItem();
            phoneCallToolStripMenuItem = new ToolStripMenuItem();
            cbFilterBy = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            btAddNewPerson = new Button();
            btClose = new Button();
            labRecordsCount = new Label();
            txtFilterValue = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPeople).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvPeople
            // 
            dgvPeople.BackgroundColor = Color.White;
            dgvPeople.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeople.ContextMenuStrip = contextMenuStrip1;
            dgvPeople.Location = new Point(14, 181);
            dgvPeople.Margin = new Padding(4, 3, 4, 3);
            dgvPeople.Name = "dgvPeople";
            dgvPeople.Size = new Size(1116, 275);
            dgvPeople.TabIndex = 0;
            dgvPeople.CellContentClick += dataGridView1_CellContentClick;
            dgvPeople.CellFormatting += dgvPeople_CellFormatting;
            dgvPeople.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { ShowDetailsToolStripMenuItem, AddNewPersonToolStripMenuItem, updatePersonToolStripMenuItem, deletePersonToolStripMenuItem, sendEmailToolStripMenuItem, phoneCallToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 158);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // ShowDetailsToolStripMenuItem
            // 
            ShowDetailsToolStripMenuItem.Name = "ShowDetailsToolStripMenuItem";
            ShowDetailsToolStripMenuItem.Size = new Size(180, 22);
            ShowDetailsToolStripMenuItem.Text = "Show Details";
            ShowDetailsToolStripMenuItem.Click += ShowDetailsToolStripMenuItem_Click_1;
            // 
            // AddNewPersonToolStripMenuItem
            // 
            AddNewPersonToolStripMenuItem.Name = "AddNewPersonToolStripMenuItem";
            AddNewPersonToolStripMenuItem.Size = new Size(180, 22);
            AddNewPersonToolStripMenuItem.Text = "Add New Person";
            AddNewPersonToolStripMenuItem.Click += AddNewPersonToolStripMenuItem_Click;
            // 
            // updatePersonToolStripMenuItem
            // 
            updatePersonToolStripMenuItem.Name = "updatePersonToolStripMenuItem";
            updatePersonToolStripMenuItem.Size = new Size(180, 22);
            updatePersonToolStripMenuItem.Text = "Edit";
            updatePersonToolStripMenuItem.Click += updatePersonToolStripMenuItem_Click;
            // 
            // deletePersonToolStripMenuItem
            // 
            deletePersonToolStripMenuItem.Name = "deletePersonToolStripMenuItem";
            deletePersonToolStripMenuItem.Size = new Size(180, 22);
            deletePersonToolStripMenuItem.Text = "Delete";
            deletePersonToolStripMenuItem.Click += deletePersonToolStripMenuItem_Click_1;
            // 
            // sendEmailToolStripMenuItem
            // 
            sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            sendEmailToolStripMenuItem.Size = new Size(180, 22);
            sendEmailToolStripMenuItem.Text = "Send Email";
            sendEmailToolStripMenuItem.Click += sendEmailToolStripMenuItem_Click;
            // 
            // phoneCallToolStripMenuItem
            // 
            phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            phoneCallToolStripMenuItem.Size = new Size(180, 22);
            phoneCallToolStripMenuItem.Text = "Phone Call";
            phoneCallToolStripMenuItem.Click += phoneCallToolStripMenuItem_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Person ID", "National No.", "First Name", "Second Name", "Third Name", "Last Name", "Nationality", "Gendor", "Phone", "Email" });
            cbFilterBy.Location = new Point(100, 152);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(104, 23);
            cbFilterBy.TabIndex = 2;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            cbFilterBy.SelectedValueChanged += cbFilterBy_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(451, 112);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(241, 36);
            label1.TabIndex = 4;
            label1.Text = "Manage People";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 153);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 16);
            label2.TabIndex = 6;
            label2.Text = "Filter By:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.People_400;
            pictureBox1.Location = new Point(502, 14);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 85);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btAddNewPerson
            // 
            btAddNewPerson.BackColor = Color.White;
            btAddNewPerson.BackgroundImage = Properties.Resources.Add_Person_72;
            btAddNewPerson.BackgroundImageLayout = ImageLayout.Stretch;
            btAddNewPerson.Location = new Point(1058, 117);
            btAddNewPerson.Margin = new Padding(4, 3, 4, 3);
            btAddNewPerson.Name = "btAddNewPerson";
            btAddNewPerson.Size = new Size(72, 58);
            btAddNewPerson.TabIndex = 1;
            btAddNewPerson.UseVisualStyleBackColor = false;
            btAddNewPerson.Click += btAddNewPerson_Click;
            // 
            // btClose
            // 
            btClose.BackColor = Color.White;
            btClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 192);
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = Properties.Resources.Close_32;
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(1013, 462);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 7;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = false;
            btClose.Click += btClose_Click;
            // 
            // labRecordsCount
            // 
            labRecordsCount.AutoSize = true;
            labRecordsCount.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            labRecordsCount.Location = new Point(14, 471);
            labRecordsCount.Name = "labRecordsCount";
            labRecordsCount.Size = new Size(14, 16);
            labRecordsCount.TabIndex = 9;
            labRecordsCount.Text = "?";
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(221, 152);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(148, 23);
            txtFilterValue.TabIndex = 10;
            txtFilterValue.Visible = false;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // fmPeopleList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1134, 511);
            ControlBox = false;
            Controls.Add(txtFilterValue);
            Controls.Add(labRecordsCount);
            Controls.Add(btClose);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(cbFilterBy);
            Controls.Add(btAddNewPerson);
            Controls.Add(dgvPeople);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fmPeopleList";
            Text = "fmPeople";
            Load += fmPeople_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPeople).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button btAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private Button btClose;
        private Label labRecordsCount;
        private TextBox txtFilterValue;
    }
}