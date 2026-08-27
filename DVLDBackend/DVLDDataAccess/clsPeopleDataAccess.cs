using DVLDDataAccess.Entities;
using DVLDShared.DTOs.People;
using Microsoft.EntityFrameworkCore;

namespace DVLDDataAccess
{
    public class clsPeopleDataAccess
    {
        private readonly DVLDContext _context;

        public clsPeopleDataAccess(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<PersonListDTO>> GetAllPersonAsync()
        {
            try
            {
                return await _context.People
                    .AsNoTracking()
                    .Select(p => new PersonListDTO(
                        p.PersonId,
                        p.NationalNo,
                        p.FirstName,
                        p.SecondName,
                        p.ThirdName ?? "",
                        p.LastName,
                        p.Gendor,
                        p.DateOfBirth,
                        p.NationalityCountry.CountryName,
                        p.Phone,
                        p.Email ?? ""
                    ))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in GetAllPersonAsync: {ex.Message}");

                return new List<PersonListDTO>();
            }
        }

        public async Task<int> AddNewPersonAsync(AddNewPeopleDTO addNewPeopleDTO)
        {
            if (addNewPeopleDTO == null)
                return -1;

            if (string.IsNullOrWhiteSpace(addNewPeopleDTO.NationalNo))
                return -1;

            if (string.IsNullOrWhiteSpace(addNewPeopleDTO.FirstName))
                return -1;

            if (string.IsNullOrWhiteSpace(addNewPeopleDTO.LastName))
                return -1;

            if (addNewPeopleDTO.NationalityCountryID <= 0)
                return -1;

            try
            {
                bool nationalNoExists =
                    await _context.People.AnyAsync(
                        p => p.NationalNo == addNewPeopleDTO.NationalNo);

                if (nationalNoExists)
                    return -1;

                Person person = new Person
                {
                    NationalNo = addNewPeopleDTO.NationalNo,
                    FirstName = addNewPeopleDTO.FirstName,
                    SecondName = addNewPeopleDTO.SecondName,

                    ThirdName =
                        string.IsNullOrWhiteSpace(addNewPeopleDTO.ThirdName)
                            ? null
                            : addNewPeopleDTO.ThirdName,

                    LastName = addNewPeopleDTO.LastName,
                    DateOfBirth = addNewPeopleDTO.DateOfBirth,
                    Gendor = addNewPeopleDTO.Gendor,
                    Address = addNewPeopleDTO.Address,
                    Phone = addNewPeopleDTO.Phone,

                    Email =
                        string.IsNullOrWhiteSpace(addNewPeopleDTO.Email)
                            ? null
                            : addNewPeopleDTO.Email,

                    NationalityCountryId =
                        addNewPeopleDTO.NationalityCountryID,

                    ImagePath =
                        string.IsNullOrWhiteSpace(addNewPeopleDTO.ImagePath)
                            ? null
                            : addNewPeopleDTO.ImagePath
                };

                await _context.People.AddAsync(person);

                int affectedRows =
                    await _context.SaveChangesAsync();

                return affectedRows > 0
                    ? person.PersonId
                    : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in AddNewPersonAsync: {ex.Message}");

                return -1;
            }
        }

        public async Task<OnePeopleDTO?> GetPersonByIDAsync(int personID)
        {
            if (personID <= 0)
                return null;

            try
            {
                return await _context.People
                    .AsNoTracking()
                    .Where(p => p.PersonId == personID)
                    .Select(p => new OnePeopleDTO(
                        p.PersonId,
                        p.NationalNo,
                        p.FirstName,
                        p.SecondName,
                        p.ThirdName ?? "",
                        p.LastName,
                        p.DateOfBirth,
                        p.Gendor,
                        p.Address,
                        p.Phone,
                        p.Email ?? "",
                        p.NationalityCountryId,
                        p.NationalityCountry.CountryName,
                        p.ImagePath ?? ""
                    ))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in GetPersonByIDAsync: {ex.Message}");

                return null;
            }
        }

        public async Task<OnePeopleDTO?> GetPersonByNationalNoAsync(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
                return null;

            try
            {
                return await _context.People
                    .AsNoTracking()
                    .Where(p => p.NationalNo == nationalNo)
                    .Select(p => new OnePeopleDTO(
                        p.PersonId,
                        p.NationalNo,
                        p.FirstName,
                        p.SecondName,
                        p.ThirdName ?? "",
                        p.LastName,
                        p.DateOfBirth,
                        p.Gendor,
                        p.Address,
                        p.Phone,
                        p.Email ?? "",
                        p.NationalityCountryId,
                        p.NationalityCountry.CountryName,
                        p.ImagePath ?? ""
                    ))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in GetPersonByNationalNoAsync: {ex.Message}");

                return null;
            }
        }

        public async Task<bool> UpdatePersonAsync(UpdatePeopleDTO updatePeopleDTO)
        {
            if (updatePeopleDTO == null)
                return false;

            if (updatePeopleDTO.PersonID <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(updatePeopleDTO.NationalNo))
                return false;

            try
            {
                Person? person =
                    await _context.People.FindAsync(
                        updatePeopleDTO.PersonID);

                if (person == null)
                    return false;

                bool nationalNoExists =
                    await _context.People.AnyAsync(p =>
                        p.NationalNo == updatePeopleDTO.NationalNo &&
                        p.PersonId != updatePeopleDTO.PersonID);

                if (nationalNoExists)
                    return false;

                person.NationalNo =
                    updatePeopleDTO.NationalNo;

                person.FirstName =
                    updatePeopleDTO.FirstName;

                person.SecondName =
                    updatePeopleDTO.SecondName;

                person.ThirdName =
                    string.IsNullOrWhiteSpace(updatePeopleDTO.ThirdName)
                        ? null
                        : updatePeopleDTO.ThirdName;

                person.LastName =
                    updatePeopleDTO.LastName;

                person.DateOfBirth =
                    updatePeopleDTO.DateOfBirth;

                person.Gendor =
                    updatePeopleDTO.Gendor;

                person.Address =
                    updatePeopleDTO.Address;

                person.Phone =
                    updatePeopleDTO.Phone;

                person.Email =
                    string.IsNullOrWhiteSpace(updatePeopleDTO.Email)
                        ? null
                        : updatePeopleDTO.Email;

                person.NationalityCountryId =
                    updatePeopleDTO.NationalityCountryID;

                person.ImagePath =
                    string.IsNullOrWhiteSpace(updatePeopleDTO.ImagePath)
                        ? null
                        : updatePeopleDTO.ImagePath;

                int affectedRows =
                    await _context.SaveChangesAsync();

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in UpdatePersonAsync: {ex.Message}");

                return false;
            }
        }

        public async Task<bool> DeletePersonAsync(int personID)
        {
            if (personID <= 0)
                return false;

            try
            {
                Person? person =
                    await _context.People.FindAsync(personID);

                if (person == null)
                    return false;

                _context.People.Remove(person);

                int affectedRows =
                    await _context.SaveChangesAsync();

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in DeletePersonAsync: {ex.Message}");

                return false;
            }
        }

        public async Task<bool> IsNationalNoExistsAsync(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
                return false;

            try
            {
                return await _context.People
                    .AnyAsync(p => p.NationalNo == nationalNo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in IsNationalNoExistsAsync: {ex.Message}");

                return false;
            }
        }
    }
}