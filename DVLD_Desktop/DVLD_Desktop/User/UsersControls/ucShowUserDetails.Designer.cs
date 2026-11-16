namespace DVLD_Desktop_Net8.User.UsersControls
{
    partial class ucShowUserDetails
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
            ucShowPesronDetails1 = new DVLD_Desktop_Net8.User_Control.ucShowPesronDetails();
            groupBox1 = new GroupBox();
            lblIsActive = new Label();
            label5 = new Label();
            label4 = new Label();
            lblUserName = new Label();
            lblUserID = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // ucShowPesronDetails1
            // 
            ucShowPesronDetails1.BackColor = Color.White;
            ucShowPesronDetails1.Location = new Point(3, 3);
            ucShowPesronDetails1.Name = "ucShowPesronDetails1";
            ucShowPesronDetails1.Size = new Size(803, 271);
            ucShowPesronDetails1.TabIndex = 0;
            ucShowPesronDetails1.Load += ucShowPesronDetails1_Load;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblIsActive);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblUserName);
            groupBox1.Controls.Add(lblUserID);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Italic);
            groupBox1.Location = new Point(3, 270);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(779, 75);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "User Information";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblIsActive
            // 
            lblIsActive.AutoSize = true;
            lblIsActive.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblIsActive.Location = new Point(589, 34);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new Size(36, 17);
            lblIsActive.TabIndex = 5;
            lblIsActive.Text = "[???]";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label5.Location = new Point(508, 34);
            label5.Name = "label5";
            label5.Size = new Size(60, 17);
            label5.TabIndex = 4;
            label5.Text = "Is Active";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.Location = new Point(280, 34);
            label4.Name = "label4";
            label4.Size = new Size(75, 17);
            label4.TabIndex = 3;
            label4.Text = "UserName:";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUserName.Location = new Point(367, 34);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(36, 17);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "[???]";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUserID.Location = new Point(166, 34);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(36, 17);
            lblUserID.TabIndex = 1;
            lblUserID.Text = "[???]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(99, 34);
            label1.Name = "label1";
            label1.Size = new Size(57, 17);
            label1.TabIndex = 0;
            label1.Text = "User ID:";
            // 
            // ucShowUserDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(groupBox1);
            Controls.Add(ucShowPesronDetails1);
            Name = "ucShowUserDetails";
            Size = new Size(803, 373);
            Load += ucShowUserDetails_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private User_Control.ucShowPesronDetails ucShowPesronDetails1;
        private GroupBox groupBox1;
        private Label lblIsActive;
        private Label label5;
        private Label label4;
        private Label lblUserName;
        private Label lblUserID;
        private Label label1;
    }
}
