namespace DVLDShared.DTOs.Applications
{
    public class GetApplicationByLocalDrivingLicenseApplicationIdDTO
    {
        public GetApplicationByLocalDrivingLicenseApplicationIdDTO(int applicationId, int personId, byte applicationStatus, decimal paidFees, string applicationTypeTitle,
             string applicant, DateTime applicationDate, DateTime lastStatusDate, string createdByUser)
        {
            this.ApplicationId = applicationId;
            this.PersonId = personId;
            this.ApplicationStatus = applicationStatus;
            this.PaidFees = paidFees;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.Applicant = applicant;
            this.ApplicationDate = applicationDate;
            this.LastStatusDate = lastStatusDate;
            this.CreatedByUser = createdByUser;
        }
        public int ApplicationId { get; set; }
        public int PersonId { get; set; }
        public byte ApplicationStatus { get; set; }
        public decimal PaidFees { get; set; }
        public string ApplicationTypeTitle { get; set; } = null!;
        public string Applicant { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public string CreatedByUser { get; set; }

    }
}
