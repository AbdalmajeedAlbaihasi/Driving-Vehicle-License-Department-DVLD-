using DVLDDataAccess.Entities;
using DVLDShared.DTOs.Test;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVLDDataAccess
{
    public class clsTestDataAccess
    {
        private readonly DVLDContext _context;

        public clsTestDataAccess(DVLDContext context)
        {
            _context = context;
        }

        // جلب تفاصيل الاختبار برقم الـ ID (مطابق لـ GetTestInfoByID عند الأستاذ)
        public async Task<TestDTO?> GetTestInfoByIdAsync(int testId)
        {
            return await _context.Tests
                .AsNoTracking()
                .Where(t => t.TestId == testId)
                .Select(t => new TestDTO(
                    t.TestId,
                    t.TestAppointmentId,
                    t.TestResult,
                    t.Notes ?? "",
                    t.CreatedByUserId
                ))
                .FirstOrDefaultAsync();
        }

        // جلب آخر اختبار بناءً على الشخص ورخصة القيادة ونوع الاختبار (مطابق لـ GetLastTestByPersonAndTestTypeAndLicenseClass)
        public async Task<TestDTO?> GetLastTestByPersonAndTestTypeAndLicenseClassAsync(int personId, int licenseClassId, int testTypeId)
        {
            return await _context.Tests
                .AsNoTracking()
                .Where(t => t.TestAppointment.LocalDrivingLicenseApplication.Application.ApplicantPersonId == personId
                         && t.TestAppointment.LocalDrivingLicenseApplication.LicenseClassId == licenseClassId
                         && t.TestAppointment.TestTypeId == testTypeId)
                .OrderByDescending(t => t.TestAppointmentId)
                .Select(t => new TestDTO(
                    t.TestId,
                    t.TestAppointmentId,
                    t.TestResult,
                    t.Notes ?? "",
                    t.CreatedByUserId
                ))
                .FirstOrDefaultAsync();
        }

        // جلب كل الاختبارات (مطابق لـ GetAllTests)
        public async Task<List<TestDTO>> GetAllTestsAsync()
        {
            return await _context.Tests
                .AsNoTracking()
                .OrderBy(t => t.TestId)
                .Select(t => new TestDTO(
                    t.TestId,
                    t.TestAppointmentId,
                    t.TestResult,
                    t.Notes ?? "",
                    t.CreatedByUserId
                ))
                .ToListAsync();
        }

        // إضافة اختبار جديد مع قفل موعد الاختبار في معاملة واحدة (Transaction)
        public async Task<int> AddNewTestAsync(AddNewTestDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var test = new Test
                {
                    TestAppointmentId = dto.TestAppointmentId,
                    TestResult = dto.TestResult,
                    Notes = string.IsNullOrEmpty(dto.Notes) ? null : dto.Notes,
                    CreatedByUserId = dto.CreatedByUserId
                };

                _context.Tests.Add(test);

                // قفل الموعد تماماً مثل كود الأستاذ
                var appointment = await _context.TestAppointments.FindAsync(dto.TestAppointmentId);
                if (appointment != null)
                {
                    appointment.IsLocked = true;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return test.TestId;
            }
            catch
            {
                await transaction.RollbackAsync();
                return -1;
            }
        }

        // تعديل بيانات الاختبار (مطابق لـ UpdateTest)
        public async Task<bool> UpdateTestAsync(UpdateTestDTO dto)
        {
            var test = await _context.Tests.FindAsync(dto.TestId);
            if (test == null) return false;

            test.TestAppointmentId = dto.TestAppointmentId;
            test.TestResult = dto.TestResult;
            test.Notes = string.IsNullOrEmpty(dto.Notes) ? null : dto.Notes;
            test.CreatedByUserId = dto.CreatedByUserId;

            _context.Tests.Update(test);
            return await _context.SaveChangesAsync() > 0;
        }

        // حساب عدد الاختبارات الناجحة لرخصة القيادة المحلية (مطابق لـ GetPassedTestCount)
        public async Task<byte> GetPassedTestCountAsync(int localDrivingLicenseApplicationId)
        {
            int count = await _context.Tests
                .AsNoTracking()
                .Where(t => t.TestAppointment.LocalDrivingLicenseApplicationId == localDrivingLicenseApplicationId
                         && t.TestResult)
                .Select(t => t.TestAppointment.TestTypeId)
                .Distinct() // لضمان عدم تكرار نفس نوع الاختبار لو حدث خطأ
                .CountAsync();

            return (byte)count;
        }
    }
}