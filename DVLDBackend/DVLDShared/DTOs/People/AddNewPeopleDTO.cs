using System.Numerics;

namespace DVLDShared.DTOs.People
{
    public class AddNewPeopleDTO
    {
        public AddNewPeopleDTO(string nationalNo, string firstName, string secondName, string thirdName
                , string lastName, DateTime dateOfBirth, byte gendor, string address, string phone, string email,
                int nationalityCountryID, string imagePath)
        {
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.Gendor = gendor;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImagePath = imagePath;
        }

        public int PersonID { get; set; }

        public string NationalNo { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string LastName { get; set; }

        public byte Gendor { get; set; }
        public int NationalityCountryID { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
    }
}
