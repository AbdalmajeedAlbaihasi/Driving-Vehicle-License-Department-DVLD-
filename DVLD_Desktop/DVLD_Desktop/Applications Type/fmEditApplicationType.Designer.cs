namespace DVLD_Desktop_Net8.Application
{
    partial class fmEditApplicationType
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblApplicationTypeID = new Label();
            txtTitle = new TextBox();
            txtFees = new TextBox();
            btSavePerson = new Button();
            btClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(39, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(308, 35);
            label1.TabIndex = 0;
            label1.Text = "Update Application Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(13, 75);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(29, 20);
            label2.TabIndex = 1;
            label2.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(13, 114);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 2;
            label3.Text = "Title:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.Location = new Point(13, 158);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 3;
            label4.Text = "Fees:";
            // 
            // lblApplicationTypeID
            // 
            lblApplicationTypeID.AutoSize = true;
            lblApplicationTypeID.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblApplicationTypeID.Location = new Point(99, 75);
            lblApplicationTypeID.Margin = new Padding(4, 0, 4, 0);
            lblApplicationTypeID.Name = "lblApplicationTypeID";
            lblApplicationTypeID.Size = new Size(42, 20);
            lblApplicationTypeID.TabIndex = 4;
            lblApplicationTypeID.Text = "[???]";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9F);
            txtTitle.Location = new Point(99, 111);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(260, 22);
            txtTitle.TabIndex = 5;
            // 
            // txtFees
            // 
            txtFees.Font = new Font("Segoe UI", 9F);
            txtFees.Location = new Point(99, 158);
            txtFees.Multiline = true;
            txtFees.Name = "txtFees";
            txtFees.Size = new Size(260, 22);
            txtFees.TabIndex = 6;
            txtFees.KeyPress += txtFees_KeyPress;
            // 
            // btSavePerson
            // 
            btSavePerson.FlatAppearance.MouseDownBackColor = Color.Blue;
            btSavePerson.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btSavePerson.FlatStyle = FlatStyle.Flat;
            btSavePerson.Font = new Font("Segoe UI", 10F);
            btSavePerson.Image = Properties.Resources.Save_32;
            btSavePerson.ImageAlign = ContentAlignment.MiddleLeft;
            btSavePerson.Location = new Point(242, 199);
            btSavePerson.Margin = new Padding(4, 3, 4, 3);
            btSavePerson.Name = "btSavePerson";
            btSavePerson.Size = new Size(117, 32);
            btSavePerson.TabIndex = 33;
            btSavePerson.Text = "Save";
            btSavePerson.UseVisualStyleBackColor = true;
            btSavePerson.Click += btSavePerson_Click;
            // 
            // btClose
            // 
            btClose.FlatAppearance.MouseDownBackColor = Color.Blue;
            btClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = Properties.Resources.Close_32;
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(110, 199);
            btClose.Margin = new Padding(4, 3, 4, 3);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 32;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // fmEditApplicationType
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 243);
            ControlBox = false;
            Controls.Add(btSavePerson);
            Controls.Add(btClose);
            Controls.Add(txtFees);
            Controls.Add(txtTitle);
            Controls.Add(lblApplicationTypeID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            Margin = new Padding(4);
            Name = "fmEditApplicationType";
            Text = "Edit Application Type";
            Load += fmEditApplicationType_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblApplicationTypeID;
        private TextBox txtTitle;
        private TextBox txtFees;
        private Button btSavePerson;
        private Button btClose;
    }
}