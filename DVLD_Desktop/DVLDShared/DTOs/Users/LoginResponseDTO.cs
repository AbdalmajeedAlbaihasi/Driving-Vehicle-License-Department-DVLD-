namespace DVLDShared.DTOs.Users
{
    public class LoginResponseDTO
    {
        public LoginResponseDTO() { }
        public LoginResponseDTO(bool success, string message, int userID, bool isActive)
        {
            Success = success;
            Message = message;
            UserID = userID;
            IsActive = isActive;
        }

        public LoginResponseDTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; } 

        public string Message { get; set; }

        public int UserID { get; set; } = -1;

        public bool IsActive { get; set; }= false;
    }
}