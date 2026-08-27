namespace DVLDShared.DTOs.Users
{
    public class UpdateUserDTO
    {
        public UpdateUserDTO(
            int userID,
            int personID,
            string userName,
            string password,
            bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }

        public int UserID { get; set; }
        public int PersonID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}