namespace DVLD_Desktop_Net8.Application
{
    partial class fmManageApplicationTypesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmManageApplicationTypesList));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            dgvApplicationTypes = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editApplicationTypeToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            btClose = new Button();
            labRecordsCount = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvApplicationTypes).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(84, 187);
            label1.Name = "label1";
            label1.Size = new Size(381, 40);
            label1.TabIndex = 0;
            label1.Text = "Manage Application Types";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(217, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(154, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dgvApplicationTypes
            // 
            dgvApplicationTypes.BackgroundColor = Color.White;
            dgvApplicationTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplicationTypes.ContextMenuStrip = contextMenuStrip1;
            dgvApplicationTypes.Location = new Point(3, 3);
            dgvApplicationTypes.Name = "dgvApplicationTypes";
            dgvApplicationTypes.Size = new Size(538, 245);
            dgvApplicationTypes.TabIndex = 2;
            dgvApplicationTypes.CellMouseDown += dgvApplicationTypes_CellMouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editApplicationTypeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(186, 26);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            editApplicationTypeToolStripMenuItem.Size = new Size(185, 22);
            editApplicationTypeToolStripMenuItem.Text = "Edit Application Type";
            editApplicationTypeToolStripMenuItem.Click += editApplicationTypeToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvApplicationTypes);
            panel1.Location = new Point(12, 275);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 251);
            panel1.TabIndex = 3;
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(441, 536);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 4;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // labRecordsCount
            // 
            labRecordsCount.AutoSize = true;
            labRecordsCount.Font = new Font("Segoe UI", 11F);
            labRecordsCount.Location = new Point(12, 548);
            labRecordsCount.Name = "labRecordsCount";
            labRecordsCount.Size = new Size(23, 20);
            labRecordsCount.TabIndex = 5;
            labRecordsCount.Text = "??";
            // 
            // fmManageApplicationTypes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(588, 603);
            ControlBox = false;
            Controls.Add(labRecordsCount);
            Controls.Add(btClose);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "fmManageApplicationTypes";
            Text = "Manage Application Types";
            Load += fmManageApplicationTypes_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvApplicationTypes).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView dgvApplicationTypes;
        private Panel panel1;
        private Button btClose;
        private Label labRecordsCount;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editApplicationTypeToolStripMenuItem;
    }
}