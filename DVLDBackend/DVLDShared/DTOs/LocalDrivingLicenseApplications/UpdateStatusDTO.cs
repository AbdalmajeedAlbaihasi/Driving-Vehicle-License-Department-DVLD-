using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.LocalDrivingLicenseApplications
{
    public class UpdateStatusDTO
    {
        public UpdateStatusDTO(int applicationId, byte newStatus)
        {
            ApplicationId = applicationId;
            NewStatus = newStatus;
        }

        public int ApplicationId { get; set; }
        public byte NewStatus { get; set; }
    }
}
