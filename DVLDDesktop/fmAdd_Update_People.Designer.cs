namespace DVLD_MainProject
{
    partial class fmAdd_Update_People
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
            this.ucAddPeople1 = new DVLD_MainProject.ucAddPeople();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucAddPeople1
            // 
            this.ucAddPeople1.Location = new System.Drawing.Point(6, 9);
            this.ucAddPeople1.Name = "ucAddPeople1";
            this.ucAddPeople1.Size = new System.Drawing.Size(596, 324);
            this.ucAddPeople1.TabIndex = 0;
            this.ucAddPeople1.OnClose += new System.EventHandler(this.ucAddPeople1_OnClose);
            this.ucAddPeople1.Load += new System.EventHandler(this.ucAddPeople1_Load);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.ucAddPeople1);
            this.pnlContainer.Location = new System.Drawing.Point(12, 3);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(602, 327);
            this.pnlContainer.TabIndex = 2;
            // 
            // fmAdd_Update_People
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 419);
            this.Controls.Add(this.pnlContainer);
            this.Name = "fmAdd_Update_People";
            this.Text = "fmAdd_People";
            this.Load += new System.EventHandler(this.fmAdd_People_Load);
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucAddPeople ucAddPeople1;
        private System.Windows.Forms.Panel pnlContainer;
    }
}