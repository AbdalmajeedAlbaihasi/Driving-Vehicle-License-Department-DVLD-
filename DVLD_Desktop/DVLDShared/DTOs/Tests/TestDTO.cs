using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.Tests
{
    public class TestDTO
    {
        public int TestId { get; set; }
        public int TestAppointmentId { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserId { get; set; }

        public TestDTO() { }

        public TestDTO(int testId, int testAppointmentId, bool testResult, string notes, int createdByUserId)
        {
            TestId = testId;
            TestAppointmentId = testAppointmentId;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserId = createdByUserId;
        }
    }
}
