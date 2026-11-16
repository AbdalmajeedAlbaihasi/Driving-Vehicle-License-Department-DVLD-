using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.TestAppointment
{
    public class TestAppointmentDTO
    {
        public int TestAppointmentId { get; set; }
        public int TestTypeId { get; set; }
        public int LocalDrivingLicenseApplicationId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserId { get; set; }
        public bool IsLocked { get; set; }




        public TestAppointmentDTO(int testAppointmentId, int testTypeId, int localDrivingLicenseApplicationId,
            DateTime appointmentDate, decimal paidFees, int createdByUserId, bool isLocked)
        {
            TestAppointmentId = testAppointmentId;
            TestTypeId = testTypeId;
            LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserId = createdByUserId;
            IsLocked = isLocked;
        }
    }
}
