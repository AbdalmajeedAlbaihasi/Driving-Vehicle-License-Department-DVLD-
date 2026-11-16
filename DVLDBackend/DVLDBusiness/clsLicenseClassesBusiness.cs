using DVLDDataAccess;
using DVLDShared.DTOs.LicenseClass;
using DVLDShared.DTOs.TestType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLDBusiness
{
    public class clsLicenseClassesBusiness
    {
        private readonly clsLicenseClassesDataAccess clsLicenseClassesDataAccess;
        public clsLicenseClassesBusiness(clsLicenseClassesDataAccess clsLicenseClassesDataAccess)
        {
            this.clsLicenseClassesDataAccess = clsLicenseClassesDataAccess;
        }

        public async Task<List<LicenseClassesNameDTO>> GetAllLicenseClassesNameAsync()
        {
            return await clsLicenseClassesDataAccess.GetAllLicenseClassesNameAsync();
        }


    }
}
