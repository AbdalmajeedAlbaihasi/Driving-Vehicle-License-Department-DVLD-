using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs
{
    public class SuccessMessageResponseIdDTO
    {
        public SuccessMessageResponseIdDTO(bool success, int id, string message)
        {
            Success = success;
            ID = id;
            Message = message;
        }
        public bool Success { get; set; }
        public int ID { get; set; }
        public string Message { get; set; }
    }
}
