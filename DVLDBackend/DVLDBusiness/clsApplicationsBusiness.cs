using System;
using DVLDDataAccess;
using DVLDShared.DTOs.Applications;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsApplicationsBusiness
    {
        private readonly clsApplicationsDataAccess _dataAccess;
        public clsApplicationsBusiness(clsApplicationsDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<(bool Success, string Message)> AddNewApplication(AddNewApplicationDTO applicationDTO)
        {
            if (applicationDTO == null)
            {
                return (false, "Application data is null.");
            }

            if(applicationDTO.ApplicationTypeId <= 0)
            {
                return (false, "Invalid Application Type ID.");
            }
            if(applicationDTO.ApplicantPersonID <= 0)
            {
                return (false, "Invalid Applicant Person ID.");
            }
            if(applicationDTO.ApplicationDate == default)
            {
                return (false, "Invalid Application Date.");
            }
            if(applicationDTO.ApplicationStatus < 0)
            {
                return (false, "Invalid Application Status.");
            }
            if(applicationDTO.PaidFees < 0)
            {
                return (false, "Paid Fees cannot be negative.");
            }
            if(applicationDTO.CreatedByUserID <= 0)
            {
                return (false, "Invalid Created By User ID.");
            }
            if(applicationDTO.LastStatusDate == default)
            {
                return (false, "Invalid Last Status Date.");
            }
            if
        }
