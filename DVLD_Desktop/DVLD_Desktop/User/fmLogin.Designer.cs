namespace DVLD_Desktop_Net8.User
{
    partial class fmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmLogin));
            btClose = new Button();
            btLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            chkBxRememberMe = new CheckBox();
            SuspendLayout();
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.Location = new Point(690, 3);
            btClose.Name = "btClose";
            btClose.Size = new Size(33, 35);
            btClose.TabIndex = 0;
            btClose.TextAlign = ContentAlignment.MiddleLeft;
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // btLogin
            // 
            btLogin.FlatStyle = FlatStyle.Flat;
            btLogin.Font = new Font("Segoe UI", 10F);
            btLogin.Image = (Image)resources.GetObject("btLogin.Image");
            btLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btLogin.Location = new Point(470, 227);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(117, 32);
            btLogin.TabIndex = 1;
            btLogin.Text = "Login";
            btLogin.UseVisualStyleBackColor = true;
            btLogin.Click += btLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(377, 52);
            label1.Name = "label1";
            label1.Size = new Size(201, 25);
            label1.TabIndex = 2;
            label1.Text = "Login to your acount";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(344, 125);
            label2.Name = "label2";
            label2.Size = new Size(73, 17);
            label2.TabIndex = 3;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(345, 161);
            label3.Name = "label3";
            label3.Size = new Size(70, 17);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(437, 120);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(163, 23);
            txtUserName.TabIndex = 5;
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(437, 161);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(163, 23);
            txtPassword.TabIndex = 6;
            // 
            // chkBxRememberMe
            // 
            chkBxRememberMe.AutoSize = true;
            chkBxRememberMe.Location = new Point(441, 191);
            chkBxRememberMe.Name = "chkBxRememberMe";
            chkBxRememberMe.Size = new Size(104, 19);
            chkBxRememberMe.TabIndex = 7;
            chkBxRememberMe.Text = "Remember me";
            chkBxRememberMe.UseVisualStyleBackColor = true;
            // 
            // fmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(728, 319);
            ControlBox = false;
            Controls.Add(chkBxRememberMe);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btLogin);
            Controls.Add(btClose);
            Name = "fmLogin";
            Text = "fmLogin";
            Load += fmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btClose;
        private Button btLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private CheckBox chkBxRememberMe;
    }
}