using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.TestAppointment
{
    public class UpdateTestAppointmentDTO
    {
        public int TestAppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int TestTypeId { get; set; }
        public int LocalDrivingLicenseApplicationId { get; set; }

        public int CreatedByUserId { get; set; }
        public bool IsLocked { get; set; }
        public UpdateTestAppointmentDTO() { }


        public UpdateTestAppointmentDTO(int testAppointmentId, DateTime appointmentDate, 
            decimal paidFees , int testTypeId,
            int localDrivingLicenseApplicationId, int createdByUserId, bool isLocked )
        {
            TestAppointmentId = testAppointmentId;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            TestTypeId = testTypeId;
            LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            CreatedByUserId = createdByUserId;
            IsLocked = isLocked;
        }
    }
}
