using DVLDDataAccess.Entities;
using DVLDShared.DTOs.Applications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccess
{
    public class clsApplicationsDataAccess
    {
        private readonly DVLDContext _context;
        public clsApplicationsDataAccess(DVLDContext context)
        {
            _context = context;
        }

        //نقدر نضيف طالما انه
        //1-ماعنده طلب من نفس النوع
        //2-اذا كان من نفس النوع لازم يكون الطلب السابق مكتمل او مرفوض او ملغي
        public async Task<int> AddNewApplicationAsync(
            AddNewApplicationDTO applicationDTO)
        {
            try
            {
                var newApplication = new Application
                {
                    ApplicantPersonId = applicationDTO.ApplicantPersonID,
                    ApplicationDate = applicationDTO.ApplicationDate,
                    ApplicationTypeId = applicationDTO.ApplicationTypeID,
                    ApplicationStatus = applicationDTO.ApplicationStatus,
                    LastStatusDate = applicationDTO.LastStatusDate,
                    PaidFees = applicationDTO.PaidFees,
                    CreatedByUserId = applicationDTO.CreatedByUserID
                };

                var newLocalDrivingLicenseApplication =
                    new LocalDrivingLicenseApplication
                    {
                        LicenseClassId = applicationDTO.LicenseClassID,

                        Application = newApplication
                    };

                _context.LocalDrivingLicenseApplications
                    .Add(newLocalDrivingLicenseApplication);

                await _context.SaveChangesAsync();

                return newLocalDrivingLicenseApplication
                    .LocalDrivingLicenseApplicationId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"An error occurred while adding a new application: {ex.Message}");

                return -1;
            }
        }

        public async Task<bool> HasActiveApplicationWithSameLicenseClassAsync(
            int ApplicantPersonID,
            int LicenseClassID)
        {
            try
            {
                return await _context.LocalDrivingLicenseApplications
                    .AnyAsync(app =>
                        app.Application.ApplicantPersonId == ApplicantPersonID &&
                        app.LicenseClassId == LicenseClassID &&
                        app.Application.ApplicationStatus == 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"An error occurred while checking for existing license applications: {ex.Message}");

                return false;
            }
        }
    }
}
