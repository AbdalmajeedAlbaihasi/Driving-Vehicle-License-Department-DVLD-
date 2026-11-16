using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.Test_Appointment
{
    public class FinishTestDTO
    {
        public FinishTestDTO(int TestAppointmentId, bool TestResult, string? Notes, int CreatedByUserId)
        {
            this.TestAppointmentId = TestAppointmentId;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserId = CreatedByUserId;
        }

        public int TestAppointmentId { get; set; }  
        public bool TestResult { get; set; }
        public string? Notes { get; set; } = null;
        public int CreatedByUserId { get; set; }
    }
}
