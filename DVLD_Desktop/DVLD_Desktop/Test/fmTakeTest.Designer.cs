namespace DVLD_Desktop_Net8.Test
{
    partial class fmTakeTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTakeTest));
            ctrlSecheduledTest1 = new DVLD_Desktop_Net8.Test.Controls.ctrlSecheduledTest();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNotes = new TextBox();
            rbPass = new RadioButton();
            rbFail = new RadioButton();
            btSave = new Button();
            btClose = new Button();
            SuspendLayout();
            // 
            // ctrlSecheduledTest1
            // 
            ctrlSecheduledTest1.BackColor = Color.White;
            ctrlSecheduledTest1.Location = new Point(12, 12);
            ctrlSecheduledTest1.Name = "ctrlSecheduledTest1";
            ctrlSecheduledTest1.Size = new Size(486, 517);
            ctrlSecheduledTest1.TabIndex = 0;
            ctrlSecheduledTest1.Load += ctrlSecheduledTest1_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label1.Location = new Point(21, 532);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 1;
            label1.Text = "Result:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(241, 532);
            label2.Name = "label2";
            label2.Size = new Size(255, 20);
            label2.TabIndex = 2;
            label2.Text = "You cannot change the results";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label3.Location = new Point(21, 564);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 3;
            label3.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Microsoft Sans Serif", 12F);
            txtNotes.Location = new Point(93, 564);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(403, 87);
            txtNotes.TabIndex = 4;
            // 
            // rbPass
            // 
            rbPass.AutoSize = true;
            rbPass.Font = new Font("Microsoft Sans Serif", 12F);
            rbPass.Location = new Point(93, 532);
            rbPass.Name = "rbPass";
            rbPass.Size = new Size(62, 24);
            rbPass.TabIndex = 5;
            rbPass.TabStop = true;
            rbPass.Text = "Pass";
            rbPass.UseVisualStyleBackColor = true;
            // 
            // rbFail
            // 
            rbFail.AutoSize = true;
            rbFail.Font = new Font("Microsoft Sans Serif", 12F);
            rbFail.Location = new Point(157, 532);
            rbFail.Name = "rbFail";
            rbFail.Size = new Size(52, 24);
            rbFail.TabIndex = 6;
            rbFail.TabStop = true;
            rbFail.Text = "Fail";
            rbFail.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Segoe UI", 10F);
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageAlign = ContentAlignment.MiddleLeft;
            btSave.Location = new Point(378, 668);
            btSave.Name = "btSave";
            btSave.Size = new Size(117, 32);
            btSave.TabIndex = 8;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            // 
            // btClose
            // 
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(233, 668);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 7;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            // 
            // fmTakeTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(508, 717);
            ControlBox = false;
            Controls.Add(btSave);
            Controls.Add(btClose);
            Controls.Add(rbFail);
            Controls.Add(rbPass);
            Controls.Add(txtNotes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctrlSecheduledTest1);
            Name = "fmTakeTest";
            Text = "Take Test";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.ctrlSecheduledTest ctrlSecheduledTest1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNotes;
        private RadioButton rbPass;
        private RadioButton rbFail;
        private Button btSave;
        private Button btClose;
    }
}