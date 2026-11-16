using DVLD_Desktop_Net8.People.Services;
using DVLDShared.DTOs.People;
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
    public partial class fmPeopleList : Form
    {
        //member variables
        private readonly PeopleService _peopleService = new PeopleService();
        private List<PersonListDTO>? _personListDTO;



        //constructors
        public fmPeopleList()
        {
            InitializeComponent();
        }




        //methods
        private void _FillRecordsCount()
        {
            labRecordsCount.Text = $"Total Records: {dgvPeople.Rows.Count.ToString()}";
        }
        private async void LoadDataOfPeople()
        {
            _personListDTO = await _peopleService.GetAllPeople();
            dgvPeople.DataSource = _personListDTO;

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;

            _FillRecordsCount();
        }

        private int? _GetSelectedPersonID()
        {
            if (dgvPeople.CurrentRow == null || dgvPeople.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a person from the list first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var cellValue = dgvPeople.CurrentRow.Cells["PersonID"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int personId))
            {
                return personId;
            }

            MessageBox.Show("Could not read Person ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }


        //handlers
        private void fmPeople_Load(object sender, EventArgs e)
        {
            dgvPeople.ContextMenuStrip = contextMenuStrip1;
            LoadDataOfPeople();
        }

        private void btAddNewPerson_Click(object sender, EventArgs e)
        {
            fmAddNewPerson fmAdd_People = new fmAddNewPerson();
            fmAdd_People.ShowDialog();

            LoadDataOfPeople();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeople.ClearSelection();//حذف الخيارات السابقه
                dgvPeople.Rows[e.RowIndex].Selected = true;//تحديد السطر
                dgvPeople.CurrentCell = dgvPeople.Rows[e.RowIndex].Cells[0];//تحديد الخلية
            }
        }

        private void AddNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddNewPerson fmAdd_ = new fmAddNewPerson();
            fmAdd_.ShowDialog();
            LoadDataOfPeople();
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? personID = _GetSelectedPersonID();
            if (personID == null) return;

            fmUpdatePerson fmUpdatePerson = new fmUpdatePerson(personID.Value);
            fmUpdatePerson.ShowDialog();

            LoadDataOfPeople();
        }

        private void ShowDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int? personID = _GetSelectedPersonID();
            if (personID == null) return;

            fmShowDetails fmShowDetails = new fmShowDetails(personID.Value);
            fmShowDetails.ShowDialog();
            LoadDataOfPeople();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void deletePersonToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int? personID = _GetSelectedPersonID();
            if (personID == null) return;

            if (MessageBox.Show($"Are you sure you want to delete Person [{personID.Value}]?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (await _peopleService.DeletePerson(personID.Value))
                {
                    MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataOfPeople();
                }
                else
                {
                    MessageBox.Show("Failed to delete person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? personID = _GetSelectedPersonID();
            if (personID == null) return;

            MessageBox.Show("Send Email functionality is not implemented yet.");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? personID = _GetSelectedPersonID();
            if (personID == null) return;
            MessageBox.Show("Phone Call functionality is not implemented yet.");
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
            }

            // إلغاء الفلتر فوراً عند اختيار None
            if (cbFilterBy.Text == "None" && _personListDTO != null)
            {
                LoadDataOfPeople();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Phone")
            {
                // السماح بالأرقام فقط (IsDigit) وزر المسح Backspace (IsControl)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // منع إدخال الحروف والرموز
                }
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_personListDTO == null || !_personListDTO.Any()) return;

            string selectedFilter = cbFilterBy.Text;
            string filterValue = txtFilterValue.Text.Trim().ToLower();

            // إذا كانت خانة البحث فارغة أو الخيار None، اعرض القائمة كاملة
            if (string.IsNullOrEmpty(filterValue) || selectedFilter == "None")
            {
                dgvPeople.DataSource = _personListDTO;
                _FillRecordsCount();
                return;
            }

            // تطبيق الفلترة باستخدام LINQ حسب الخيار المختار
            IEnumerable<PersonListDTO> filteredResult = selectedFilter switch
            {
                "Person ID" => _personListDTO.Where(p => p.PersonID.ToString().StartsWith(filterValue)),

                "National No." => _personListDTO.Where(p => !string.IsNullOrEmpty(p.NationalNo) &&
                                                           p.NationalNo.ToLower().StartsWith(filterValue)),

                "First Name" => _personListDTO.Where(p => !string.IsNullOrEmpty(p.FirstName) &&
                                                         p.FirstName.ToLower().StartsWith(filterValue)),

                "Second Name" => _personListDTO.Where(p => !string.IsNullOrEmpty(p.SecondName) &&
                                                          p.SecondName.ToLower().StartsWith(filterValue)),

                "Third Name" => _personListDTO.Where(p => !string.IsNullOrEmpty(p.ThirdName) &&
                                                         p.ThirdName.ToLower().StartsWith(filterValue)),

                "Last Name" => _personListDTO.Where(p => !string.IsNullOrEmpty(p.LastName) &&
                                                        p.LastName.ToLower().StartsWith(filterValue)),

                "Gendor" => _personListDTO.Where(p => (p.Gendor == 0 ? "male" : "female").StartsWith(filterValue) ||
                                                        p.Gendor.ToString() == filterValue),


                "Nationality" => _personListDTO.Where(p => !string.IsNullOrEmpty(p.Nationality) &&
                                                          p.Nationality.ToLower().StartsWith(filterValue)),

                "Phone" => _personListDTO.Where(p => !string.IsNullOrEmpty(p.Phone) &&
                                                      p.Phone.StartsWith(filterValue)),

                "Email" => _personListDTO.Where(p => !string.IsNullOrEmpty(p.Email) &&
                                                      p.Email.ToLower().StartsWith(filterValue)),

                _ => _personListDTO
            };

            // إسناد القائمة المفلترة للـ DataGridView
            dgvPeople.DataSource = filteredResult.ToList();

            // تحديث عداد السجلات الظاهرة
            _FillRecordsCount();
        }

        private void dgvPeople_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPeople.Columns[e.ColumnIndex].Name == "Gendor" && e.Value != null)
            {
                byte genderValue = Convert.ToByte(e.Value);

                // 0 = Male (ذكر) , 1 = Female (أنثى)
                if (genderValue == 0)
                {
                    e.Value = "Male"; // أو "ذكر"
                }
                else
                {
                    e.Value = "Female"; // أو "أنثى"
                }

                // إعلام الـ DataGridView بأنه تم تطبيق التنسيق بنجاح
                e.FormattingApplied = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvPeople.CurrentRow == null || dgvPeople.CurrentRow.Index < 0)
            {
                e.Cancel = true;
            }
        }

        //Empty event handlers
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void phoneCallToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFilterBy_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}


