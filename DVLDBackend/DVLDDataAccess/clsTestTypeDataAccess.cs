using DVLDDataAccess.Entities;
using DVLDShared.DTOs.ApplicationsType;
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

        public async Task<TestTypeDTO?> GetOneTestTypes(int TestTypeID)
        {
            try
            {
                return await _context.TestTypes.AsNoTracking()
                    .Where(A => A.TestTypeId == TestTypeID)
                    .Select(at => new TestTypeDTO(at.TestTypeId,
                            at.TestTypeTitle, at.TestTypeDescription,at.TestTypeFees)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error getting Test type: {ex.Message}");

                return null;
            }


        }

        public async Task<int> AddNewTestTypeAsync(AddNewTestTypeDTO NewtestTypeDTO)
        {
            try
            {

                var testType = new TestType
                {
                    TestTypeTitle = NewtestTypeDTO.TestTypeTitle,
                    TestTypeDescription = NewtestTypeDTO.Description,
                    TestTypeFees = NewtestTypeDTO.TestFees 
                };


                await _context.TestTypes.AddAsync(testType);


                await _context.SaveChangesAsync();


                return testType.TestTypeId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding test type: {ex.Message}");
                return -1;
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