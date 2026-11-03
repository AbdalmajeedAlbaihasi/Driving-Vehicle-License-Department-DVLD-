namespace DVLD_Desktop_Net8.User
{
    partial class fmShowUserDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmShowUserDetails));
            ucShowUserDetails1 = new DVLD_Desktop_Net8.User.UsersControls.ucShowUserDetails();
            btClose = new Button();
            SuspendLayout();
            // 
            // ucShowUserDetails1
            // 
            ucShowUserDetails1.BackColor = Color.White;
            ucShowUserDetails1.Location = new Point(0, -1);
            ucShowUserDetails1.Name = "ucShowUserDetails1";
            ucShowUserDetails1.Size = new Size(800, 359);
            ucShowUserDetails1.TabIndex = 0;
            ucShowUserDetails1.Load += ucShowUserDetails1_Load;
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(661, 364);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 8;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // fmShowUserDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(802, 412);
            ControlBox = false;
            Controls.Add(btClose);
            Controls.Add(ucShowUserDetails1);
            Name = "fmShowUserDetails";
            Text = "fmShowUserDetails";
            Load += fmShowUserDetails_Load;
            ResumeLayout(false);
        }

        #endregion

        private UsersControls.ucShowUserDetails ucShowUserDetails1;
        private Button btClose;
    }
}