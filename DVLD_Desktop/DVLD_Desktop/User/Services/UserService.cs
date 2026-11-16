using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.User.Services
{
    public class UserService
    {
        private readonly UserApiService _api;

        public UserService()
        {
            _api = new UserApiService();
        }

        public string LastError => _api.LastError;

        public async Task<LoginResponseDTO?> Login(LoginDTO dto)
        {
            if (dto == null) return new LoginResponseDTO();
            return await _api.LoginAsync(dto);
        }

        public async Task<List<UsersListDTO>?> GetAllUsers()
        {
            return await _api.GetAllUsersAsync();
        }

        public async Task<UsersListDTO?> GetUserById(int id)
        {
            if (id <= 0) return null;
            return await _api.GetUserByIdAsync(id);
        }

        public async Task<SuccessMessageResponseIdDTO> AddUser(AddNewUserDTO dto)
        {
            if (dto == null) return new SuccessMessageResponseIdDTO(false, 0, "Invalid DTO");
            return await _api.AddUserAsync(dto);
        }

        public async Task<SuccessMessageResponseDTO?> UpdateUser(int id, UpdateUserDTO dto)
        {
            if (id <= 0 || dto == null) return null;
            return await _api.UpdateUserAsync(id, dto);
        }

        public async Task<bool> DeleteUser(int id)
        {
            if (id <= 0) return false;
            return await _api.DeleteUserAsync(id);
        }

        public async Task<SuccessMessageResponseDTO?> ChangePassword(int UserID, string newPassword)
        {
            if (UserID <= 0 || string.IsNullOrEmpty(newPassword)) return null;
            return await _api.ChangePassword(UserID, newPassword);
        }

        public async Task<SuccessMessageResponseDTO?> VerifyCurrentPassword(int UserID, string password)
        {
            if (UserID <= 0 || string.IsNullOrEmpty(password)) return null;
            return await _api.VerifyCurrentPassword(UserID, password);
        }
    }
}