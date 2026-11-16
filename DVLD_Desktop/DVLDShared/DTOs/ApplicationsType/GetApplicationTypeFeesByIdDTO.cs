using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.ApplicationsType
{
    public class GetApplicationTypeFeesByIdDTO
    {
        public GetApplicationTypeFeesByIdDTO(bool success, decimal fees, string message)
        {
            Success = success;
            Fees = fees;
            Message = message;
        }
        public bool Success { get; set; }
        public decimal Fees { get; set; }
        public string Message { get; set; }
    }
}
