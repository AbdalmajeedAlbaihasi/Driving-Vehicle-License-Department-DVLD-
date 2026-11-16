using DVLD_Desktop_Net8.People.Control;
using DVLD_Desktop_Net8.User.Services;
using DVLDShared.DTOs.Users;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Desktop_Net8.User.fmUsersList;

namespace DVLD_Desktop_Net8.User
{
    public partial class fmAddUpdateUser : Form
    {
        //members
        private readonly UserService? _userService = new UserService();
        private int _UserID;
        private int _PersonID;
        private enMode _mode;



        //constructors
        public fmAddUpdateUser()
        {
            InitializeComponent();
            _mode = enMode.AddNew;
        }

        public fmAddUpdateUser(int userID, int personID)
        {
            InitializeComponent();
            _UserID = userID;
            _PersonID = personID;
            _mode = enMode.Update;
        }
        


        //methods
        private async void loadUserDataByUserID(int userID)
        {
            var user = await _userService.GetUserById(userID);
            if (user != null)
            {
                lbUserID.Text = user.UserID.ToString();
                txtUserName.Text = user.UserName;
                chkBoxIsActive.Checked = user.IsActive;
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
                return;
            }

            // فحص التطابق مع كلمة السر الأولى
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password does not match!");
            }
            else
            {
                // إزالة علامة الخطأ عند التطابق
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            if (_mode == enMode.AddNew)
            {
                _PersonID = ucPersonCardWithFilter1._personID;
                AddNewUserDTO newUser = new AddNewUserDTO(_PersonID, txtUserName.Text, txtPassword.Text, chkBoxIsActive.Checked);
                var isSaved = await _userService.AddUser(newUser);
                if (isSaved.Success)
                {
                    lbUserID.Text = isSaved.ID.ToString();
                    MessageBox.Show(isSaved.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(isSaved.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_mode == enMode.Update)
            {
                UpdateUserDTO updatedUser = new UpdateUserDTO(_UserID, txtUserName.Text, chkBoxIsActive.Checked);
                
                var isUpdated = await _userService.UpdateUser(_UserID,updatedUser);
                if (isUpdated != null && isUpdated.Success)
                {
                    MessageBox.Show(isUpdated.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(isUpdated?.Message ?? "Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void fmAddNewUser_Load(object sender, EventArgs e)
        {
            if(_mode == enMode.AddNew)
            {
                label1.Text = "Add New User";
            }
            else if(_mode == enMode.Update)
            {
                label1.Text = "Update User";
                ucPersonCardWithFilter1.SetPersonID(_PersonID);
                loadUserDataByUserID(_UserID);
            }
            
        }






        // Empty event handlers
        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ucPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
