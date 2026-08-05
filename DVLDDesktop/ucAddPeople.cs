using DVLD__Bussnis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_MainProject
{
    public partial class ucAddPeople : UserControl
    {
        private int _PersonID = -1;
        public event EventHandler OnClose;
        public ucAddPeople()
        {
            InitializeComponent();
        }

        public ucAddPeople(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            LoadData();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void ucAddPeople_Load(object sender, EventArgs e)
        {
           
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string imagesFolder = @"C:\Users\Abdalmajeed\Desktop\مشروعي\DVLD_Images";


                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }


                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(ofd.FileName);


                string finalPath = Path.Combine(imagesFolder, imageName);


                File.Copy(ofd.FileName, finalPath, true);


                pictureBox1.ImageLocation = finalPath;
            }

        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }


        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "you can not leave it empty");
                e.Cancel = true;
                return;
            }

            clsPeople clsPeople = new clsPeople();
            clsPeople.NationalNo = txtNationalNo.Text;
            if (clsPeople.FiendByNationalNoPeople())
            {
                errorProvider1.SetError(txtNationalNo, "choose a new one");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "");

            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFmale.Checked)
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\Abdalmajeed\Desktop\مشروعي\Women.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMale.Checked)
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\Abdalmajeed\Desktop\مشروعي\Man.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Rong");
            }
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text, pattern))
            {
                errorProvider1.SetError(txtEmail, "صيغة الإيميل غير صحيحة");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsPeople clsPeople = new clsPeople();
            clsPeople.FirstName = txtFirstName.Text;
            clsPeople.SecondName = txtSecondName.Text;
            clsPeople.ThirdName = TxtThirdName.Text;
            clsPeople.LastName = txtLastName.Text;
            clsPeople.NationalNo = txtNationalNo.Text;
            clsPeople.DateOfBirth = dtDateOfBirth.Value;
            clsPeople.Gendor = CheckSix();
            clsPeople.Phone = txtPhone.Text;
            clsPeople.Email = txtEmail.Text;
            clsPeople.NationalityCountryID = Convert.ToInt32(bxCuntry.SelectedValue);
            clsPeople.Address = txtAddress.Text;
            clsPeople.ImagePath = pictureBox1.ImageLocation;

            if (clsPeople.save())
            {
                MessageBox.Show("Saving is Done", "Save");
                lbPersonID.Text = clsPeople.PersonID.ToString();
            }
            else
            {
                MessageBox.Show("Saving is Faeld", "Save");
            }

            
        }

        private int CheckSix()
        {
            if (rdMale.Checked)
            {
                return 0;
            }
            else if (rdFmale.Checked)
            {
                return 1;
            }
            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke(this, EventArgs.Empty);

        }

        private void LoadData()
        {
            DataTable dt = clsPeople.GetAllCountries();
            bxCuntry.DataSource = dt;
            bxCuntry.DisplayMember = "CountryName";
            bxCuntry.ValueMember = "CountryID";

            clsPeople person = new clsPeople();
            person.PersonID = _PersonID;

            if (person.PersonID == -1) 
            {
                label13.Text = "Add new person";
                bxCuntry.SelectedIndex = 190;
                dtDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
                dtDateOfBirth.Value = DateTime.Today.AddYears(-18);
                return;
            }

            person.FiendByID();
            label13.Text = "Update person data";
            txtFirstName.Text = person.FirstName;
            txtSecondName.Text = person.SecondName;
            TxtThirdName.Text = person.ThirdName;
            txtLastName.Text = person.LastName;
            txtNationalNo.Text = person.NationalNo;
            dtDateOfBirth.Value = person.DateOfBirth;

            txtPhone.Text = person.Phone;
            txtEmail.Text = person.Email;
            txtAddress.Text = person.Address;
            bxCuntry.SelectedValue = person.NationalityCountryID;
            if (person.Gendor == 0)
                rdMale.Checked = true;
            else
                rdFmale.Checked = true;

            pictureBox1.ImageLocation = person.ImagePath;
            lbPersonID.Text = person.PersonID.ToString();
        }

        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

