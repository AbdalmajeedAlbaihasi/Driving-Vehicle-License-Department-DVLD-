namespace DVLDShared.DTOs.LicenseClass
{
    public class LicenseClassDTO
    {
        public LicenseClassDTO(int LicenseClassId, string ClassName ,decimal ClassFees)
        {
            this.LicenseClassId = LicenseClassId;
            this.ClassName = ClassName;
            this.ClassFees = ClassFees;
        }
        public int LicenseClassId { get; set; }
        public string ClassName { get; set; }
        public decimal ClassFees { get; set; }
    }
}
