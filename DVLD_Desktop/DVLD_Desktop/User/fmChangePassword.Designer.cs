namespace DVLD_Desktop_Net8.User
{
    partial class fmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmChangePassword));
            ucShowUserDetails1 = new DVLD_Desktop_Net8.User.UsersControls.ucShowUserDetails();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtBoxCurrentPassword = new TextBox();
            txtBoxNewPassword = new TextBox();
            txtBoxConfirmPassword = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            btSave = new Button();
            btClose = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // ucShowUserDetails1
            // 
            ucShowUserDetails1.BackColor = Color.White;
            ucShowUserDetails1.Location = new Point(-1, -2);
            ucShowUserDetails1.Name = "ucShowUserDetails1";
            ucShowUserDetails1.Size = new Size(789, 353);
            ucShowUserDetails1.TabIndex = 0;
            ucShowUserDetails1.Load += ucShowUserDetails1_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(40, 366);
            label1.Name = "label1";
            label1.Size = new Size(120, 17);
            label1.TabIndex = 1;
            label1.Text = "Current Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(40, 394);
            label2.Name = "label2";
            label2.Size = new Size(101, 17);
            label2.TabIndex = 2;
            label2.Text = "New Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(40, 421);
            label3.Name = "label3";
            label3.Size = new Size(124, 17);
            label3.TabIndex = 3;
            label3.Text = "Confirm Password:";
            // 
            // txtBoxCurrentPassword
            // 
            txtBoxCurrentPassword.Location = new Point(210, 366);
            txtBoxCurrentPassword.Multiline = true;
            txtBoxCurrentPassword.Name = "txtBoxCurrentPassword";
            txtBoxCurrentPassword.Size = new Size(153, 22);
            txtBoxCurrentPassword.TabIndex = 4;
            txtBoxCurrentPassword.TextChanged += txtBoxCurrentPassword_TextChanged;
            // 
            // txtBoxNewPassword
            // 
            txtBoxNewPassword.Location = new Point(210, 393);
            txtBoxNewPassword.Name = "txtBoxNewPassword";
            txtBoxNewPassword.Size = new Size(153, 23);
            txtBoxNewPassword.TabIndex = 5;
            // 
            // txtBoxConfirmPassword
            // 
            txtBoxConfirmPassword.Location = new Point(210, 420);
            txtBoxConfirmPassword.Name = "txtBoxConfirmPassword";
            txtBoxConfirmPassword.Size = new Size(153, 23);
            txtBoxConfirmPassword.TabIndex = 6;
            txtBoxConfirmPassword.TextChanged += txtBoxConfirmPassword_TextChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btSave
            // 
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI", 10F);
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageAlign = ContentAlignment.MiddleLeft;
            btSave.Location = new Point(665, 444);
            btSave.Name = "btSave";
            btSave.Size = new Size(117, 32);
            btSave.TabIndex = 8;
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
            btClose.Location = new Point(520, 444);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 7;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // fmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 490);
            ControlBox = false;
            Controls.Add(btSave);
            Controls.Add(btClose);
            Controls.Add(txtBoxConfirmPassword);
            Controls.Add(txtBoxNewPassword);
            Controls.Add(txtBoxCurrentPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ucShowUserDetails1);
            Name = "fmChangePassword";
            Text = "Change Password";
            Load += fmChangePassword_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UsersControls.ucShowUserDetails ucShowUserDetails1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtBoxCurrentPassword;
        private TextBox txtBoxNewPassword;
        private TextBox txtBoxConfirmPassword;
        private ErrorProvider errorProvider1;
        private Button btSave;
        private Button btClose;
    }
}