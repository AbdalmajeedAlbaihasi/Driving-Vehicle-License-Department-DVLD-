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
    public partial class fmAddNewPerson : Form
    {
        //constructors
        public fmAddNewPerson()
        {
            InitializeComponent();
        }






        //handlers 
        private void ucAddNewPerson_OnPersonSaved(object? sender, int personID)
        {
            labelPersonID.Text = personID.ToString();
        }

        private void ucAddNewPerson_OnClose(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void fmAddNewPerson_Load(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();

            ucAddUpdatePerson uc = new ucAddUpdatePerson();
            uc.OnPersonSaved += ucAddNewPerson_OnPersonSaved;
            uc.OnucAddUpdatePersonClose += ucAddNewPerson_OnClose;
            uc.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(uc);
        }




        //Empty event handlers for the controls in the form
        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ucAddNewPerson_Load(object sender, EventArgs e)
        {

        }

        private void ucAddNewPerson_Load_1(object sender, EventArgs e)
        {

        }

        private void ucAddUpdatePerson_Load(object sender, EventArgs e)
        {

        }

        private void fmAddNewPerson_Load_1(object sender, EventArgs e)
        {

        }
    }
}
