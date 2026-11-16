using DVLD_Desktop_Net8.Application.Services;
using DVLD_Desktop_Net8.Test_Type.Services;
using DVLDShared.DTOs.ApplicationsType;
using DVLDShared.DTOs.TestType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_Net8.Test_Type
{
    public partial class fmEditTestType : Form
    {
        private readonly TestTypeService _testTypeService = new TestTypeService();
        private int _testTypeID;


        public fmEditTestType()
        {
            InitializeComponent();
        }

        public fmEditTestType(int TestTyopeID)
        {
            InitializeComponent();
            _testTypeID = TestTyopeID;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void fmEditTestType_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            // 1. ✅ الفحص الصحيح: الخروج فقط إذا كان المعرف غير صالح (أقل من أو يساوي 0)
            if (_testTypeID <= 0)
            {
                MessageBox.Show("Invalid Test Type ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                // 2. جلب البيانات من الـ API
                TestTypeDTO? testTypeDTO = await _testTypeService.GetOneTestType(_testTypeID);

                if (testTypeDTO != null)
                {
                    lblTestTypeID.Text = testTypeDTO.TestTypeId.ToString();
                    txtDescription.Text = testTypeDTO.Description.ToString();
                    txtTitle.Text = testTypeDTO.TestTypeTitle;
                    txtFees.Text = testTypeDTO.TestFees.ToString("0.00");
                }
                else
                {
                    // 3. معالجة حالة عدم العثور على البيانات
                    MessageBox.Show("Test Type not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        



        private async void btSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من تعبئة كافة الحقول
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtFees.Text) || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. التحقق من صحة إدخال الرسوم كقيمة رقمية
            if (!decimal.TryParse(txtFees.Text.Trim(), out decimal TestFees))
            {
                MessageBox.Show("Please enter a valid numeric value for Test Fees.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. تعطيل الزر لتجنب الضغط المكرر أثناء الاتصال بالشبكة
            btSave.Enabled = false;

            try
            {
                // استخدام المعرف الخاص بالشاشة
                int TestTypeId = _testTypeID;
                string TestTypeTitle = txtTitle.Text.Trim();
                string Description = txtDescription.Text.Trim();

                TestTypeDTO testTypeDTO = new TestTypeDTO(TestTypeId, TestTypeTitle, Description, TestFees);

                // إرسال طلب التحديث للـ API
                var res = await _testTypeService.UpdateTestTypeAsync(TestTypeId, testTypeDTO);

                if (res != null && res.Success)
                {
                    MessageBox.Show(res.Message ?? "Test type updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res?.Message ?? "Error updating Test Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // إعادة تفعيل الزر دائماً حتى في حال حدوث خطأ
                btSave.Enabled = true;
            }
        }

        
    }
}
