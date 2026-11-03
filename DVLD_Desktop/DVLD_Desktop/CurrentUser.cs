using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8
{
    public static class CurrentUser
    {
        public static string? UserName { get; private set; } 
        public static int? UserId { get; private set; }

        public static void LoadCurrentUser(int? userId, string userName)
        {
            UserName = userName;
            UserId = userId;
        }

        public static void ClearCurrentUser()
        {
            UserName = "";
            UserId = 0;
        }
    }
}
