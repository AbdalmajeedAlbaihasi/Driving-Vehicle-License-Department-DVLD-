using DVLD_Desktop_Net8.Application.Services;
using DVLDShared.DTOs.ApplicationsType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.Application
{
    public partial class fmEditApplicationType : Form
    {
        private readonly ManageApplicationTypesService _ManageApplicationTypesService = new ManageApplicationTypesService();
        private int _ApplicationTypeId;
        public fmEditApplicationType()
        {
            InitializeComponent();
        }

        public fmEditApplicationType(int applicationTypeId)
        {
            InitializeComponent();
            this._ApplicationTypeId = applicationTypeId;
        }



        private async void loadData()
        {
            // 1. ✅ الفحص الصحيح: الخروج فقط إذا كان المعرف غير صالح (أقل من أو يساوي 0)
            if (_ApplicationTypeId <= 0)
            {
                MessageBox.Show("Invalid Application Type ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                // 2. جلب البيانات من الـ API
                ApplicationsTypeDTO? applicationsTypeDTO = await _ManageApplicationTypesService.GetOneApplicationTypeAsync(_ApplicationTypeId);

                if (applicationsTypeDTO != null)
                {
                    lblApplicationTypeID.Text = applicationsTypeDTO.ApplicationTypeId.ToString();
                    txtTitle.Text = applicationsTypeDTO.ApplicationTypeTitle;
                    txtFees.Text = applicationsTypeDTO.ApplicationFees.ToString("0.00");
                }
                else
                {
                    // 3. معالجة حالة عدم العثور على البيانات
                    MessageBox.Show("Application Type not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // 4. حماية التطبيق من الانهيار عند أخطاء الشبكة
                MessageBox.Show($"Error loading data: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح بالأرقام فقط (IsDigit) وزر المسح Backspace (IsControl)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // منع إدخال الحروف والرموز
            }

        }

        private void fmEditApplicationType_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btSavePerson_Click(object sender, EventArgs e)
        {
            // 1. التحقق من تعبئة كافة الحقول
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtFees.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. التحقق من صحة إدخال الرسوم كقيمة رقمية
            if (!decimal.TryParse(txtFees.Text.Trim(), out decimal applicationFees))
            {
                MessageBox.Show("Please enter a valid numeric value for Application Fees.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. تعطيل الزر لتجنب الضغط المكرر أثناء الاتصال بالشبكة
            btSavePerson.Enabled = false;

            try
            {
                // استخدام المعرف الخاص بالشاشة
                int applicationTypeId = _ApplicationTypeId;
                string applicationTypeTitle = txtTitle.Text.Trim();

                ApplicationsTypeDTO applicationsTypeDTO = new ApplicationsTypeDTO(applicationTypeId, applicationTypeTitle, applicationFees);

                // إرسال طلب التحديث للـ API
                var res = await _ManageApplicationTypesService.UpdateApplicationsTypeAsync(applicationTypeId, applicationsTypeDTO);

                if (res != null && res.Success)
                {
                    MessageBox.Show(res.Message ?? "Application type updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res?.Message ?? "Error updating Application Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // إعادة تفعيل الزر دائماً حتى في حال حدوث خطأ
                btSavePerson.Enabled = true;
            }
        }
    }
}
