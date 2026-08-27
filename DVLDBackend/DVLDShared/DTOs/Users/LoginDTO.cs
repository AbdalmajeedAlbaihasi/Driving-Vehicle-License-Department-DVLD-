namespace DVLDShared.DTOs.Users
{
    public class LoginDTO
    {
        public LoginDTO(
            string userName,
            string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}