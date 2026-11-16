namespace DVLDShared.DTOs.TestType
{
    public class TestTypeDTO
    {
        public TestTypeDTO(int testTypeId , string testTypeTitle,string description, decimal testFees)
        {
            TestTypeId = testTypeId;
            TestTypeTitle = testTypeTitle;
            Description = description;  
            TestFees = testFees;
        }
        public int TestTypeId { get; set; }
        public string TestTypeTitle { get; set; }
        public string Description { get; set; }
        public decimal TestFees { get; set; }
    }
}
