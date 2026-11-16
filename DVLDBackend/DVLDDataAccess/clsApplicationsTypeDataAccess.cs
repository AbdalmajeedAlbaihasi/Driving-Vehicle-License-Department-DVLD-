using DVLDDataAccess.Entities;
using DVLDShared.DTOs.ApplicationsType;
using DVLDShared.DTOs.Users;
using Microsoft.EntityFrameworkCore;

namespace DVLDDataAccess
{
    public class clsApplicationsTypeDataAccess
    {
        private readonly DVLDContext _context;
        public clsApplicationsTypeDataAccess(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationsTypeDTO>> GetAllApplicationsTypeAsync()
        {
            try
            {
                return await _context.ApplicationTypes.AsNoTracking()
                    .Select(at => new ApplicationsTypeDTO(at.ApplicationTypeId, 
                            at.ApplicationTypeTitle, at.ApplicationFees))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error getting application types: {ex.Message}");

                return new List<ApplicationsTypeDTO>();
            }
        }

        public async Task<ApplicationsTypeDTO?> GetOneApplicationsTypeAsync(int ApplicationsTypeID)
        {
            try
            {
                return await _context.ApplicationTypes.AsNoTracking()
                    .Where(A => A.ApplicationTypeId == ApplicationsTypeID)
                    .Select(at => new ApplicationsTypeDTO(at.ApplicationTypeId,
                            at.ApplicationTypeTitle, at.ApplicationFees)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error getting application types: {ex.Message}");

                return null;
            }

           
        }

        public async Task<bool> UpdateApplicationsTypeAsync(ApplicationsTypeDTO applicationsTypeDTO)
        {
            try
            {
                var applicationType = await _context.ApplicationTypes
                    .FindAsync(applicationsTypeDTO.ApplicationTypeId);
                if (applicationType == null)
                {
                    return false; 
                }

                applicationType.ApplicationTypeTitle = applicationsTypeDTO.ApplicationTypeTitle;
                applicationType.ApplicationFees = applicationsTypeDTO .ApplicationFees;

                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating application type: {ex.Message}");
                return false; 
            }
        }


        public async Task<decimal?> GetApplicationTypeFeesByIdAsync(int applicationTypeId)
        {
            try
            {
                return await _context.ApplicationTypes
                    .AsNoTracking()
                    .Where(a => a.ApplicationTypeId == applicationTypeId)
                    .Select(a => (decimal?)a.ApplicationFees)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
                return null;
            }
        }
    
    }
}
