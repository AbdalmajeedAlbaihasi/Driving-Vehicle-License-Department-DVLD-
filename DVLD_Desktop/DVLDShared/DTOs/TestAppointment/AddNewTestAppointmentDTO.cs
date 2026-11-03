using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.TestAppointment
{
    public class AddNewTestAppointmentDTO
    {
       public  AddNewTestAppointmentDTO(int testTypeId,int LocalDrivingLicenseApplicationId,DateTime AppointmentDate,
           decimal PaidFees,int CreatedByUserId )
        {
        this.TestTypeId = testTypeId;
        this.LocalDrivingLicenseApplicationId = LocalDrivingLicenseApplicationId;
        this.AppointmentDate = AppointmentDate;
        this.PaidFees = PaidFees;
            this.CreatedByUserId = CreatedByUserId;
        }

        public int TestTypeId { get; set; }
        public int LocalDrivingLicenseApplicationId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserId { get; set; }
    }

   

}
