using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IRN_DataLayer
    {
        bool AddUsersToRoles(string[] usernames, string[] roleNames);
        bool CreateRole(string roleName);
        bool DeleteRole(string roleName, bool throwOnPopulatedRole);
        string[] FindUsersInRole(string roleName, string usernameToMatch);
        string[] GetAllRoles();
        string[] GetRolesForUser(string username);
        string[] GetUsersInRole(string roleName);
        bool IsUserInRole(string username, string roleName);
        bool RemoveUsersFromRoles(string[] usernames, string[] roleNames);
        bool RoleExists(string roleName);
        
        bool CreatePermission(string permissionName);
        bool DeletePermission(string permission, bool throwOnPopulatedPerm);
        string[] GetPermissionsForRole(string roleName);
        string[] GetRolesWithPermission(string permissionName);
        bool RoleHavePermission(string roleName, string permissionName);        
        bool RemoveRolesFromPermissions(string[] roleNames, string[] permissionNames);
        string[] GetRoleHierarchy(string roleName);
    }
}
