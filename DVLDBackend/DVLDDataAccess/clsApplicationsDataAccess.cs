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
        public async Task<int> AddNewApplication(AddNewApplicationDTO applicationDTO)
        {
            try
            {
                var newApplication = new Application
                {                    
                    ApplicantPersonId = applicationDTO.ApplicantPersonID ,
                    ApplicationDate = applicationDTO.ApplicationDate,
                    ApplicationTypeId = applicationDTO.ApplicationTypeID,
                    ApplicationStatus = applicationDTO.ApplicationStatus,
                    LastStatusDate = applicationDTO.LastStatusDate,
                    PaidFees = applicationDTO.PaidFees,
                    CreatedByUserId = applicationDTO.CreatedByUserID
                };
                _context.Applications.Add(newApplication);
                int newApplicationId = newApplication.ApplicationId;

                var newLocalDrivingLicenseApplication = new LocalDrivingLicenseApplication
                {
                    ApplicationId = newApplicationId,
                    LicenseClassId = applicationDTO.LicenseClassID
                };


                _context.LocalDrivingLicenseApplications.Add(newLocalDrivingLicenseApplication);

                int newLocalDrivingLicenseApplicationID = await _context.SaveChangesAsync();
                return newLocalDrivingLicenseApplicationID;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding a new application: {ex.Message}");
                return -1;
            }
        }

        public async Task<bool> HasApplicationWithSameTypeAsync(int ApplicantPersonID, int LicenseClassID)
        {
            try
            {
                return await _context.LocalDrivingLicenseApplications
                    .AnyAsync(app => app.Application.ApplicantPersonId == ApplicantPersonID &&
                            app.LicenseClassId == LicenseClassID);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking for existing license applications: {ex.Message}");
                return false;
            }
        }



        LocalDrivingLicenseApplication
        LocalDrivingLicenseApplicationID

        LicenseClass
        ClassName

        People
        NationalNo
        FullName

        Application
        ApplicationDate



    }
}
