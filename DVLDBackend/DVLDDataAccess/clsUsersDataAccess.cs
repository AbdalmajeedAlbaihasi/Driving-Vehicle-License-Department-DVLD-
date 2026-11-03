using DVLDDataAccess.Entities;
using DVLDShared.DTOs.Users;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DVLDDataAccess
{
    public class clsUsersDataAccess
    {
        private readonly DVLDContext _context;

        public clsUsersDataAccess(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<UsersListDTO>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.AsNoTracking()
                                .Select(u => new UsersListDTO(
                                    u.UserId,
                                    u.PersonId,
                                    u.Person.FirstName + " " + u.Person.SecondName + " " +
                                    u.Person.ThirdName + " " + u.Person.LastName,
                                    u.UserName,
                                    u.IsActive
                                    )).ToListAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in GetAllUsersAsync: {ex.Message}");

                return new List<UsersListDTO>();
            }

        }

        public async Task<GetUserByIDDTO?> GetUserByIDAsync(int userID)
        {
            try
            {
                return await _context.Users
                    .Where(u => u.UserId == userID)
                    .Select(u => new GetUserByIDDTO(
                        u.UserId,
                        u.PersonId,
                        u.UserName,
                        u.IsActive
                    ))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in GetUserByIDAsync: {ex.Message}");

                return null;
            }
        }

        public async Task<UserLoginDataDTO?> GetUserForLoginAsync(string username)
        {
            try
            {
                return await _context.Users
                                .Where(u => u.UserName == username)
                                .Select(u => new UserLoginDataDTO(
                                    u.UserId,
                                    u.UserName,
                                    u.Password,
                                    u.IsActive
                                    )).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error in GetUserForLoginAsync: {ex.Message}");

                return null;
            }


        }

        public async Task<int> AddNewUserAsync(AddNewUserDTO addNewUserDTO)
        {
            try
            {
                User user = new User { 
                    PersonId = addNewUserDTO.PersonID,
                    UserName = addNewUserDTO.UserName,
                    Password = addNewUserDTO.Password,
                    IsActive = addNewUserDTO.IsActive
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user.UserId;

            }
            catch
            {
                return -1;
            }
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDTO updateUserDTO)
        {
            try
            {
                User? user = await _context.Users.FindAsync(updateUserDTO.UserID);
                if (user == null)
                {
                    return false;
                }
                user.UserName = updateUserDTO.UserName;
                user.IsActive = updateUserDTO.IsActive;
                

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int userID)
        {
            try
            {
                var user = await _context.Users
                    .FindAsync(userID);

                if (user == null)
                {
                    return false;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string?> GetPasswordHashByUserIDAsync(int userID)
        {
            try
            {
                return await _context.Users
                    .Where(u => u.UserId == userID)
                    .Select(u => u.Password)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> ChangePasswordAsync(int userID,string NewPassword)
        {
            try
            {
                User? user = await _context.Users.FindAsync(userID);

                if (user == null)
                {
                    return false;
                }
                user.Password = NewPassword;

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> IsUserNameExistsAsync(string userName)
        {
            return await _context.Users
                .AnyAsync(u => u.UserName == userName);
        }

        public async Task<bool> IsUserNameExistsForAnotherUserAsync(string userName, int userID)
        {
            return await _context.Users
                .AnyAsync(u =>
                    u.UserName == userName &&
                    u.UserId != userID);
        }

        public async Task<bool> IsPersonLinkedToUserAsync(int personID)
        {
            try
            {
                return await _context.Users
            .AnyAsync(u => u.PersonId == personID);
            }
            catch
            {
                return false;
            }
        }
    }
}
