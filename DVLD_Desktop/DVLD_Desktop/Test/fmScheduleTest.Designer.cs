namespace DVLD_Desktop_Net8.Test
{
    partial class fmScheduleTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmScheduleTest));
            crlScheduleTest1 = new DVLD_Desktop_Net8.Test.Controls.crlScheduleTest();
            btClose = new Button();
            SuspendLayout();
            // 
            // crlScheduleTest1
            // 
            crlScheduleTest1.BackColor = Color.White;
            crlScheduleTest1.Location = new Point(12, 12);
            crlScheduleTest1.Name = "crlScheduleTest1";
            crlScheduleTest1.Size = new Size(499, 655);
            crlScheduleTest1.TabIndex = 0;
            crlScheduleTest1.Load += crlScheduleTest1_Load;
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(193, 673);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 8;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            // 
            // fmScheduleTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(525, 729);
            ControlBox = false;
            Controls.Add(btClose);
            Controls.Add(crlScheduleTest1);
            Name = "fmScheduleTest";
            Text = "Schedule Test";
            Load += fmScheduleTest_Load;
            ResumeLayout(false);
        }

        #endregion

        private Controls.crlScheduleTest crlScheduleTest1;
        private Button btClose;
    }
}