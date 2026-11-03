using DVLDDataAccess.Entities;
using DVLDShared.DTOs.Applications;
using DVLDShared.DTOs.LicenseClass;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
using DVLDShared.DTOs.People;
using DVLDShared.DTOs.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccess
{
    public class clsLocalDrivingLicenseApplicationDataAccess
    {
        private readonly DVLDContext _context;
        public clsLocalDrivingLicenseApplicationDataAccess(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<LocalDrivingLicenseApplicationListDTO>> GetAllLocalDrivingLicenseApplicationsAsync()
        {
            try
            {
                var LocalDrivingLicenseApplicationsList =
                    await _context.LocalDrivingLicenseApplications
                    .AsNoTracking()
                    .Select(x => new LocalDrivingLicenseApplicationListDTO
                    (
                        x.LocalDrivingLicenseApplicationId,

                        x.LicenseClass.ClassName,

                        x.Application.ApplicantPerson.NationalNo,
                        x.Application.ApplicantPerson.FirstName + " " +
                        x.Application.ApplicantPerson.SecondName + " " +
                        (x.Application.ApplicantPerson.ThirdName ?? "") + " " +
                        x.Application.ApplicantPerson.LastName,

                        x.Application.ApplicationDate,

                        x.TestAppointments
                            .SelectMany(ta => ta.Tests)
                            .Count(t => t.TestResult == true),

                        x.Application.ApplicationStatus == 1 ? "New" :
                        x.Application.ApplicationStatus == 2 ? "Cancelled" :
                        x.Application.ApplicationStatus == 3 ? "Completed" :
                        "Unknown"
                    ))
                    .ToListAsync();

                return LocalDrivingLicenseApplicationsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"An error occurred while retrieving local driving license applications: {ex.Message}"
                );

                return new List<LocalDrivingLicenseApplicationListDTO>();
            }
        }

        public async Task<GetOneLocalDrivingLicenseApplicationDTO?> GetOneLocalDrivingLicenseApplicationsAsync(int id)
        {
            try
            {
                return await _context.LocalDrivingLicenseApplications
                    .AsNoTracking()
                    .Where(l => l.LocalDrivingLicenseApplicationId == id)
                    .Select(x => new GetOneLocalDrivingLicenseApplicationDTO
                    (
                        x.LocalDrivingLicenseApplicationId,

                        x.LicenseClass.ClassName,

                        x.TestAppointments
                            .SelectMany(ta => ta.Tests)
                            .Count(t => t.TestResult == true)

                    ))
                    .FirstOrDefaultAsync();

            }


            catch (Exception ex)
            {
                Console.WriteLine(
                    $"An error occurred while retrieving local driving license applications: {ex.Message}"
                );

                return null;
            }
        }

        public async Task<LocalDrivingLicenseApplicationInfoDTO?> GetLocalDrivingLicenseApplicationInfoByIDAsync(
                int localDrivingLicenseApplicationID)
        {
            try
            {
                return await _context.LocalDrivingLicenseApplications
                    .AsNoTracking()
                    .Where(a =>
                        a.LocalDrivingLicenseApplicationId ==
                        localDrivingLicenseApplicationID)
                    .Select(a => new LocalDrivingLicenseApplicationInfoDTO
                    {
                        ApplicationID = a.ApplicationId,
                        LicenseClassID = a.LicenseClassId
                    })
                    .FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> UpdateLocalDrivingLicenseApplicationStatusAsync(UpdateStatusDTO updateStatusDTO)
        {
            try
            {
                // 1. البحث بـ LocalDrivingLicenseApplicationId وتضمين جدول Applications الأساسي
                var localApp = await _context.LocalDrivingLicenseApplications
                    .Include(a => a.Application)
                    .FirstOrDefaultAsync(x => x.LocalDrivingLicenseApplicationId == updateStatusDTO.ApplicationId);

                if (localApp == null || localApp.Application == null)
                {
                    return false;
                }

                // 2. تحديث الحالة والتاريخ في الكائن المترابط
                localApp.Application.ApplicationStatus = updateStatusDTO.NewStatus;
                localApp.Application.LastStatusDate = DateTime.Now;

                int result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"An error occurred while updating the status: {ex.Message}"
                );

                return false;
            }


        }

        public async Task<int> AddNewLocalDrivingLicenseApplicationAsync(AddNewLocalDrivingLicenseApplicationDTO applicationDTO)
        {
            try
            {
                var newApplication = new Application
                {
                    ApplicantPersonId = applicationDTO.PersonID,
                    ApplicationDate = applicationDTO.ApplicationDate,
                    ApplicationTypeId = 1,
                    ApplicationStatus = 1,
                    LastStatusDate = applicationDTO.ApplicationDate,
                    PaidFees = applicationDTO.ApplicationsFees,
                    CreatedByUserId = applicationDTO.CreatedBy
                };

                var newLocalDrivingLicenseApplication =
                    new LocalDrivingLicenseApplication
                    {
                        LicenseClassId = applicationDTO.LisansClassID,

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

        public async Task<bool> HasActiveApplicationWithSameLicenseClassAsync(int ApplicantPersonID,int LicenseClassID)
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
