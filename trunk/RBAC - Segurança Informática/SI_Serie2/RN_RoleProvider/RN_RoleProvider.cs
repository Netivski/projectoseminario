using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using DataLayer;

namespace RN_RoleProvider
{   
    public class RN_RoleProvider : System.Web.Security.RoleProvider
    {
        IRN_DataLayer _data = RN_DataFactory.getInstance(ConfigurationManager.AppSettings["DataType"]);

        #region "RoleProvider"

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            if (usernames.Length == 0 || roleNames.Length == 0)
            {
                throw new ArgumentException();
            }
            if (!_data.AddUsersToRoles(usernames, roleNames))
                throw new Exception("Unable to add the specified users to the specified roles.");
        }
        public override string ApplicationName
        {
            get
            {
                return AppDomain.CurrentDomain.FriendlyName;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override void CreateRole(string roleName)
        {
            if (!_data.CreateRole(roleName))
                throw new Exception("Unable to create the specified role.");
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return _data.DeleteRole(roleName, throwOnPopulatedRole);
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return _data.FindUsersInRole(roleName, usernameToMatch);
        }
        public override string[] GetAllRoles()
        {
            return _data.GetAllRoles();
        }
        public override string[] GetRolesForUser(string username)
        {
            return _data.GetRolesForUser(username);
        }
        public override string[] GetUsersInRole(string roleName)
        {
            return _data.GetUsersInRole(roleName);
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            return _data.IsUserInRole(username, roleName);
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            if (usernames.Length == 0 || roleNames.Length == 0)
            {
                throw new ArgumentException();
            }
            if (!_data.RemoveUsersFromRoles(usernames, roleNames))
                throw new Exception("Unable to add the specified users to the specified roles.");
        }
        public override bool RoleExists(string roleName)
        {
            return _data.RoleExists(roleName);
        }

        #endregion

        public void CreatePermission(string permission)
        {
            _data.CreatePermission(permission);
        }
        public bool DeletePermission(string permission, bool throwOnPopulatedPerm)
        {
            return _data.DeletePermission(permission, throwOnPopulatedPerm);
        }
        public string[] GetPermissionsForRole(string roleName)
        {
            return _data.GetPermissionsForRole(roleName);
        }
        public string[] GetRolesWithPermission(string permissionName)
        {
            return _data.GetRolesWithPermission(permissionName);
        }
        public bool RoleHavePermission(string roleName, string permissionName)
        {
            return _data.RoleHavePermission(roleName, permissionName);
        }        
        public bool RemoveRolesFromPermissions(string[] roleNames, string[] permissionNames)
        {
            return _data.RemoveRolesFromPermissions(roleNames, permissionNames);
        }
        public String[] GetRoleHierarchy(String roleName)
        {
            return _data.GetRoleHierarchy(roleName);
        }
    }        
}
