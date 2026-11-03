namespace DVLD_Desktop_Net8.Test_Type
{
    partial class fmEditTestType
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
            btSave = new Button();
            btClose = new Button();
            txtFees = new TextBox();
            txtTitle = new TextBox();
            lblTestTypeID = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDescription = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btSave
            // 
            btSave.FlatAppearance.MouseDownBackColor = Color.Blue;
            btSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI", 10F);
            btSave.Image = Properties.Resources.Save_32;
            btSave.ImageAlign = ContentAlignment.MiddleLeft;
            btSave.Location = new Point(325, 286);
            btSave.Margin = new Padding(4, 3, 4, 3);
            btSave.Name = "btSave";
            btSave.Size = new Size(117, 32);
            btSave.TabIndex = 42;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btClose
            // 
            btClose.FlatAppearance.MouseDownBackColor = Color.Blue;
            btClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = Properties.Resources.Close_32;
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(193, 286);
            btClose.Margin = new Padding(4, 3, 4, 3);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 41;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // txtFees
            // 
            txtFees.Font = new Font("Segoe UI", 9F);
            txtFees.Location = new Point(129, 247);
            txtFees.Multiline = true;
            txtFees.Name = "txtFees";
            txtFees.Size = new Size(313, 22);
            txtFees.TabIndex = 40;
            txtFees.KeyPress += txtFees_KeyPress;
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9F);
            txtTitle.Location = new Point(129, 112);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(313, 22);
            txtTitle.TabIndex = 39;
            // 
            // lblTestTypeID
            // 
            lblTestTypeID.AutoSize = true;
            lblTestTypeID.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblTestTypeID.Location = new Point(129, 76);
            lblTestTypeID.Margin = new Padding(4, 0, 4, 0);
            lblTestTypeID.Name = "lblTestTypeID";
            lblTestTypeID.Size = new Size(42, 20);
            lblTestTypeID.TabIndex = 38;
            lblTestTypeID.Text = "[???]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.Location = new Point(59, 246);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 37;
            label4.Text = "Fees:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(59, 111);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 36;
            label3.Text = "Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(71, 78);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(29, 20);
            label2.TabIndex = 35;
            label2.Text = "ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(148, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(220, 35);
            label1.TabIndex = 34;
            label1.Text = "Update Test Type";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9F);
            txtDescription.Location = new Point(129, 157);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(313, 84);
            txtDescription.TabIndex = 44;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label5.Location = new Point(12, 156);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 43;
            label5.Text = "Description:";
            // 
            // fmEditTestType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(496, 343);
            ControlBox = false;
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(btSave);
            Controls.Add(btClose);
            Controls.Add(txtFees);
            Controls.Add(txtTitle);
            Controls.Add(lblTestTypeID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "fmEditTestType";
            Text = "Edit Test Type";
            Load += fmEditTestType_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btSave;
        private Button btClose;
        private TextBox txtFees;
        private TextBox txtTitle;
        private Label lblTestTypeID;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDescription;
        private Label label5;
    }
}