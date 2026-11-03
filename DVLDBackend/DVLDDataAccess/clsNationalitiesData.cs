using DVLDDataAccess.Entities;
using DVLDShared.DTOs.Nationalities;
using Microsoft.EntityFrameworkCore;

namespace DVLDDataAccessLayer
{
    public class clsNationalitiesData
    {
        private readonly DVLDContext _context;

        public clsNationalitiesData(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<NationalityListDTO>> GetAllNationalities()
        {
            return await _context.Countries
                .AsNoTracking()
                .Select(p => new NationalityListDTO(
                    p.CountryId,
                    p.CountryName
                ))
                .ToListAsync();
        }

        public async Task<NationalityListDTO?> GetNationalityByID(
            int nationalityID)
        {
            return await _context.Countries
                .AsNoTracking()
                .Where(p => p.CountryId == nationalityID)
                .Select(p => new NationalityListDTO(
                    p.CountryId,
                    p.CountryName
                ))
                .FirstOrDefaultAsync();
        }
    }
}