using DVLDDataAccess;
using DVLDShared.DTOs;
using DVLDShared.DTOs.ApplicationsType;
using DVLDShared.DTOs.TestType;
using System;
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

        public async Task<TestTypeDTO?> GetOneTestTypes(int TestTypeID)
        {
            if (TestTypeID < 1)
            {
                return null;
            }

            return await _testTypeDataAccess.GetOneTestTypes(TestTypeID);
        }

        public async Task<SuccessMessageResponseDTO> UpdateTestTypeAsync(TestTypeDTO testTypeDTO)
        {
            if (testTypeDTO == null)
            {
                return (new SuccessMessageResponseDTO(false, "Invalid data."));
            }
            if (testTypeDTO.TestTypeId <= 0)
            {
                return (new SuccessMessageResponseDTO(false, "Invalid test type ID."));
            }
            if (string.IsNullOrWhiteSpace(testTypeDTO.TestTypeTitle))
            {
                return (new SuccessMessageResponseDTO(false, "Test type title cannot be empty."));
            }
            if (testTypeDTO.TestFees < 0)
            {
                return (new SuccessMessageResponseDTO(false, "Test fees cannot be negative."));
            }

            var result = await _testTypeDataAccess.UpdateTestType(testTypeDTO);
            if (result)
            {
                return (new SuccessMessageResponseDTO(true, "Test type updated successfully."));
            }
            else
            {
                return (new SuccessMessageResponseDTO(false, "Failed to update test type."));
            }
        }

        public async Task<SuccessMessageResponseIdDTO> AddNewTestTypeAsync(AddNewTestTypeDTO newTestTypeDTO)
        {
            if (newTestTypeDTO == null)
            {
                return (new SuccessMessageResponseIdDTO(false, "Invalid data.", 0));
            }

            if (string.IsNullOrWhiteSpace(newTestTypeDTO.TestTypeTitle))
            {
                return (new SuccessMessageResponseIdDTO(false, "Test type title cannot be empty.", 0));
            }

            if (newTestTypeDTO.TestFees < 0)
            {
                return (new SuccessMessageResponseIdDTO(false, "Test fees cannot be negative.", 0));
            }

            var newTestTypeId = await _testTypeDataAccess.AddNewTestTypeAsync(newTestTypeDTO);
            if (newTestTypeId > 0)
            {
                return (new SuccessMessageResponseIdDTO(true, "Test type added successfully.", newTestTypeId));
            }
            else
            {
                return (new SuccessMessageResponseIdDTO(false, "Failed to add test type.", 0));
            }
        }
        
    }
}
