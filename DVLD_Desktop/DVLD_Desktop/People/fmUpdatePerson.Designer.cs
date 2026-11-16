namespace DVLD_Desktop_Net8
{
    partial class fmUpdatePerson
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
            labelPersonID = new Label();
            label3 = new Label();
            label1 = new Label();
            pnlContainer = new Panel();
            ucAddUpdatePerson = new ucAddUpdatePerson();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // labelPersonID
            // 
            labelPersonID.AutoSize = true;
            labelPersonID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPersonID.Location = new Point(148, 32);
            labelPersonID.Name = "labelPersonID";
            labelPersonID.Size = new Size(38, 21);
            labelPersonID.TabIndex = 9;
            labelPersonID.Text = "N/A";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 31);
            label3.Name = "label3";
            label3.Size = new Size(91, 21);
            label3.TabIndex = 8;
            label3.Text = "Person ID :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(283, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 7;
            label1.Text = "Edit Person";
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(ucAddUpdatePerson);
            pnlContainer.Location = new Point(26, 65);
            pnlContainer.Margin = new Padding(4, 3, 4, 3);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(682, 298);
            pnlContainer.TabIndex = 10;
            // 
            // ucAddUpdatePerson
            // 
            ucAddUpdatePerson.BackColor = Color.White;
            ucAddUpdatePerson.Location = new Point(0, 0);
            ucAddUpdatePerson.Margin = new Padding(4, 3, 4, 3);
            ucAddUpdatePerson.Name = "ucAddUpdatePerson";
            ucAddUpdatePerson.Size = new Size(682, 298);
            ucAddUpdatePerson.TabIndex = 0;
            ucAddUpdatePerson.Load += ucAddUpdatePerson_Load;
            // 
            // fmUpdatePerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(726, 386);
            ControlBox = false;
            Controls.Add(pnlContainer);
            Controls.Add(labelPersonID);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "fmUpdatePerson";
            Text = "fmUpdatePerson";
            Load += fmUpdatePerson_Load;
            pnlContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPersonID;
        private Label label3;
        private Label label1;
        private Panel pnlContainer;
        private ucAddUpdatePerson ucAddUpdatePerson;
    }
}