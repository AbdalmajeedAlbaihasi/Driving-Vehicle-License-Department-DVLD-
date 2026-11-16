using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.People;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.People.Services
{
    public class PeopleService
    {
        private readonly PeopleApiService _api;

        public PeopleService()
        {
            _api = new PeopleApiService();
        }

        public string LastError => _api.LastError;

        public async Task<List<PersonListDTO>?> GetAllPeople()
        {
            return await _api.GetAllPeopleAsync();
        }

        public async Task<OnePeopleDTO?> GetPersonByPersonId(int id)
        {
            if (id <= 0) return null;
            return await _api.GetPersonByPersonIdAsync(id);
        }

        public async Task<OnePeopleDTO?> GetPersonByUserId(int id)
        {
            if (id <= 0) return null;
            return await _api.GetPersonByUserIdAsync(id);
        }

        public async Task<OnePeopleDTO?> GetPersonByNationalNo(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo)) return null;
            return await _api.GetPersonByNationalNoAsync(nationalNo);
        }

        public async Task<SuccessMessageResponseIdDTO?> AddPerson(AddNewPeopleDTO dto)
        {
            if (dto == null) return null;
            return await _api.AddPersonAsync(dto);
        }

        public async Task<bool> UpdatePerson(int id, UpdatePeopleDTO dto)
        {
            if (id <= 0 || dto == null) return false;
            return await _api.UpdatePersonAsync(id, dto);
        }

        public async Task<bool> DeletePerson(int id)
        {
            if (id <= 0) return false;
            return await _api.DeletePersonAsync(id);
        }

        public async Task<bool> CheckNationalNoExists(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo)) return false;
            return await _api.IsNationalNoExistsAsync(nationalNo);
        }
    }
}