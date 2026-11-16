namespace DVLDShared.DTOs.Users
{
    public class UserLoginDataDTO
    {
        public UserLoginDataDTO(
            int userID,
            string userName,
            string passwordHash,
            bool isActive)
        {
            UserID = userID;
            UserName = userName;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public bool IsActive { get; set; }
    }
}