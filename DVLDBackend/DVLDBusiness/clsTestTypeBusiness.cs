using System;
using DVLDShared.DTOs.TestType;
using DVLDDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsTestTypeBusiness
    {
        private readonly clsTestTypeDataAccess _testTypeDataAccess;
        public clsTestTypeBusiness(clsTestTypeDataAccess testTypeDataAccess)
        {
            _testTypeDataAccess = testTypeDataAccess;
        }
        public async Task<List<TestTypeDTO>> GetAllTestTypesAsync()
        {

            return await _testTypeDataAccess.GetAllTestTypes();
        }
        public async Task<(bool Success, string Message)> UpdateTestTypeAsync(TestTypeDTO testTypeDTO)
        {
            if (testTypeDTO == null)
            {
                return (false, "Invalid data.");
            }
            if (testTypeDTO.TestTypeId <= 0)
            {
                return (false, "Invalid test type ID.");
            }
            if (string.IsNullOrWhiteSpace(testTypeDTO.TestTypeTitle))
            {
                return (false, "Test type title cannot be empty.");
            }
            if (testTypeDTO.TestFees < 0)
            {
                return (false, "Test fees cannot be negative.");
            }

            var result = await _testTypeDataAccess.UpdateTestType(testTypeDTO);
            if (result)
            {
                return (true, "Test type updated successfully.");
            }
            else
            {
                return (false, "Failed to update test type.");
            }
        }
    }
}
