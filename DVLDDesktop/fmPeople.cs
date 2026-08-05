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
    public partial class fmPeople : Form
    {
        public fmPeople()
        {
            InitializeComponent();
            dgvPeople.ContextMenuStrip = contextMenuStrip1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        DataTable dt;

        private void fmPeople_Load(object sender, EventArgs e)
        {
            dt = clsPeople.GetAllPeople();
            dgvPeople.DataSource = dt;

            cbSearchBy.SelectedIndex = 0;

  
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbSearchBy.SelectedItem == null)
                return;

            if (cbSearchBy.SelectedItem.ToString() == "ID")
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    dt.DefaultView.RowFilter = "";
                    return;
                }

                if (int.TryParse(txtSearch.Text, out int id))
                {
                    dt.DefaultView.RowFilter = $"PersonID = {id}";
                }
                else
                {
                    dt.DefaultView.RowFilter = "";
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            fmAdd_Update_People fmAdd_People = new fmAdd_Update_People();
            fmAdd_People.ShowDialog();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeople.ClearSelection();//حذف الخيارات السابقه
                dgvPeople.Rows[e.RowIndex].Selected = true;//تحديد السطر
                dgvPeople.CurrentCell = dgvPeople.Rows[e.RowIndex].Cells[0];//تحديد الخلية
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32( dgvPeople.SelectedRows[0].Cells["PersonID"].Value);
            clsPeople clsPeople = new clsPeople();
            clsPeople.PersonID = personID;
            if (clsPeople.DeletePeople())
            {
                MessageBox.Show("Delete is success");
                LoadDataOfPeople();
            }
            else
            {
                MessageBox.Show("Delete is failed");

            }
        }

        private void ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fmAdd_Update_People fmAdd_People_1 = new fmAdd_Update_People();
            fmAdd_People_1.ShowDialog();
        }
        private void LoadDataOfPeople()
        {
            dgvPeople.DataSource = clsPeople.GetAllPeople();
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
                return;

            int personID = Convert.ToInt32( dgvPeople.SelectedRows[0].Cells["PersonID"].Value );

            fmAdd_Update_People frm = new fmAdd_Update_People(personID);
            frm.ShowDialog(); // فتح الفورم الثاني
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells["PersonID"].Value);
            fmShowDetails fmShowDetails = new fmShowDetails(personID);
            fmShowDetails.ShowDialog();
        }
    }
}


