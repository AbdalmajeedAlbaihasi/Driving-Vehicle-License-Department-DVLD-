namespace DVLDShared.DTOs.Nationality
{
    public class NationalityListDTO
    {
        public NationalityListDTO(int nationalityID, string nationalityName)
        {
            NationalityID = nationalityID;
            NationalityName = nationalityName;
        }

        public int NationalityID { get; set; }
        public string NationalityName { get; set; }
    }
}
