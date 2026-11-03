using DVLD_Desktop_Net8.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.People.Control
{
    public partial class ucPersonCardWithFilter : UserControl
    {
        //members
        public int _personID ;



        //constructors
        public ucPersonCardWithFilter()
        {
            InitializeComponent();
        }




        //methods
        public async void SetPersonID(int personID)
        {
            _personID = personID;

            if (_personID > 0)
            {
                await ucShowDetails2.LoadPersonDataByPersonID(_personID);
                groupBoxFilter.Enabled = false; // Disable the filter group box when a specific person is set
            }

        }


        //event handlers
        private void btAddNewPerson_Click(object sender, EventArgs e)
        {
            fmAddNewPerson fmAdd_People = new fmAddNewPerson();
            fmAdd_People.ShowDialog();
        }

        private async void btFindPerson_Click(object sender, EventArgs e)
        {
            string filterValue = txtFilterValue.Text.ToString();
            if (cbFilterBy.SelectedIndex == 0)
            {
                await ucShowDetails2.LoadPersonDataByNationalNo(filterValue);
                _personID = ucShowDetails2._PersonID;
            }
            else if (cbFilterBy.SelectedIndex == 1)
            {
                if (int.TryParse(filterValue, out int personID))
                {
                    await ucShowDetails2.LoadPersonDataByPersonID(personID);
                    _personID = ucShowDetails2._PersonID;
                }
                else
                {
                    MessageBox.Show("Please enter a valid Person ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private async void ucPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            if (_personID > 0)
            {
                await ucShowDetails2.LoadPersonDataByPersonID(_personID);
            }
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
            {
                // السماح بالأرقام فقط (IsDigit) وزر المسح Backspace (IsControl)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // منع إدخال الحروف والرموز
                }
            }
        }




        //empty event handlers
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucShowDetails2_Load(object sender, EventArgs e)
        {

        }

        private void ucShowDetails1_Load(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
