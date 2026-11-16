using System;

namespace DVLDShared.DTOs.Users
{
    public class UsersListDTO
    {
        public UsersListDTO(
            int userID,
            int personID,
            string fullName,
            string userName,
            bool isActive

            )
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.FullName = fullName;
            this.UserName = userName;
            this.IsActive = isActive;
        }

        public int PersonID { get; set; }

        public int UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }

        public bool IsActive { get; set; }

    }
}