using DVLD_Desktop_Net8.User.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.User.UsersControls
{
    public partial class ucShowUserDetails : UserControl
    {
        private readonly UserService _userService;
        public ucShowUserDetails()
        {
            InitializeComponent();
            _userService = new UserService();
        }
        public async void loadUserDetailsByUserID(int userID)
        {
            var user = await _userService.GetUserById(userID);
            if (user == null || user.UserID <= 0) return;

            lblUserID.Text = user.UserID.ToString();
            lblUserName.Text = user.UserName;
            lblIsActive.Text = user.IsActive ? "Active" : "Inactive";

            await ucShowPesronDetails1.LoadPersonDataByUserID(userID);
        }






        //empty 
        private void ucShowUserDetails_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucShowPesronDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
