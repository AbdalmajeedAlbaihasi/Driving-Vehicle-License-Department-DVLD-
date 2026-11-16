using DVLDDataAccess.Entities;
using DVLDShared.DTOs.ApplicationsType;
using DVLDShared.DTOs.LicenseClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLDDataAccess
{
    public class clsLicenseClassesDataAccess
    {
        private readonly DVLDContext _context;
        public clsLicenseClassesDataAccess(DVLDContext context)
        {
            _context = context;
        }


        public async Task<List<LicenseClassesNameDTO>> GetAllLicenseClassesNameAsync()
        {
            try
            {
                return await _context.LicenseClasses.AsNoTracking()
                    .Select(at => new LicenseClassesNameDTO(at.LicenseClassId,
                            at.ClassName))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error getting License Classes Name: {ex.Message}");

                return new List<LicenseClassesNameDTO>();
            }
        }



    }
}
