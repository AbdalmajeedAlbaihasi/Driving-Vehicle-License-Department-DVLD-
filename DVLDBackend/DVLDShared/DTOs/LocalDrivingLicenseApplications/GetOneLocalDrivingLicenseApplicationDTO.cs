namespace DVLDShared.DTOs.LocalDrivingLicenseApplications
{
    public class GetOneLocalDrivingLicenseApplicationDTO
    {
        public GetOneLocalDrivingLicenseApplicationDTO(int lDLAppID,string drivingClass,int passedTests)
        {
            this.LDLAppID = lDLAppID;
            this.DrivingClass = drivingClass;
            this.PassedTests = passedTests;
        }

        public int LDLAppID { get; set; }
        public string DrivingClass { get; set; }
        public int PassedTests { get; set; }
    }
}