namespace DVLDShared.DTOs.Users
{
    public class AddNewUserDTO
    {
        public AddNewUserDTO(
            int personID,
            string userName,
            string password,
            bool isActive)
        {
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }

        public int PersonID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}