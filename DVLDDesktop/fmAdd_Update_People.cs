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
    public partial class fmAdd_Update_People : Form
    {
        private int _personID = -1;
        public fmAdd_Update_People()
        {
            InitializeComponent();
            
        }

        public fmAdd_Update_People(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        private void ucAddPeople1_Load(object sender, EventArgs e)
        {
            
        }

        private void ucAddPeople1_OnClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmAdd_People_Load(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();

            ucAddPeople uc = new ucAddPeople(_personID);
            uc.OnClose += ucAddPeople1_OnClose;

            uc.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(uc);
        }

    }
}
