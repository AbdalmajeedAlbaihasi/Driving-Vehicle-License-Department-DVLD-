using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.Test
{
    public class AddNewTestDTO
    {
        public int TestAppointmentId { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserId { get; set; }

        public AddNewTestDTO() { }

        public AddNewTestDTO(int testAppointmentId, bool testResult, string notes, int createdByUserId)
        {
            TestAppointmentId = testAppointmentId;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserId = createdByUserId;
        }
    }
}
