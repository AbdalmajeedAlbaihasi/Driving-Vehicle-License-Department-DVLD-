namespace DVLD_Desktop_Net8
{
    partial class ucAddUpdatePerson
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtFirstName = new TextBox();
            txtNationalNo = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            TxtThirdName = new TextBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            txtSecondName = new TextBox();
            bxCuntry = new ComboBox();
            colorDialog1 = new ColorDialog();
            dtDateOfBirth = new DateTimePicker();
            rdFmale = new RadioButton();
            rdMale = new RadioButton();
            btAddImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            errorProvider1 = new ErrorProvider(components);
            pictureBox1 = new PictureBox();
            btClose = new Button();
            btSavePerson = new Button();
            labRemoveImage = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 61);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 1;
            label2.Text = "National NO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 91);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 2;
            label3.Text = "Gendor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 120);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 153);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 4;
            label5.Text = "Address";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(273, 63);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 5;
            label6.Text = "Date of Birth";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(273, 94);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 6;
            label7.Text = "Phone";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(273, 122);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 7;
            label8.Text = "Cuntry";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(276, 10);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 9;
            label10.Text = "Second";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(446, 10);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(34, 15);
            label11.TabIndex = 10;
            label11.Text = "Third";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(576, 10);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(63, 15);
            label12.TabIndex = 11;
            label12.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(118, 26);
            txtFirstName.Margin = new Padding(4, 3, 4, 3);
            txtFirstName.Multiline = true;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(98, 18);
            txtFirstName.TabIndex = 12;
            // 
            // txtNationalNo
            // 
            txtNationalNo.Location = new Point(118, 61);
            txtNationalNo.Margin = new Padding(4, 3, 4, 3);
            txtNationalNo.Multiline = true;
            txtNationalNo.Name = "txtNationalNo";
            txtNationalNo.Size = new Size(98, 18);
            txtNationalNo.TabIndex = 13;
            txtNationalNo.Click += textBox2_Click;
            txtNationalNo.TextChanged += textBox2_TextChanged;
            txtNationalNo.Validating += txtNationalNo_Validating;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(118, 119);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(98, 18);
            txtEmail.TabIndex = 14;
            txtEmail.TextChanged += textBox3_TextChanged;
            txtEmail.Validating += txtEmail_Validating;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(118, 159);
            txtAddress.Margin = new Padding(4, 3, 4, 3);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(373, 70);
            txtAddress.TabIndex = 15;
            txtAddress.TextChanged += txtAddress_TextChanged;
            // 
            // TxtThirdName
            // 
            TxtThirdName.Location = new Point(414, 26);
            TxtThirdName.Margin = new Padding(4, 3, 4, 3);
            TxtThirdName.Multiline = true;
            TxtThirdName.Name = "TxtThirdName";
            TxtThirdName.Size = new Size(98, 18);
            TxtThirdName.TabIndex = 16;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(564, 26);
            txtLastName.Margin = new Padding(4, 3, 4, 3);
            txtLastName.Multiline = true;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(98, 18);
            txtLastName.TabIndex = 17;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(392, 94);
            txtPhone.Margin = new Padding(4, 3, 4, 3);
            txtPhone.Multiline = true;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(98, 18);
            txtPhone.TabIndex = 18;
            txtPhone.KeyPress += txtPhone_KeyPress;
            // 
            // txtSecondName
            // 
            txtSecondName.Location = new Point(264, 26);
            txtSecondName.Margin = new Padding(4, 3, 4, 3);
            txtSecondName.Multiline = true;
            txtSecondName.Name = "txtSecondName";
            txtSecondName.Size = new Size(98, 18);
            txtSecondName.TabIndex = 21;
            txtSecondName.TextChanged += textBox10_TextChanged;
            // 
            // bxCuntry
            // 
            bxCuntry.FormattingEnabled = true;
            bxCuntry.Location = new Point(392, 122);
            bxCuntry.Margin = new Padding(4, 3, 4, 3);
            bxCuntry.Name = "bxCuntry";
            bxCuntry.Size = new Size(98, 23);
            bxCuntry.TabIndex = 24;
            bxCuntry.SelectedIndexChanged += bxCuntry_SelectedIndexChanged;
            // 
            // dtDateOfBirth
            // 
            dtDateOfBirth.Format = DateTimePickerFormat.Short;
            dtDateOfBirth.Location = new Point(392, 61);
            dtDateOfBirth.Margin = new Padding(4, 3, 4, 3);
            dtDateOfBirth.Name = "dtDateOfBirth";
            dtDateOfBirth.Size = new Size(121, 23);
            dtDateOfBirth.TabIndex = 25;
            dtDateOfBirth.Value = new DateTime(2026, 10, 10, 9, 55, 22, 0);
            dtDateOfBirth.ValueChanged += dtDateOfBirth_ValueChanged;
            dtDateOfBirth.Validating += dtDateOfBirth_Validating;
            // 
            // rdFmale
            // 
            rdFmale.AutoSize = true;
            rdFmale.Location = new Point(181, 90);
            rdFmale.Margin = new Padding(4, 3, 4, 3);
            rdFmale.Name = "rdFmale";
            rdFmale.Size = new Size(57, 19);
            rdFmale.TabIndex = 26;
            rdFmale.TabStop = true;
            rdFmale.Text = "Fmale";
            rdFmale.UseVisualStyleBackColor = true;
            rdFmale.CheckedChanged += rdFmale_CheckedChanged;
            // 
            // rdMale
            // 
            rdMale.AutoSize = true;
            rdMale.Location = new Point(118, 91);
            rdMale.Margin = new Padding(4, 3, 4, 3);
            rdMale.Name = "rdMale";
            rdMale.Size = new Size(51, 19);
            rdMale.TabIndex = 27;
            rdMale.TabStop = true;
            rdMale.Text = "Male";
            rdMale.UseVisualStyleBackColor = true;
            rdMale.CheckedChanged += rdMale_CheckedChanged;
            // 
            // btAddImage
            // 
            btAddImage.FlatAppearance.MouseDownBackColor = Color.Blue;
            btAddImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btAddImage.FlatStyle = FlatStyle.Flat;
            btAddImage.Location = new Point(568, 171);
            btAddImage.Margin = new Padding(4, 3, 4, 3);
            btAddImage.Name = "btAddImage";
            btAddImage.Size = new Size(89, 26);
            btAddImage.TabIndex = 29;
            btAddImage.Text = "Add Image";
            btAddImage.UseVisualStyleBackColor = true;
            btAddImage.Click += btAddImage_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.Male_512;
            pictureBox1.Location = new Point(564, 61);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(99, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btClose
            // 
            btClose.FlatAppearance.MouseDownBackColor = Color.Blue;
            btClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.Font = new Font("Segoe UI", 10F);
            btClose.Image = Properties.Resources.Close_32;
            btClose.ImageAlign = ContentAlignment.MiddleLeft;
            btClose.Location = new Point(242, 244);
            btClose.Margin = new Padding(4, 3, 4, 3);
            btClose.Name = "btClose";
            btClose.Size = new Size(117, 32);
            btClose.TabIndex = 30;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // btSavePerson
            // 
            btSavePerson.FlatAppearance.BorderSize = 2;
            btSavePerson.FlatAppearance.MouseDownBackColor = Color.Blue;
            btSavePerson.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btSavePerson.FlatStyle = FlatStyle.Flat;
            btSavePerson.Font = new Font("Segoe UI", 10F);
            btSavePerson.Image = Properties.Resources.Save_32;
            btSavePerson.ImageAlign = ContentAlignment.MiddleLeft;
            btSavePerson.Location = new Point(374, 244);
            btSavePerson.Margin = new Padding(4, 3, 4, 3);
            btSavePerson.Name = "btSavePerson";
            btSavePerson.Size = new Size(117, 32);
            btSavePerson.TabIndex = 31;
            btSavePerson.Text = "Save";
            btSavePerson.UseVisualStyleBackColor = true;
            btSavePerson.Click += btSavePerson_Click;
            // 
            // labRemoveImage
            // 
            labRemoveImage.AutoSize = true;
            labRemoveImage.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labRemoveImage.ForeColor = Color.Blue;
            labRemoveImage.Location = new Point(573, 203);
            labRemoveImage.Name = "labRemoveImage";
            labRemoveImage.Size = new Size(81, 13);
            labRemoveImage.TabIndex = 32;
            labRemoveImage.Text = "Remove Image";
            labRemoveImage.Click += labRemoveImage_Click;
            // 
            // ucAddUpdatePerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(labRemoveImage);
            Controls.Add(btSavePerson);
            Controls.Add(btClose);
            Controls.Add(rdMale);
            Controls.Add(btAddImage);
            Controls.Add(rdFmale);
            Controls.Add(dtDateOfBirth);
            Controls.Add(bxCuntry);
            Controls.Add(pictureBox1);
            Controls.Add(txtSecondName);
            Controls.Add(txtPhone);
            Controls.Add(txtLastName);
            Controls.Add(TxtThirdName);
            Controls.Add(txtAddress);
            Controls.Add(txtEmail);
            Controls.Add(txtNationalNo);
            Controls.Add(txtFirstName);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucAddUpdatePerson";
            Size = new Size(682, 298);
            Load += ucAddPeople_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox TxtThirdName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtSecondName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox bxCuntry;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.RadioButton rdFmale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.Button btAddImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btSavePerson;
        private System.Windows.Forms.Button btClose;
        private Label labRemoveImage;
    }
}
