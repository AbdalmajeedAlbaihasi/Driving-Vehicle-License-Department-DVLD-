using DVLD_Desktop_Net8;
using DVLD_Desktop_Net8.User.Services;
using DVLDShared.DTOs.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Desktop_Net8.User
{
    public partial class fmLogin : Form
    {
        //members
        private readonly UserService _userService = new UserService();
        private int _UserID;
        private readonly string _credentialsFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "RememberMe.txt");


        //constructors
        public fmLogin()
        {
            InitializeComponent();
        }





        //methods
        private void SaveCredentials(string username, string password)
        {
            if (chkBxRememberMe.Checked)
            {
                // حفظ اسم المستخدم في السطر الأول وكلمة المرور في السطر الثاني
                string[] lines = { username, password };
                File.WriteAllLines(_credentialsFilePath, lines);
            }
            else
            {
                // إذا أزال المستخدم التحديد، نحذف الملف القديم إن وجد
                if (File.Exists(_credentialsFilePath))
                {
                    File.Delete(_credentialsFilePath);
                }
            }
        }

        private void LoadCredentials()
        {
            if (File.Exists(_credentialsFilePath))
            {
                string[] lines = File.ReadAllLines(_credentialsFilePath);

                if (lines.Length >= 2)
                {
                    txtUserName.Text = lines[0];
                    txtPassword.Text = lines[1];
                    chkBxRememberMe.Checked = true;
                }
            }
            else
            {
                chkBxRememberMe.Checked = false;
            }
        }





        //handlers
        private void fmLogin_Load(object sender, EventArgs e)
        {
            LoadCredentials();
        }


        private async void btLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text; // لا نعمل Trim لكلمة المرور لأن المسافات قد تكون جزءاً منها

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تعطيل الزر لمنع الضغط المكرر أثناء انتظار السيرفر
            btLogin.Enabled = false;

            try
            {
                LoginDTO loginDTO = new LoginDTO(userName, password);
                var result = await _userService.Login(loginDTO);

                // ✅ الفحص الآمن والصحيح: النتيجة ليست null والنجاح true
                if (result != null && result.Success)
                {
                    SaveCredentials(userName, password);
                    _UserID = result.UserID;

                    CurrentUser.LoadCurrentUser(_UserID, userName);

                    fmMain mainForm = new fmMain(result.UserID);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    string errorMessage = result?.Message ?? "Invalid username or password or connection failed.";
                    MessageBox.Show(errorMessage, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // إعادة تفعيل الزر سواء نجحت العملية أو فشلت
                btLogin.Enabled = true;
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // Empty event handlers for the controls in the form
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
