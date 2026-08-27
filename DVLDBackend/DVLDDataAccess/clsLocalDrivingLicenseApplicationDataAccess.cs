using DVLDDataAccess.Entities;
using DVLDShared.DTOs.LicenseClass;
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

        public async Task<List<LicenseClassDTO>> GetAllLocalDrivingLicenseApplications()
        {
            try
            {
                var LicenseClassList = await _context.LicenseClasses.AsNoTracking()
                    .Select(x => new LicenseClassDTO
                    (
                        x.LicenseClassId,
                        x.ClassName,
                        x.ClassFees
                    )).ToListAsync();
                return LicenseClassList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving license classes: {ex.Message}");
                return new List<LicenseClassDTO>();
            }
        }

        
    }
}
