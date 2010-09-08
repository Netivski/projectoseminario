using System;
using System.Linq;
using System.Security.Principal;

namespace EDM.FoundationClasses.Security.Permissions
{
    //PDP
    internal class RuntimePermissionChecker 
    {
        public static bool HasPermission(IPrincipal principal, RuntimePermission permission)
        {
            RuntimeRoleProvider rrp = RuntimeRoleProviderFactory.GetRoleProvider();
            if (rrp == null) return true;

            String[] rolesWithPermission = rrp.GetRolesWithPermission(permission.Name);
            foreach (String s in rolesWithPermission) if (principal.IsInRole(s)) return true;
            
            String[] roles = rrp.GetRolesForUser(principal.Identity.Name);
            foreach (String role in roles)
            {
                String[] rolesHierarchy = rrp.GetRoleHierarchy(role);
                foreach (String newRole in rolesHierarchy) if (rolesWithPermission.Contains(newRole)) return true;                
            }

            return false;
        }
    }
}
