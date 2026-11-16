using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.LocalDrivingLicenseApplications
{
    public class LocalDrivingLicenseApplicationInfoDTO
    {
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public LocalDrivingLicenseApplicationInfoDTO()
        {
        }

        public LocalDrivingLicenseApplicationInfoDTO(
            int applicationID,
            int licenseClassID)
        {
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }
    }
}
