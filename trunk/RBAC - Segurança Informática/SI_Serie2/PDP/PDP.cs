using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Principal;
using RN_RoleProvider;

namespace PDP
{
    public class PermissionChecker
    {
        public static bool CheckUserPermission(IPrincipal principal, String permissionName)
        {
            String[] rolesWithPermission = RN_Role_Provider_Manager.GetRoleProvider().GetRolesWithPermission(permissionName);
            foreach (String s in rolesWithPermission)
            {
                if (principal.IsInRole(s))
                    return true;
            }
            String[] roles = RN_Role_Provider_Manager.GetRoleProvider().GetRolesForUser(principal.Identity.Name);
            foreach (String role in roles)
            {
                String[] rolesHierarchy = RN_Role_Provider_Manager.GetRoleProvider().GetRoleHierarchy(role);
                foreach (String newRole in rolesHierarchy)
                {
                    if (rolesWithPermission.Contains(newRole))
                        return true;
                }
            }
            return false;
        }
    }
}
