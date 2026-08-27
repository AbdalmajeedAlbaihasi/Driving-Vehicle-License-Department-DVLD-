using BCrypt.Net;
using DVLDDataAccess;
using DVLDDataAccess.Entities;
using DVLDShared.DTOs.Users;

namespace DVLDBusiness
{
    public class clsUsersBusiness
    {
        private readonly clsUsersDataAccess _usersDataAccess;

        public clsUsersBusiness(clsUsersDataAccess usersDataAccess)
        {
            _usersDataAccess = usersDataAccess;
        }

        public async Task<(bool Success, string Message, int UserID, bool IsActive)> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return (false, "Invalid data", -1, false);
            }

            if (string.IsNullOrWhiteSpace(loginDTO.UserName) ||
                string.IsNullOrWhiteSpace(loginDTO.Password))
            {
                return (false, "Username or password is required", -1, false);
            }

            var user =
                await _usersDataAccess.GetUserForLoginAsync(loginDTO.UserName);

            if (user == null)
            {
                return (false, "Invalid username or password", -1, false);
            }

            if (!user.IsActive)
            {
                return (false, "User account is inactive", user.UserID, false);
            }

            bool isPasswordCorrect =
                BCrypt.Net.BCrypt.Verify(
                    loginDTO.Password,
                    user.PasswordHash);

            if (!isPasswordCorrect)
            {
                return (false, "Invalid username or password", -1, false);
            }

            return (
                true,
                "Login successful",
                user.UserID,
                user.IsActive
            );
        }

        public async Task<(bool Success, string Message, List<UsersListDTO>? UsersList)>GetAllUsersAsync()
        {
            var users = await _usersDataAccess.GetAllUsersAsync();

            if (users.Count == 0)
            {
                return (false, "No users found", null);
            }

            return (true, "Users found successfully", users);
        }

        public async Task<(bool Success, string Message, int UserID)> AddNewUserAsync(AddNewUserDTO addNewUserDTO)
        {
            if (addNewUserDTO == null)
            {
                return (false, "Invalid data", -1);
            }

            if (addNewUserDTO.PersonID < 1)
            {
                return (false, "Invalid person ID", -1);
            }

            if (string.IsNullOrWhiteSpace(addNewUserDTO.UserName))
            {
                return (false, "UserName is required", -1);
            }

            if (string.IsNullOrWhiteSpace(addNewUserDTO.Password))
            {
                return (false, "Password is required", -1);
            }

            if (await _usersDataAccess.IsUserNameExistsAsync(addNewUserDTO.UserName))
            {
                return (false, "Username already exists", -1);
            }

            addNewUserDTO.Password =
                            BCrypt.Net.BCrypt.HashPassword(addNewUserDTO.Password);

            int userID = await _usersDataAccess.AddNewUserAsync(addNewUserDTO);

            if (userID == -1)
            {
                return (false, "Failed to add user", -1);
            }

            return (true, "User added successfully", userID);
        }

        public async Task<UsersListDTO?> GetUserByIDAsync(int userID)
        {
            if (userID < 1)
            {
                return null;
            }

            return await _usersDataAccess.GetUserByIDAsync(userID);
        }

        public async Task<(bool Success, string Message)> UpdateUserAsync(UpdateUserDTO updateUserDTO)
        {
            if (updateUserDTO == null)
            {
                return (false, "Invalid data");
            }

            if (updateUserDTO.PersonID < 1)
            {
                return (false, "Invalid person ID");
            }

            if (updateUserDTO.UserID < 1)
            {
                return (false, "Invalid user ID");
            }

            if (string.IsNullOrWhiteSpace(updateUserDTO.UserName))
            {
                return (false, "Username is required");
            }

            if (await _usersDataAccess.IsUserNameExistsForAnotherUserAsync(updateUserDTO.UserName,updateUserDTO.UserID))
            {
                return (false, "Username already exists");
            }

            updateUserDTO.Password =
        BCrypt.Net.BCrypt.HashPassword(updateUserDTO.Password);

            bool isUpdated =
                await _usersDataAccess.UpdateUserAsync(updateUserDTO);

            if (!isUpdated)
            {
                return (false, "User update failed");
            }

            return (true, "User updated successfully");
        }

        public async Task<(bool Success, string Message)> DeleteUserAsync(int userID)
        {
            if (userID < 1)
            {
                return (false, "Invalid user ID");
            }

            bool isLinkedToPerson = await _usersDataAccess.IsUserLinkedToPersonAsync(userID);

            if (isLinkedToPerson)
            {
                return (false, "User cannot be deleted because it is linked to a person");
            }

            bool isDeleted = await _usersDataAccess.DeleteUserAsync(userID);

            if (!isDeleted)
            {
                return (false, "User deletion failed");
            }

            return (true, "User deleted successfully");
        }

        public async Task<(bool Success, string Message)> VerifyCurrentPasswordAsync(int userID, string password)
        {
            if (userID <= 0)
            {
                return (false, "Invalid user ID");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "Password is required");
            }

            string? passwordHash =
                await _usersDataAccess.GetPasswordHashByUserIDAsync(userID);

            if (passwordHash == null)
            {
                return (false, "User not found");
            }

            bool isPasswordCorrect =
                BCrypt.Net.BCrypt.Verify(
                    password,
                    passwordHash);

            if (!isPasswordCorrect)
            {
                return (false, "Invalid password");
            }

            return (true, "Password is correct");
        }
 
        public async Task<(bool Success, string Message)> ChangePasswordAsync(int userID,string newPassword)
        {
            if (userID <= 0)
            {
                return (false, "Invalid user ID");
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                return (false, "New password is required");
            }

            string newPasswordHash =
                BCrypt.Net.BCrypt.HashPassword(newPassword);

            bool result =
                await _usersDataAccess.ChangePasswordAsync(
                    userID,
                    newPasswordHash);

            if (!result)
            {
                return (false, "Failed to change password");
            }

            return (true, "Password changed successfully");
        }
    }
}
