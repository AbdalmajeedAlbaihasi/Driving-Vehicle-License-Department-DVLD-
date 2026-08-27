using DVLDDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using DVLDShared.DTOs.ApplicationsType;

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

        public async Task<bool> UpdateTitleNameAsync(int applicationTypeId, string newTitle)
        {
            try
            {
                var applicationType = await _context.ApplicationTypes
                    .FirstOrDefaultAsync(at => at.ApplicationTypeId == applicationTypeId);
                if (applicationType == null)
                {
                    return false; 
                }
                applicationType.ApplicationTypeTitle = newTitle;
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating application type: {ex.Message}");
                return false; 
            }
        }

        public async Task<bool> UpdateApplicationFeesAsync(int applicationTypeId, decimal newFees)
        {
            try
            {
                var applicationType = await _context.ApplicationTypes
                    .FirstOrDefaultAsync(at => at.ApplicationTypeId == applicationTypeId);
                if (applicationType == null)
                {
                    return false; 
                }
                applicationType.ApplicationFees = newFees;
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating application fees: {ex.Message}");
                return false; 
            }
        }
    }
}
