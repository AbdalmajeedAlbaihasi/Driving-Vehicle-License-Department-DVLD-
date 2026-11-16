namespace DVLDShared.DTOs.LocalDrivingLicenseApplications
{
    public class LocalDrivingLicenseApplicationListDTO
    {
        public LocalDrivingLicenseApplicationListDTO(
            int lDLAppID,
            string drivingClass,
            string nationalNo,
            string fullName,
            DateTime applicationDate,
            int passedTests,
            string status)
        {
            this.LDLAppID = lDLAppID;
            this.DrivingClass = drivingClass;
            this.NationalNo = nationalNo;
            this.FullName = fullName;
            this.ApplicationDate = applicationDate;
            this.PassedTests = passedTests;
            this.Status = status;
        }

        public int LDLAppID { get; set; }
        public string DrivingClass { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PassedTests { get; set; }
        public string Status { get; set; }
    }
}