using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace RN_RoleProvider
{
    public class RN_Role_Provider_Manager
    {
        public static RN_RoleProvider GetRoleProvider()
        {
            return new RN_RoleProvider();
        }
    }
}
