using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.TestType
{
    public class AddNewTestTypeDTO
    {
        public AddNewTestTypeDTO( string testTypeTitle, string description, decimal testFees)
        {
            TestTypeTitle = testTypeTitle;
            Description = description;
            TestFees = testFees;
        }
        public string TestTypeTitle { get; set; }
        public string Description { get; set; }
        public decimal TestFees { get; set; }
    }
}
