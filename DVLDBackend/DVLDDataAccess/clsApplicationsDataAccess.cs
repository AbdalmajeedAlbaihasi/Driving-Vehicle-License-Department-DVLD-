using DVLDDataAccess.Entities;
using DVLDShared.DTOs.Applications;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
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

        public async Task<GetApplicationByLocalDrivingLicenseApplicationIdDTO?> GetApplicationByLocalDrivingLicenseApplicationIdAsync(int LocalDrivingLicenseApplicationId)
        {
            try
            {
                var application = await _context.Applications
                    .AsNoTracking()
                    .Where(app => app.ApplicationId == LocalDrivingLicenseApplicationId)
                    .Select(app => new GetApplicationByLocalDrivingLicenseApplicationIdDTO
                    (
                        app.ApplicationId,
                        app.ApplicantPersonId,
                        app.ApplicationStatus,
                        app.PaidFees,
                        app.ApplicationType.ApplicationTypeTitle,
                        app.ApplicantPerson.FirstName + " " +
                        app.ApplicantPerson.SecondName + " " +
                        app.ApplicantPerson.ThirdName + " " +
                        app.ApplicantPerson.LastName ,
                        app.ApplicationDate,
                        app.LastStatusDate,
                        app.CreatedByUser.UserName
                    ))
                    .FirstOrDefaultAsync();
                return application;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"An error occurred while retrieving the application by ID: {ex.Message}");
                return null;
            }
        }


    }
}
