using DVLD_Desktop_Net8.User_Control;
using System;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8
{
    public partial class fmShowDetails : Form
    {
        //members variables
        private int _PersonID ;





        //constructors
        public fmShowDetails()
        {
            InitializeComponent();
        }

        public fmShowDetails(int PersonID) : this()
        {
            _PersonID = PersonID;
        }






        //handlers
        private async void fmShowDetails_Load(object sender, EventArgs e)
        {
            if (_PersonID > 0)
            {
                await ucShowDetails1.LoadPersonDataByPersonID(_PersonID);
            }
            else
            {
                MessageBox.Show("You have provided an invalid Person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        //Empty event handlers for the controls in the form
        private void ucShowDetails1_Load(object sender, EventArgs e)
        {

        }

        private void ucShowDetails1_Load_1(object sender, EventArgs e)
        {

        }
    }
}