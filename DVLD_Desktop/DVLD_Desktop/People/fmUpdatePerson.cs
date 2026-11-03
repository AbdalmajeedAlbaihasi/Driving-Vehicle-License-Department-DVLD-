using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8
{
    public partial class fmUpdatePerson : Form
    {
        //members variables
        private readonly int _personID;



        //constructor
        public fmUpdatePerson(int personID)
        {
            _personID = personID;
            InitializeComponent();
        }
        public fmUpdatePerson()
        {
            InitializeComponent();
        }



        //event handler for the ucAddNewPerson1's OnClose event
        private void ucAddNewPerson1_OnClose(object? sender, EventArgs e)
        {
            this.Close();
        }
        private void fmUpdatePerson_Load(object sender, EventArgs e)
        {
            labelPersonID.Text = _personID.ToString();

            ucAddUpdatePerson.LoadPersonData(_personID);

            ucAddUpdatePerson.OnucAddUpdatePersonClose += ucAddNewPerson1_OnClose;
        }



        //empty event handler for the form's FormClosed event
        private void ucAddNewPerson1_Load(object sender, EventArgs e)
        {

        }

        private void ucAddUpdatePerson_Load(object sender, EventArgs e)
        {

        }
    }
}
