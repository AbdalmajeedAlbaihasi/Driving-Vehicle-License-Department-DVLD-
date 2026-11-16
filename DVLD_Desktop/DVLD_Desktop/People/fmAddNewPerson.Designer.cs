namespace DVLD_Desktop_Net8
{
    partial class fmAddNewPerson
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
            SuspendLayout();
            // 
            // fmAddNewPerson
            // 
            ClientSize = new Size(284, 261);
            Name = "fmAddNewPerson";
            Load += fmAddNewPerson_Load_1;
            ResumeLayout(false);
            label1 = new Label();
            label3 = new Label();
            labelPersonID = new Label();
            pnlContainer = new Panel();
            ucAddUpdatePerson = new ucAddUpdatePerson();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(299, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 25);
            label1.TabIndex = 3;
            label1.Text = "Add New Person";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(39, 31);
            label3.Name = "label3";
            label3.Size = new Size(91, 21);
            label3.TabIndex = 5;
            label3.Text = "Person ID :";
            // 
            // labelPersonID
            // 
            labelPersonID.AutoSize = true;
            labelPersonID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPersonID.Location = new Point(161, 32);
            labelPersonID.Name = "labelPersonID";
            labelPersonID.Size = new Size(38, 21);
            labelPersonID.TabIndex = 6;
            labelPersonID.Text = "N/A";
            labelPersonID.Click += label4_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(ucAddUpdatePerson);
            pnlContainer.Location = new Point(16, 63);
            pnlContainer.Margin = new Padding(4, 3, 4, 3);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(682, 298);
            pnlContainer.TabIndex = 2;
            pnlContainer.Paint += pnlContainer_Paint;
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
            // fmAddNewPerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(726, 386);
            ControlBox = false;
            Controls.Add(labelPersonID);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pnlContainer);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fmAddNewPerson";
            Text = "Add New Person";
            Load += fmAddNewPerson_Load;
            pnlContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        //private ucAddUpdatePerson ucAddPeople1;
        private System.Windows.Forms.Label label1;
        private Label label3;
        private Label labelPersonID;
        //private ucAddUpdatePerson ucAddPeople;
        private Panel pnlContainer;
        private ucAddUpdatePerson ucAddUpdatePerson;
    }
}