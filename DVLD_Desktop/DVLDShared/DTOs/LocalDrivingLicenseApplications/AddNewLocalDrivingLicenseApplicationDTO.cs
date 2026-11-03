using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.LocalDrivingLicenseApplications
{
    public class AddNewLocalDrivingLicenseApplicationDTO
    {
        public AddNewLocalDrivingLicenseApplicationDTO(
            int personID,
            DateTime applicationDate,
            int lisansClassID,
            decimal applicationsFees,
            int createdBy)
        {
            this.PersonID = personID;
            this.ApplicationDate = applicationDate;
            this.LisansClassID = lisansClassID;
            this.ApplicationsFees = applicationsFees;
            this.CreatedBy = createdBy;
        }

        public int PersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int LisansClassID { get; set; }
        public decimal ApplicationsFees { get; set; }
        public int CreatedBy { get; set; }
    }
}