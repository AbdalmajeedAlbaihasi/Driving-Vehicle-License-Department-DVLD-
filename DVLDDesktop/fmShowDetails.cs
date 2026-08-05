using DVLD__Bussnis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_MainProject
{
    public partial class fmShowDetails : Form
    {
        private int _PersonID;


        private void fmShowDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public fmShowDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void LoadData()
        {
            clsPeople clsPeople = new clsPeople();
            clsPeople.PersonID = _PersonID;
            clsPeople.FiendByID();
            laPersonID.Text = clsPeople.PersonID.ToString();
            laName.Text = clsPeople.FirstName + " " + clsPeople.SecondName + " " + clsPeople.ThirdName + " " + clsPeople.LastName;
            laNationalNO.Text = clsPeople.NationalNo;
            if (clsPeople.Gendor == 0)
            {
                laGendor.Text = "Male";
            }
            else
            {
                laGendor.Text = "Fmale";
            }
            laEmail.Text = clsPeople.Email;
            laAddress.Text = clsPeople.Address;
            laDateOfBirth.Text = clsPeople.DateOfBirth.ToString();
            laPhone.Text = clsPeople.Phone;
            laCountry.Text = clsPeople.CountryName;
            pictureBox1.ImageLocation = clsPeople.ImagePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
