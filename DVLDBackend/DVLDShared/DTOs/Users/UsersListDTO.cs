using System;

namespace DVLDShared.DTOs.Users
{
    public class UsersListDTO
    {
        public UsersListDTO(
            int userID,
            int personID,
            string userName,
            bool isActive

            )
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.IsActive = isActive;
        }

        public int PersonID { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public bool IsActive { get; set; }

    }
}