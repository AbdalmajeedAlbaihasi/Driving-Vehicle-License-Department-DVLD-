using DVLD_Desktop_Net8.User.Services;

namespace DVLD_Desktop_Net8.User
{
    public partial class fmChangePassword : Form
    {
        //members
        private readonly UserService _userService = new UserService();
        private int _userId;


        
        //constructors
        public fmChangePassword()
        {
            InitializeComponent();
            _userService = new UserService();
        }
        public fmChangePassword(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }




        ////event handeler
        private async void txtBoxCurrentPassword_TextChanged(object sender, EventArgs e)
        {

            string currentPassword = txtBoxCurrentPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                errorProvider1.SetError(txtBoxCurrentPassword, string.Empty);
                return;
            }

            try
            {
                // ✅ استخدام await بدلاً من .Result وتمرير الحقل الصحيح
                var isPasswordCorrect = await _userService.VerifyCurrentPassword(_userId, currentPassword);

                if (isPasswordCorrect == null || !isPasswordCorrect.Success)
                {
                    errorProvider1.SetError(txtBoxCurrentPassword, isPasswordCorrect?.Message ?? "Incorrect current password.");
                }
                else
                {
                    errorProvider1.SetError(txtBoxCurrentPassword, string.Empty);
                }
            }
            catch (Exception ex)
            {
                // حماية الشاشة من الانهيار عند انقطاع الاتصال
                errorProvider1.SetError(txtBoxCurrentPassword, "Connection error: " + ex.Message);
            }
        }

        private void txtBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxNewPassword.Text != txtBoxConfirmPassword.Text)
            {
                errorProvider1.SetError(txtBoxConfirmPassword, "Passwords do not match.");
            }
            else
            {
                errorProvider1.SetError(txtBoxConfirmPassword, string.Empty);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtBoxCurrentPassword.Text;
            string newPassword = txtBoxNewPassword.Text;
            string confirmPassword = txtBoxConfirmPassword.Text;

            // أ. التحقق من التعبئة
            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ب. التحقق من التطابق
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ج. التأكد من عدم وجود أخطاء قائمة في الـ ErrorProvider
            if (!string.IsNullOrEmpty(errorProvider1.GetError(txtBoxCurrentPassword)) ||
                !string.IsNullOrEmpty(errorProvider1.GetError(txtBoxConfirmPassword)))
            {
                MessageBox.Show("Please fix the validation errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btSave.Enabled = false;

            try
            {
                // ✅ استخدام await المباشر وتجنب .Result
                var result = await _userService.ChangePassword(_userId, newPassword);

                if (result != null && result.Success)
                {
                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result?.Message ?? "Error changing password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btSave.Enabled = true;
            }
        }

        private void fmChangePassword_Load(object sender, EventArgs e)
        {
            ucShowUserDetails1.loadUserDetailsByUserID(_userId);
        }





        //empty
        private void ucShowUserDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
