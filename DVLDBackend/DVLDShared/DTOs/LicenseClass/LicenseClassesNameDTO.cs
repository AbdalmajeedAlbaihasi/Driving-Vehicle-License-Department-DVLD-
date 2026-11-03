using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDShared.DTOs.LicenseClass
{
    public class LicenseClassesNameDTO
    {
       public LicenseClassesNameDTO(int LicenseClassId, string ClassName)
        {
            this.LicenseClassId = LicenseClassId;
            this.ClassName = ClassName;
        }
        public int LicenseClassId { get; set; }
        public string ClassName { get; set; }
    }
}
