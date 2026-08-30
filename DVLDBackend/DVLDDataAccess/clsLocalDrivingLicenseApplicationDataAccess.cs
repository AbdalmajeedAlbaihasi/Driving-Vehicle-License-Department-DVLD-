using DVLDDataAccess.Entities;
using DVLDShared.DTOs.LicenseClass;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
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

        public async Task<bool> UpdateLocalDrivingLicenseApplicationStatusAsync(int localDrivingLicenseApplicationId,byte newStatus)
        {
            try
            {
                var application =
                    await _context.LocalDrivingLicenseApplications
                        .Include(x => x.Application)
                        .FirstOrDefaultAsync(x =>
                            x.LocalDrivingLicenseApplicationId ==
                            localDrivingLicenseApplicationId);

                if (application == null)
                {
                    return false;
                }

                application.Application.ApplicationStatus = newStatus;
                application.Application.LastStatusDate = DateTime.Now;

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


    }
}
