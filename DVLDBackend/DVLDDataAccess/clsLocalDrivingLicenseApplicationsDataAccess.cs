using System;
using DV;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccess
{
    public class clsLocalDrivingLicenseApplicationsDataAccess
    {
        private readonly DVLDContext _context;
        public clsLocalDrivingLicenseApplicationsDataAccess(DVLDContext context)
        {
            _context = context;
        }
    }
}
