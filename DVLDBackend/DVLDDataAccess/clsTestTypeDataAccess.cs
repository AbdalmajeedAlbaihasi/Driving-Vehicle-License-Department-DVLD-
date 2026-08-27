using DVLDDataAccess.Entities;
using DVLDShared.DTOs.TestType;
using Microsoft.EntityFrameworkCore;

namespace DVLDDataAccess
{
    public class clsTestTypeDataAccess
    {
        private readonly DVLDContext _context;

        public clsTestTypeDataAccess(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<TestTypeDTO>> GetAllTestTypes()
        {
            try
            {
                return await _context.TestTypes.AsNoTracking()
                    .Select(tt => new TestTypeDTO(tt.TestTypeId, tt.TestTypeTitle,
                            tt.TestTypeDescription, tt.TestTypeFees))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking database connection: {ex.Message}");
                 return new List<TestTypeDTO>(); ;
            }
        }

        public async Task<bool> UpdateTestType(TestTypeDTO testTypeDTO)
        {
            try
            {
                var testType = await _context.TestTypes.FindAsync(testTypeDTO.TestTypeId);
                if (testType == null)
                {
                    return false; 
                }
                testType.TestTypeTitle = testTypeDTO.TestTypeTitle;
                testType.TestTypeDescription = testTypeDTO.Description;
                testType.TestTypeFees = testTypeDTO.TestFees;
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating test type: {ex.Message}");
                return false; 
            }
        }

    }
}