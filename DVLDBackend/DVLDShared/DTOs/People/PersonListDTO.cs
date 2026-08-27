using System;

namespace DVLDShared.DTOs.People
{
    public class PersonListDTO
    {
        public PersonListDTO(
            int personID,
            string nationalNo,
            string firstName,
            string secondName,
            string thirdName,
            string lastName,
            int gendor,
            DateTime dateOfBirth,
            string nationality,
            string phone,
            string email)
        {
            this.PersonID = personID;
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.Gendor = gendor;
            this.DateOfBirth = dateOfBirth;
            this.Nationality = nationality;
            this.Phone = phone;
            this.Email = email;
        }

        public int PersonID { get; set; }

        public string NationalNo { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string LastName { get; set; }

        public int Gendor { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}