using DVLDDataAccessLayer;
using DVLDShared.DTOs.Nationalities;

namespace DVLDBusiness
{
    public class clsNationalitiesBusiness
    {
        private readonly clsNationalitiesData _nationalitiesData;

        public clsNationalitiesBusiness(clsNationalitiesData nationalitiesData)
        {
            _nationalitiesData = nationalitiesData;
        }

        public async Task<List<NationalityListDTO>> GetAllNationalities()
        {
            return await _nationalitiesData.GetAllNationalities();
        }

        public async Task<NationalityListDTO?> GetNationalityByID(int nationalityID)
        {
            if (nationalityID < 1)
                return null;

            return await _nationalitiesData.GetNationalityByID(nationalityID);
        }
    }
}