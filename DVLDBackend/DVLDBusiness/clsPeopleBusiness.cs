using DVLDDataAccess;
using DVLDShared.DTOs.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DVLDDataAccess.clsPeopleDataAccess;

namespace DVLDBusiness
{
    public sealed class PeopleService
    {
        private readonly clsPeopleDataAccess _peopleDataAccess;

        public PeopleService(clsPeopleDataAccess peopleDataAccess)
        {
            _peopleDataAccess = peopleDataAccess;
        }

        public async Task<List<PersonListDto>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _peopleDataAccess.GetAllAsync(cancellationToken);
        }
    


















    public enum enMode { Add, Update };
        enMode Mode = enMode.Add;

        private int _PersonID;
        private string _NationalNo;
        private string _FirstName;
        private string _SecondName;
        private string _ThirdName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private int _Gendor;
        private string _Address;
        private string _CountryName;
        private string _Phone;
        private string _Email;
        private int _NationalityCountryID;
        private string _ImagePath;

        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }

        public string NationalNo
        {
            get { return _NationalNo; }
            set { _NationalNo = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string SecondName
        {
            get { return _SecondName; }
            set { _SecondName = value; }
        }

        public string ThirdName
        {
            get { return _ThirdName; }
            set { _ThirdName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        public int Gendor
        {
            get { return _Gendor; }
            set { _Gendor = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public int NationalityCountryID
        {
            get { return _NationalityCountryID; }
            set { _NationalityCountryID = value; }
        }

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }


        public clsPeopleBusiness()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = 0;
            this.ImagePath = "";
            Mode = enMode.Add;

        }

        private clsPeopleBusiness(string NationalNo, string FirstName, string SecondName, string ThirdName
            , string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }

        private bool _AddPeople()
        {
            this.PersonID = DVLD_DataAccess.clsPeople.AddPeople(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName
            , this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
            this.NationalityCountryID, this.ImagePath);

            return (this.PersonID > 0);
        }

        private bool _UpdatePeople()
        {
            return DVLD_DataAccess.clsPeople.UpdatePeople(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName
            , this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
            this.NationalityCountryID, this.ImagePath);
        }

        public bool save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddPeople())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePeople();
            }
            return false;
        }

        public static DataTable GetAllPeople()
        {
            return DVLD_DataAccess.clsPeople.GetAllPeople();
        }

        public static DataTable GetAllCountries()
        {
            return DVLD_DataAccess.clsPeople.GetAllCountries();
        }

        public bool FiendByNationalNoPeople()
        {
            return DVLD_DataAccess.clsPeople.FiendByNationalNoPeople(this.NationalNo);
        }

        public bool FiendByID()
        {
            return DVLD_DataAccess.clsPeople.GetPersonByID(this.PersonID, ref _NationalNo, ref _FirstName, ref _SecondName,
                                     ref _ThirdName, ref _LastName, ref _DateOfBirth, ref _Gendor,
                                     ref _Phone, ref _NationalityCountryID, ref _Email, ref _Address, ref _ImagePath);

        }

        public bool DeletePeople()
        {
            return DVLD_DataAccess.clsPeople.DeletePeople(this.PersonID);
        }
    }
}







