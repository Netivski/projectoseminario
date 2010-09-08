using System;
using System.Web.Security;

namespace EDM.FoundationClasses.Security.Permissions
{
    public abstract class RuntimeRoleProvider : RoleProvider
    {
        public abstract void CreatePermission(string permission);
        public abstract bool DeletePermission(string permission, bool throwOnPopulatedPerm);
        public abstract string[] GetPermissionsForRole(string roleName);
        public abstract string[] GetRolesWithPermission(string permissionName);
        public abstract bool RoleHavePermission(string roleName, string permissionName);
        public abstract bool RemoveRolesFromPermissions(string[] roleNames, string[] permissionNames);
        public abstract String[] GetRoleHierarchy(String roleName);
    }
}
