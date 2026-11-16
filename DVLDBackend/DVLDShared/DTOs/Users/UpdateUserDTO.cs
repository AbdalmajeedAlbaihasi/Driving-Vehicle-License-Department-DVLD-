namespace DVLDShared.DTOs.Users
{
    public class UpdateUserDTO
    {
        public UpdateUserDTO(
            int userID,
            string userName,
            bool isActive)
        {
            UserID = userID;
            UserName = userName;
            IsActive = isActive;
        }

        public int UserID { get; set; }

        public string UserName { get; set; }


        public bool IsActive { get; set; }
    }
}