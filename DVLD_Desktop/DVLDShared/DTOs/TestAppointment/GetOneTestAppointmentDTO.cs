using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.TestAppointment
{
    public class GetOneTestAppointmentDTO
    {
        public int LocalDrivingLicenseApplicationId { get; set; }
        public string DrivingClass { get; set; } = string.Empty;
        public string PersonFullName { get; set; } = string.Empty;
        public int PassedTests { get; set; }
        public float ApplicationFees { get; set; }

        public GetOneTestAppointmentDTO(int localDrivingLicenseApplicationId, string drivingClass, string personFullName, int passedTests, float applicationFees)
        {
            LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            DrivingClass = drivingClass;
            PersonFullName = personFullName;
            PassedTests = passedTests;
            ApplicationFees = applicationFees;
        }

    }
}
