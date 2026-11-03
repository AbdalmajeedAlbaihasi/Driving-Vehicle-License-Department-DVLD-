using DVLD_Desktop_Net8.Application.Services;
using DVLD_Desktop_Net8.License_Classes.Services;
using DVLD_Desktop_Net8.Local_Driving_License_Application.Services;
using DVLDShared.DTOs.LicenseClass;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.Local_Driving_License_Application
{
    public partial class fmNewLocalDrivingLicenseApplication : Form
    {
        private readonly LocalDrivingLicenseApplicationService? _localDrivingLicenseApplication = new LocalDrivingLicenseApplicationService();
        private readonly ManageApplicationTypesService _manageApplicationTypes = new ManageApplicationTypesService();
        private readonly LicenseClassesService _licenseClassesService = new LicenseClassesService();


        public fmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private async void loadApplicationFees()
        {
            try
            {
                // 1. جلب بيانات الرسوم من الخدمة
                var applicationFees = await _manageApplicationTypes.GetApplicationTypeFeesById(1);

                // 2. التحقق من وصول الاستجابة من السيرفر
                if (applicationFees == null)
                {
                    MessageBox.Show("Failed to connect to the server or no response received.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. التحقق من نجاح العملية
                if (!applicationFees.Success)
                {
                    MessageBox.Show(applicationFees.Message ?? "Failed to load application fees.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. عرض قيمة الرسوم بتنسيق عشري مناسب
                lbApplicationFees.Text = applicationFees.Fees.ToString("0.00");
            }
            catch (Exception ex)
            {
                // 5. حماية التطبيق من الانهيار عند أخطاء الاتصال
                MessageBox.Show($"An error occurred while loading fees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void loadLicenseClass()
        {
            try
            {
                // 1. جلب أسماء أنواع الرخص من الخدمة
                List<LicenseClassesNameDTO> licenseClasses = await _licenseClassesService.GetAllLicenseClassesNameAsync();

                // 2. التحقق من وصول البيانات وأن القائمة ليست فارغة
                if (licenseClasses == null || !licenseClasses.Any())
                {
                    MessageBox.Show("Failed to connect to the server or no license classes found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. منع الكتابة اليدوية وجعل خيار القائمة المنسدلة فقط
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

                // 4. تحديد اسم الخاصية المعروضة والخاصية الممثلة للقيمة المخفية (قبل إسناد الـ DataSource)
                comboBox1.DisplayMember = "ClassName";
                comboBox1.ValueMember = "LicenseClassId";

                // 5. ربط القائمة بالـ ComboBox وتحديد العنصر الأول
                comboBox1.DataSource = licenseClasses;
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading license classes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadDataToForm()
        {
            lbApplicationDate.Text = DateTime.Now.ToString();
            loadLicenseClass();
            loadApplicationFees();
            lbCreatedBy.Text = CurrentUser.UserName;
        }

        private void fmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            loadDataToForm();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من اختيار شخص من شاشة البحث
            int personID = ucPersonCardWithFilter1._personID;
            if (personID <= 0)
            {
                MessageBox.Show("Please select a person first!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. التحقق من اختيار فئة الرخصة
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a License Class!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. التحويل الآمن للبيانات
            int licenseClassId = Convert.ToInt32(comboBox1.SelectedValue);

            if (!decimal.TryParse(lbApplicationFees.Text, out decimal applicationFees))
            {
                MessageBox.Show("Invalid Application Fees value!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime applicationDate = DateTime.TryParse(lbApplicationDate.Text, out var parsedDate) ? parsedDate : DateTime.Now;
            int createdBy = (int)CurrentUser.UserId;

            // 4. تعطيل الزر لتجنب الضغط المكرر أثناء الاتصال
            btSave.Enabled = false;

            try
            {
                // 5. إنشاء كائن الـ DTO بكلمة new
                AddNewLocalDrivingLicenseApplicationDTO addNewLocal = new AddNewLocalDrivingLicenseApplicationDTO(
                    personID,
                    applicationDate,
                    licenseClassId,
                    applicationFees,
                    createdBy
                );

                // 6. إرسال الطلب مع await ومعالجة النتيجة
                var result = await _localDrivingLicenseApplication.AddNewLocalDrivingLicenseApplicationAsync(addNewLocal);

                if (result != null && result.Success)
                {
                    lbApplicationID.Text = result.ID.ToString();
                    MessageBox.Show(result.Message ?? "Application added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result?.Message ?? "Failed to add local driving license application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
