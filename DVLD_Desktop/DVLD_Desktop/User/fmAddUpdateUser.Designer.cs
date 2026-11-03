namespace DVLD_Desktop_Net8.User
{
    partial class fmAddUpdateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAddUpdateUser));
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            ucPersonCardWithFilter1 = new DVLD_Desktop_Net8.People.Control.ucPersonCardWithFilter();
            tabPage2 = new TabPage();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            lbUserID = new Label();
            chkBoxIsActive = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            errorProvider1 = new ErrorProvider(components);
            btClose = new Button();
            btSave = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(358, 9);
            label1.Name = "label1";
            label1.Size = new Size(221, 40);
            label1.TabIndex = 0;
            label1.Text = "Add New  User";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 52);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(872, 401);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ucPersonCardWithFilter1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(864, 373);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Personal Info";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucPersonCardWithFilter1
            // 
            ucPersonCardWithFilter1.BackColor = Color.White;
            ucPersonCardWithFilter1.Location = new Point(6, 6);
            ucPersonCardWithFilter1.Name = "ucPersonCardWithFilter1";
            ucPersonCardWithFilter1.Size = new Size(795, 361);
            ucPersonCardWithFilter1.TabIndex = 0;
            ucPersonCardWithFilter1.Load += ucPersonCardWithFilter1_Load;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtConfirmPassword);
            tabPage2.Controls.Add(txtPassword);
            tabPage2.Controls.Add(txtUserName);
            tabPage2.Controls.Add(lbUserID);
            tabPage2.Controls.Add(chkBoxIsActive);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(864, 373);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Login Info";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 9F);
            txtConfirmPassword.Location = new Point(186, 170);
            txtConfirmPassword.Multiline = true;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(131, 23);
            txtConfirmPassword.TabIndex = 8;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;
            txtConfirmPassword.KeyPress += txtConfirmPassword_KeyPress;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(186, 133);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(131, 23);
            txtPassword.TabIndex = 7;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(186, 96);
            txtUserName.Multiline = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(131, 23);
            txtUserName.TabIndex = 6;
            // 
            // lbUserID
            // 
            lbUserID.AutoSize = true;
            lbUserID.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbUserID.Location = new Point(186, 62);
            lbUserID.Name = "lbUserID";
            lbUserID.Size = new Size(30, 20);
            lbUserID.TabIndex = 5;
            lbUserID.Text = "???";
            // 
            // chkBoxIsActive
            // 
            chkBoxIsActive.AutoSize = true;
            chkBoxIsActive.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkBoxIsActive.Location = new Point(186, 210);
            chkBoxIsActive.Name = "chkBoxIsActive";
            chkBoxIsActive.Size = new Size(74, 19);
            chkBoxIsActive.TabIndex = 4;
            chkBoxIsActive.Text = "Is Active";
            chkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label5.Location = new Point(30, 173);
            label5.Name = "label5";
            label5.Size = new Size(141, 20);
            label5.TabIndex = 3;
            label5.Text = "Confirm Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.Location = new Point(30, 136);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 2;
            label4.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(30, 99);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 1;
            label3.Text = "UserName:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(30, 62);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 0;
            label2.Text = "UserID:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(622, 459);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 2;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // btSave
            // 
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI", 10F);
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageAlign = ContentAlignment.MiddleLeft;
            btSave.Location = new Point(767, 459);
            btSave.Name = "btSave";
            btSave.Size = new Size(117, 32);
            btSave.TabIndex = 3;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // fmAddUpdateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(928, 508);
            Controls.Add(btSave);
            Controls.Add(btClose);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Name = "fmAddUpdateUser";
            Text = "fmAddNewUser";
            Load += fmAddNewUser_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private People.Control.ucPersonCardWithFilter ucPersonCardWithFilter1;
        private Label label2;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label lbUserID;
        private CheckBox chkBoxIsActive;
        private Label label5;
        private Label label4;
        private Label label3;
        private ErrorProvider errorProvider1;
        private Button btSave;
        private Button btClose;
    }
}