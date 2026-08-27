using DVLDDataAccess;
using DVLDShared.DTOs.People;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsPeopleBusiness
    {
        private readonly clsPeopleDataAccess _peopleDataAccess;

        public clsPeopleBusiness(clsPeopleDataAccess peopleDataAccess)
        {
            _peopleDataAccess = peopleDataAccess;
        }


        public async Task<List<PersonListDTO>> GetAllPeopleAsync()
        {
            return await _peopleDataAccess.GetAllPersonAsync();
        }


        public async Task<(bool Success, string Message, int PersonID)> AddNewPersonAsync(AddNewPeopleDTO addNewPeopleDTO)
        {
            if (addNewPeopleDTO == null)
            {
                return (false, "Invalid data", -1);
            }

            if (string.IsNullOrWhiteSpace(addNewPeopleDTO.NationalNo))
            {
                return (false, "National number is required", -1);
            }

            if (string.IsNullOrWhiteSpace(addNewPeopleDTO.FirstName))
            {
                return (false, "First name is required", -1);
            }

            if (string.IsNullOrWhiteSpace(addNewPeopleDTO.SecondName))
            {
                return (false, "Second name is required", -1);
            }

            if (string.IsNullOrWhiteSpace(addNewPeopleDTO.LastName))
            {
                return (false, "Last name is required", -1);
            }

            if (string.IsNullOrWhiteSpace(addNewPeopleDTO.Phone))
            {
                return (false, "Phone is required", -1);
            }

            if (addNewPeopleDTO.NationalityCountryID < 1)
            {
                return (false, "Invalid nationality country", -1);
            }

            if (addNewPeopleDTO.DateOfBirth > DateTime.Today.AddYears(-18))
            {
                return (false, "Person must be at least 18 years old", -1);
            }

            if (await _peopleDataAccess.IsNationalNoExistsAsync(
                addNewPeopleDTO.NationalNo))
            {
                return (false, "National number already exists", -1);
            }

            int personID =
                await _peopleDataAccess.AddNewPersonAsync(addNewPeopleDTO);

            if (personID == -1)
            {
                return (false, "Failed to add person", -1);
            }

            return (true, "Person added successfully", personID);
        }


        public async Task<OnePeopleDTO> GetPersonByIDAsync(int PersonID)
        {
            if (PersonID < 1)
            {
                return null;
            }

            return await _peopleDataAccess.GetPersonByIDAsync(PersonID);
        }


        public async Task<OnePeopleDTO> GetPersonByNationalNoAsync(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return null;
            }

            return await _peopleDataAccess
                .GetPersonByNationalNoAsync(nationalNo);
        }


        public async Task<(bool Success, string Message)> UpdatePersonAsync(UpdatePeopleDTO updatePeopleDTO)
        {
            if (updatePeopleDTO == null)
            {
                return (false, "Invalid data");
            }

            if (updatePeopleDTO.PersonID < 1)
            {
                return (false, "Invalid person ID");
            }

            OnePeopleDTO currentPerson =
                await _peopleDataAccess.GetPersonByIDAsync(updatePeopleDTO.PersonID);

            if (currentPerson == null)
            {
                return (false, "Person not found");
            }

            if (string.IsNullOrWhiteSpace(updatePeopleDTO.NationalNo))
            {
                return (false, "National number is required");
            }

            if (string.IsNullOrWhiteSpace(updatePeopleDTO.FirstName))
            {
                return (false, "First name is required");
            }

            if (string.IsNullOrWhiteSpace(updatePeopleDTO.SecondName))
            {
                return (false, "Second name is required");
            }

            if (string.IsNullOrWhiteSpace(updatePeopleDTO.LastName))
            {
                return (false, "Last name is required");
            }

            if (string.IsNullOrWhiteSpace(updatePeopleDTO.Phone))
            {
                return (false, "Phone is required");
            }

            if (updatePeopleDTO.NationalityCountryID < 1)
            {
                return (false, "Invalid nationality country");
            }

            if (updatePeopleDTO.DateOfBirth > DateTime.Today.AddYears(-18))
            {
                return (false, "Person must be at least 18 years old");
            }

            OnePeopleDTO personWithSameNationalNo =
                await _peopleDataAccess.GetPersonByNationalNoAsync(updatePeopleDTO.NationalNo);

            if (personWithSameNationalNo != null &&
                personWithSameNationalNo.PersonID != updatePeopleDTO.PersonID)
            {
                return (false, "National number already exists");
            }

            bool isUpdated =
                await _peopleDataAccess.UpdatePersonAsync(updatePeopleDTO);

            if (!isUpdated)
            {
                return (false, "Failed to update person");
            }

            return (true, "Person updated successfully");
        }


        public async Task<(bool Success, string Message)> DeletePersonAsync(int PersonID)
        {
            if (PersonID < 1)
            {
                return (false, "Invalid person ID");
            }

            OnePeopleDTO person =
                await _peopleDataAccess.GetPersonByIDAsync(PersonID);

            if (person == null)
            {
                return (false, "Person not found");
            }

            bool isDeleted =
                await _peopleDataAccess.DeletePersonAsync(PersonID);

            if (!isDeleted)
            {
                return (false, "Failed to delete person");
            }

            return (true, "Person deleted successfully");
        }


        public async Task<bool> IsNationalNoExistsAsync(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return false;
            }

            return await _peopleDataAccess
                .IsNationalNoExistsAsync(nationalNo);
        }
    }
}