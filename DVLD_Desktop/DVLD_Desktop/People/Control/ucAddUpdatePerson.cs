using DVLD_Desktop_Net8.People.Services;
using DVLD_Desktop_Net8.Properties;
using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs.People;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Desktop_Net8
{       
    public partial class ucAddUpdatePerson : UserControl
    {
        //member variables
        public event EventHandler? OnucAddUpdatePersonClose;
        public event EventHandler<int>? OnPersonSaved;
        private readonly PeopleService _peopleService;
        private readonly CountriesService _countriesService;
        private int _personID = -1;


        //constructors
        public ucAddUpdatePerson()
        {
            InitializeComponent();
            _peopleService = new PeopleService();
            _countriesService = new CountriesService();
        }




        //methods
        private UpdatePeopleDTO LoadPersonDataForUpdate(int personID)
        {
            byte gendor = CheckGander();
            int nationalityCountryID = Convert.ToInt32(bxCuntry.SelectedValue);
            string imagePath = pictureBox1.ImageLocation ?? string.Empty;


            UpdatePeopleDTO updatePersonDTO = new UpdatePeopleDTO(_personID,
                    txtNationalNo.Text, txtFirstName.Text, txtSecondName.Text, TxtThirdName.Text,
                    txtLastName.Text, dtDateOfBirth.Value, gendor, txtAddress.Text, txtPhone.Text,
                    txtEmail.Text, nationalityCountryID, imagePath
                    );
            return updatePersonDTO;
        }

        private async Task LoadCountriesAsync()
        {
            var countries = await _countriesService.GetAllCountries();

            if (countries != null && countries.Any())
            {

                bxCuntry.DisplayMember = "NationalityName";
                bxCuntry.ValueMember = "NationalityID";

                bxCuntry.DataSource = countries;

                bxCuntry.SelectedIndex = 190;
            }
            else
            {
                MessageBox.Show("The system could not find any countries.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private byte CheckGander()
        {
            if (rdMale.Checked)
            {
                return 0;
            }
            else if (rdFmale.Checked)
            {
                return 1;
            }
            return 255;
        }

        public async void LoadPersonData(int personID)
        {
            _personID = personID;
            var person = await _peopleService.GetPersonByPersonId(personID);


            if (person != null)
            {
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

            }
            else
            {
                MessageBox.Show("The system could not find the person with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OnucAddUpdatePersonClose?.Invoke(this, EventArgs.Empty);
            }
        }

        private async void _savePersonData()
        {
            byte gendor = CheckGander();
            int nationalityCountryID = Convert.ToInt32(bxCuntry.SelectedValue);
            string imagePath = pictureBox1.ImageLocation ?? string.Empty;
            AddNewPeopleDTO addNewPeopleDTO = new AddNewPeopleDTO(
                txtNationalNo.Text, txtFirstName.Text, txtSecondName.Text, TxtThirdName.Text,
                txtLastName.Text, dtDateOfBirth.Value, gendor, txtAddress.Text, txtPhone.Text,
                txtEmail.Text, nationalityCountryID, imagePath
                );


            var response = await _peopleService.AddPerson(addNewPeopleDTO);
            if (response?.Success == true)
            {
                MessageBox.Show("Saving is Done", "Save");
                _personID = response.ID;
                OnPersonSaved?.Invoke(this, _personID);
            }
            else
            {
                MessageBox.Show($"Saving is Failed: {response?.Message}", "Save");
            }
        }


        private async void _UpdatePersonData()
        {
            bool response = await _peopleService.UpdatePerson(_personID, LoadPersonDataForUpdate(_personID));
            if (response == true)
            {
                MessageBox.Show("Updating is Done", "Update");
                OnPersonSaved?.Invoke(this, _personID);
            }
            else
            {
                MessageBox.Show("Updating is Failed", "Update");
            }
        }






        //event handlers
        private async void ucAddPeople_Load(object sender, EventArgs e)
        {
            dtDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            bxCuntry.DropDownStyle = ComboBoxStyle.DropDownList;
            await LoadCountriesAsync();

            rdMale.Checked = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void btAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string imagesFolder = @"C:\Users\2tita\Desktop\My_Projects\Abalmajeed_DVLD\Images";

                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }


                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(ofd.FileName);


                string finalPath = Path.Combine(imagesFolder, imageName);

                File.Copy(ofd.FileName, finalPath, true);


                pictureBox1.ImageLocation = finalPath;

                labRemoveImage.Visible = true;
            }

        }

        private async void txtNationalNo_Validating(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "National number cannot be empty.");
                return;
            }

            bool exists = await _peopleService.CheckNationalNoExists(txtNationalNo.Text.Trim());

            if (exists)
            {
                errorProvider1.SetError(txtNationalNo, "This National Number already exists.");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, string.Empty);
            }

        }

        private void rdFmale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFmale.Checked)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(@"\Users\2tita\Desktop\My_Projects\Abalmajeed_DVLD\DVLD_Desktop\DVLD_Desktop\Resources\Female_512.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMale.Checked)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(@"\Users\2tita\Desktop\My_Projects\Abalmajeed_DVLD\DVLD_Desktop\DVLD_Desktop\Resources\Male 512.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Rong");
            }
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text, pattern))
            {
                errorProvider1.SetError(txtEmail, "Invalid email format.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void btSavePerson_Click(object sender, EventArgs e)
        {
            if (_personID == -1)
            {
                _savePersonData();
            }
            else
            {
                _UpdatePersonData();
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            OnucAddUpdatePersonClose?.Invoke(this, EventArgs.Empty);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void labRemoveImage_Click(object sender, EventArgs e)
        {
            // Check if there is a custom image path set
            if (!string.IsNullOrEmpty(pictureBox1.ImageLocation) && File.Exists(pictureBox1.ImageLocation))
            {
                string imagePathToDelete = pictureBox1.ImageLocation;

                // 1. Clear picture box and release file lock
                pictureBox1.ImageLocation = null;
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                // 2. Restore default profile image based on gender
                if (rdMale.Checked)
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(@"C:\Users\2tita\Desktop\My_Projects\Abalmajeed_DVLD\DVLD_Desktop\DVLD_Desktop\Resources\Male 512.png");
                }
            
                else if (rdFmale.Checked)
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(@"C:\Users\2tita\Desktop\My_Projects\Abalmajeed_DVLD\DVLD_Desktop\DVLD_Desktop\Resources\Female_512.png");
                }
            

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                // 3. Delete file from directory
                try
                {
                    File.Delete(imagePathToDelete);
                    rdFmale_CheckedChanged(this, EventArgs.Empty);
                    rdMale_CheckedChanged(this, EventArgs.Empty);
                    labRemoveImage.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the image file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No custom image to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }







        //Empty event handlers for various controls
        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtDateOfBirth_Validating(object sender, CancelEventArgs e)
        {

        }

        private void bxCuntry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

