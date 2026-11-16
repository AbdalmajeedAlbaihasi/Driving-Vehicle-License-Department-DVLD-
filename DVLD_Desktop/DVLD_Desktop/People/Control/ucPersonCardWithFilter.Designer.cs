namespace DVLD_Desktop_Net8.People.Control
{
    partial class ucPersonCardWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPersonCardWithFilter));
            groupBoxFilter = new GroupBox();
            txtFilterValue = new TextBox();
            btAddNewPerson = new Button();
            btFindPerson = new Button();
            cbFilterBy = new ComboBox();
            label1 = new Label();
            ucShowDetails2 = new DVLD_Desktop_Net8.User_Control.ucShowPesronDetails();
            groupBoxFilter.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(txtFilterValue);
            groupBoxFilter.Controls.Add(btAddNewPerson);
            groupBoxFilter.Controls.Add(btFindPerson);
            groupBoxFilter.Controls.Add(cbFilterBy);
            groupBoxFilter.Controls.Add(label1);
            groupBoxFilter.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Italic);
            groupBoxFilter.Location = new Point(3, 3);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(785, 77);
            groupBoxFilter.TabIndex = 1;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Filter";
            groupBoxFilter.Enter += groupBox1_Enter;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Font = new Font("Segoe UI", 10F);
            txtFilterValue.Location = new Point(215, 37);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(171, 25);
            txtFilterValue.TabIndex = 4;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // btAddNewPerson
            // 
            btAddNewPerson.FlatStyle = FlatStyle.Flat;
            btAddNewPerson.Image = (Image)resources.GetObject("btAddNewPerson.Image");
            btAddNewPerson.Location = new Point(523, 25);
            btAddNewPerson.Name = "btAddNewPerson";
            btAddNewPerson.Size = new Size(42, 45);
            btAddNewPerson.TabIndex = 3;
            btAddNewPerson.UseVisualStyleBackColor = true;
            btAddNewPerson.Click += btAddNewPerson_Click;
            // 
            // btFindPerson
            // 
            btFindPerson.FlatStyle = FlatStyle.Flat;
            btFindPerson.Image = (Image)resources.GetObject("btFindPerson.Image");
            btFindPerson.Location = new Point(452, 25);
            btFindPerson.Name = "btFindPerson";
            btFindPerson.Size = new Size(41, 45);
            btFindPerson.TabIndex = 2;
            btFindPerson.UseVisualStyleBackColor = true;
            btFindPerson.Click += btFindPerson_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.Font = new Font("Segoe UI", 10F);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "National NO", "Person ID" });
            cbFilterBy.Location = new Point(64, 37);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(121, 25);
            cbFilterBy.TabIndex = 1;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(6, 37);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 0;
            label1.Text = "Find by :";
            // 
            // ucShowDetails2
            // 
            ucShowDetails2.BackColor = Color.White;
            ucShowDetails2.Location = new Point(3, 86);
            ucShowDetails2.Name = "ucShowDetails2";
            ucShowDetails2.Size = new Size(803, 271);
            ucShowDetails2.TabIndex = 2;
            ucShowDetails2.Load += ucShowDetails2_Load;
            // 
            // ucPersonCardWithFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ucShowDetails2);
            Controls.Add(groupBoxFilter);
            Name = "ucPersonCardWithFilter";
            Size = new Size(801, 362);
            Load += ucPersonCardWithFilter_Load;
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private User_Control.ucShowPesronDetails ucShowDetails1;
        private GroupBox groupBoxFilter;
        private Button btAddNewPerson;
        private Button btFindPerson;
        private ComboBox cbFilterBy;
        private Label label1;
        private TextBox txtFilterValue;
        private User_Control.ucShowPesronDetails ucShowDetails2;
    }
}
