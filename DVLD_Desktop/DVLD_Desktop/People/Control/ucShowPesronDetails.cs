using DVLD_Desktop_Net8.People.Services;
using DVLD_Desktop_Net8.Properties;
using DVLDShared.DTOs.People;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.User_Control
{
    public partial class ucShowPesronDetails : UserControl
    {
        //member variables
        private readonly PeopleService _peopleService;
        private OnePeopleDTO? _onePeopleDTO;
        public int _PersonID;
        private string? _NationalNo;




        //constructors
        public ucShowPesronDetails()
        {
            InitializeComponent();

            _peopleService = new PeopleService();
        }

        



        //methods
        private void _fillPersonDetails(OnePeopleDTO personDetails)
        {
            _PersonID = personDetails.PersonID;


            labPersonID.Text = personDetails.PersonID.ToString();
            labName.Text = $"{personDetails.FirstName} {personDetails.SecondName} {personDetails.ThirdName} {personDetails.LastName}".Trim();
            labNationalNO.Text = personDetails.NationalNo;
            labGendor.Text = personDetails.Gendor == 0 ? "Male" : "Female";
            labEmail.Text = string.IsNullOrEmpty(personDetails.Email) ? "N/A" : personDetails.Email;
            labAddress.Text = personDetails.Address;
            labDateOfBirth.Text = personDetails.DateOfBirth.ToString("yyyy-MM-dd");
            labPhone.Text = personDetails.Phone;
            labCountry.Text = personDetails.CountryName;

            if (!string.IsNullOrEmpty(personDetails.ImagePath) && File.Exists(personDetails.ImagePath))
            {
                pictureBox1.ImageLocation = personDetails.ImagePath;
            }
        }

        private void _resetPersonDetails()
        {
            _PersonID = -1;
            labPersonID.Text = "[????]";
            labName.Text = "[????]";
            labNationalNO.Text = "[????]";
            labGendor.Text = "[????]";
            labEmail.Text = "[????]";
            labAddress.Text = "[????]";
            labDateOfBirth.Text = "[????]";
            labPhone.Text = "[????]";
            labCountry.Text = "[????]";
            pictureBox1.Image = Resources.Male_512;
        }

        public async Task LoadPersonDataByPersonID(int personID)
        {
            _onePeopleDTO = await _peopleService.GetPersonByPersonId(personID);

            if (_onePeopleDTO == null)
            {
                _resetPersonDetails();
                MessageBox.Show($"Person with ID [{personID}] not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _fillPersonDetails(_onePeopleDTO);


        }

        public async Task LoadPersonDataByUserID(int userID)
        {
            _onePeopleDTO = await _peopleService.GetPersonByUserId(userID);

            if (_onePeopleDTO == null)
            {
                _resetPersonDetails();
                MessageBox.Show($"Person with ID [{userID}] not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _fillPersonDetails(_onePeopleDTO);


        }
        public async Task LoadPersonDataByNationalNo(string nationalNo)
        {
            _onePeopleDTO = await _peopleService.GetPersonByNationalNo(nationalNo);

            if (_onePeopleDTO == null)
            {
                _resetPersonDetails();
                MessageBox.Show($"Person with National No [{nationalNo}] not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _fillPersonDetails(_onePeopleDTO);


        }



        //event handlers
        private async void labEditpersoninfo_Click(object sender, EventArgs e)
        {

            fmUpdatePerson fmUpdate_People = new fmUpdatePerson(_PersonID);
            fmUpdate_People.ShowDialog();

            await LoadPersonDataByPersonID(_PersonID);
        }



        //empty event handler for the Load event of the user control
        private void ucShowDetails_Load(object sender, EventArgs e)
        {
           // _PersonID = (int)labPersonID;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}