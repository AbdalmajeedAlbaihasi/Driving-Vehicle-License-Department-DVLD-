using DVLD_Desktop_Net8.User.Services;
using DVLDShared.DTOs.Users;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;

namespace DVLD_Desktop_Net8.User
{
    public partial class fmUsersList : Form
    {
        //members
        private readonly UserService _userService = new UserService();
        private List<UsersListDTO>? _usersListDTO;
        public enum enMode { AddNew = 0, Update = 1 }




        //constructor
        public fmUsersList()
        {
            InitializeComponent();
        }




        //methods
        private void _FillRecordsCount()
        {
            labRecordsCount.Text = $"Total Records: {dgvUsers.Rows.Count.ToString()}";
        }

        private async void LoadDataOfUsers()
        {
            _usersListDTO = await _userService.GetAllUsers();
            dgvUsers.DataSource = _usersListDTO;
            dgvUsers.Columns[2].Width = 250;


            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;

            _FillRecordsCount();
        }


        private int? _GetSelectedUserID()
        {
            // 1. التأكد من تحديد سطر حالي في DataGridView
            if (dgvUsers.CurrentRow == null || dgvUsers.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a user from the list first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // 2. قراءة UserID بأمان
            var cellValue = dgvUsers.CurrentRow.Cells["UserID"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int userId))
            {
                return userId;
            }

            MessageBox.Show("Could not read User ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private int? _GetSelectedPersonID()
        {
            if (dgvUsers.CurrentRow == null || dgvUsers.CurrentRow.Index < 0) return null;

            var cellValue = dgvUsers.CurrentRow.Cells["PersonID"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int personId))
            {
                return personId;
            }

            return null;
        }




        //event handeler
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvUsers.ClearSelection();//حذف الخيارات السابقه
                dgvUsers.Rows[e.RowIndex].Selected = true;//تحديد السطر
                dgvUsers.CurrentCell = dgvUsers.Rows[e.RowIndex].Cells[0];//تحديد الخلية
            }
        }

        private void fmUsersList_Load(object sender, EventArgs e)
        {
            LoadDataOfUsers();
        }

        private void btAddNewUser_Click(object sender, EventArgs e)
        {
            fmAddUpdateUser fmAdd_User = new fmAddUpdateUser();
            fmAdd_User.ShowDialog();
            LoadDataOfUsers();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_usersListDTO == null || !_usersListDTO.Any()) return;

            string selectedFilter = cbFilterBy.Text;
            string filterValue = txtFilterValue.Text.Trim().ToLower();

            // إذا كانت خانة البحث فارغة أو الخيار None، اعرض القائمة كاملة
            if (string.IsNullOrEmpty(filterValue) || selectedFilter == "None")
            {
                dgvUsers.DataSource = _usersListDTO;
                _FillRecordsCount();
                return;
            }

            // تطبيق الفلترة باستخدام LINQ حسب الخيار المختار
            IEnumerable<UsersListDTO> filteredResult = selectedFilter switch
            {
                "User ID" => _usersListDTO.Where(p => p.UserID.ToString().StartsWith(filterValue)),

                "UserName" => _usersListDTO.Where(p => !string.IsNullOrEmpty(p.UserName) &&
                                                           p.UserName.ToLower().StartsWith(filterValue)),

                "Person ID" => _usersListDTO.Where(p => !string.IsNullOrEmpty(p.PersonID.ToString()) &&
                                                         p.PersonID.ToString().StartsWith(filterValue)),

                "Full Name" => _usersListDTO.Where(p => !string.IsNullOrEmpty(p.FullName) &&
                                                          p.FullName.ToLower().StartsWith(filterValue)),


                _ => _usersListDTO
            };

            // إسناد القائمة المفلترة للـ DataGridView
            dgvUsers.DataSource = filteredResult.ToList();
            // تحديث عداد السجلات الظاهرة
            _FillRecordsCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
            {
                // السماح بالأرقام فقط (IsDigit) وزر المسح Backspace (IsControl)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // منع إدخال الحروف والرموز
                }
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";

            // إعادة عرض البيانات كاملة عند تغيير خيار الفلترة
            dgvUsers.DataSource = _usersListDTO;
            _FillRecordsCount();

            // التحكم في ظهور عناصر الفلترة بناءً على الخيار
            switch (cbFilterBy.Text)
            {
                case "None":
                    txtFilterValue.Visible = false;
                    cbIsActive.Visible = false;
                    break;

                case "Is Active":
                    txtFilterValue.Visible = false;
                    cbIsActive.Visible = true;
                    cbIsActive.SelectedIndex = 0; // "All"
                    cbIsActive.DropDownStyle = ComboBoxStyle.DropDownList;
                    break;

                default:
                    cbIsActive.Visible = false;
                    txtFilterValue.Visible = true;
                    txtFilterValue.Focus();
                    break;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_usersListDTO == null || !_usersListDTO.Any()) return;

            string selectedValue = cbIsActive.Text;

            // إذا كان الخيار All (الكل)، اعرض القائمة كاملة
            if (selectedValue == "All")
            {
                dgvUsers.DataSource = _usersListDTO;
                _FillRecordsCount();
                return;
            }

            // تحديد القيمة البولينية المطلوب الفلترة بناءً عليها (Yes -> true, No -> false)
            bool isActive = (selectedValue == "Yes");

            // فلترة القائمة بناءً على قيمة IsActive
            var filteredResult = _usersListDTO.Where(p => p.IsActive == isActive);

            dgvUsers.DataSource = filteredResult.ToList();
            _FillRecordsCount();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? userId = _GetSelectedUserID();
            if (userId == null) return;

            MessageBox.Show("Send Email functionality is not implemented yet.");
        }

        private async void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? userId = _GetSelectedUserID();
            if (userId == null) return;

            if (MessageBox.Show($"Are you sure you want to delete User [{userId.Value}]?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (await _userService.DeleteUser(userId.Value))
                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataOfUsers();
                }
                else
                {
                    MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? userId = _GetSelectedUserID();
            int? personId = _GetSelectedPersonID();

            if (userId == null || personId == null) return;

            fmAddUpdateUser fmUpdateUser = new fmAddUpdateUser(userId.Value, personId.Value);
            fmUpdateUser.ShowDialog();
            LoadDataOfUsers();
        }

        private void AddNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fmAddUpdateUser fmAddNewUser = new fmAddUpdateUser();
            fmAddNewUser.ShowDialog();
            LoadDataOfUsers();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? userId = _GetSelectedUserID();
            if (userId == null) return;
            MessageBox.Show("Phone Call functionality is not implemented yet.");
        }

        private void ChangePasswordPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? userId = _GetSelectedUserID();
            if (userId == null) return;

            fmChangePassword fmChangePassword = new fmChangePassword(userId.Value);
            fmChangePassword.ShowDialog();
            LoadDataOfUsers();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? userId = _GetSelectedUserID();
            if (userId == null) return;


            fmShowUserDetails fmShowUserDetails = new fmShowUserDetails(userId.Value);
            fmShowUserDetails.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvUsers.CurrentRow == null || dgvUsers.CurrentRow.Index < 0)
            {
                e.Cancel = true;
            }
        }




        //empty

        private void dgvUsers_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void labRecordsCount_Click(object sender, EventArgs e)
        {

        }
    }
}
