using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace DataLayer
{
    public class RN_DataLayer_Sql : IRN_DataLayer
    {
        private const String GET_ALL_ROLES = "spGetAllRoles";
        private const String ADD_USERS_TO_ROLES = "spAddUserToRoles";
        private const String CREATE_ROLE = "spCreateRole";
        private const String DELETE_ROLE = "spDeleteRole";
        private const String FIND_USERS_IN_ROLES = "spFindUsersInRoles";
        private const String DELETE_USER_ASSOCIATIONS = "spDeleteUsersAssociations";
        private const String GET_ROLES_FOR_USER = "spGetRolesForUser";
        private const String GET_USERS_IN_ROLE = "spGetUsersInRole";
        private const String IS_USER_IN_ROLE = "spIsUserInRole";
        private const String REMOVE_USERS_FROM_ROLES = "spRemoveUsersFromRoles";
        private const String ROLE_EXISTS = "spRoleExists";
        private const String CREATE_PERMISSION = "spCreatePermission";
        private const String DELETE_PERMISSION = "spDeletePermission";
        private const String DELETE_PERMISSIONS_ASSOCIATIONS = "spDeletePermissionsAssociations";
        private const String GET_PERMISSIONS_FOR_ROLE = "spGetPermissionsForRole";
        private const String GET_ROLES_WITH_PERMISSION = "spGetRolesWithPermission";
        private const String ROLE_HAVE_PERMISSION = "spRoleHavePErmission";
        private const String REMOVE_ROLES_FROM_PERMISSION = "spRemoveRolesFromPermission";
        private const String GET_ROLE_HIERARCHY = "spGetRoleHierarchy";

        public bool AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            SqlParameter[] paramCollection = new SqlParameter[2];
            foreach (String userName in usernames)
            {
                paramCollection[0] = new SqlParameter("@user", SqlDbType.VarChar);
                paramCollection[0].Value = userName;                
                foreach (String roleName in roleNames)
                {
                    paramCollection[1] = new SqlParameter("@role", SqlDbType.VarChar);
                    paramCollection[1].Value = roleName;                    
                    try
                    {
                        RN_DataTools.ExecuteCommand(ADD_USERS_TO_ROLES, paramCollection);                        
                    }
                    catch (SqlException){
                        return false;
                    }
                }                
            }
            return true;
        }
        public bool CreateRole(string roleName)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@role", SqlDbType.VarChar);
            param[0].Value = roleName;            
            try
            {
                RN_DataTools.ExecuteCommand(CREATE_ROLE, param);                
            }
            catch (SqlException){
                return false;
            }            
            return true;
        }
        public bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@role", SqlDbType.VarChar);
            param[0].Value = roleName;            

            if (throwOnPopulatedRole)
            {
                try
                {
                    RN_DataTools.ExecuteCommand(DELETE_ROLE, param);
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
            else
            {
                RN_DataTools.ExecuteCommand(DELETE_USER_ASSOCIATIONS, param);
                //É necessário criar um novo sqlParameter porque não é possível
                //utilizar o mesmo parameter em dois sqlCommands
                SqlParameter[] newParam = new SqlParameter[1];
                newParam[0] = new SqlParameter("@role", SqlDbType.VarChar);
                newParam[0].Value = roleName;
                RN_DataTools.ExecuteCommand(DELETE_ROLE, newParam);
                return true;
            }
        }
        public string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@role", SqlDbType.VarChar);
            param[0].Value = roleName;
            param[1] = new SqlParameter("@user", SqlDbType.VarChar);
            param[1].Value = usernameToMatch;            

            IDataReader reader = RN_DataTools.GetReader(FIND_USERS_IN_ROLES, param);
            ArrayList arrList = new ArrayList();
            while (reader.Read())
            {
                arrList.Add(reader.GetString(0));
            }
            reader.Close();

            return (String[])arrList.ToArray(Type.GetType("System.String"));
        }
        public string[] GetAllRoles()
        {
            IDataReader reader = RN_DataTools.GetReader(GET_ALL_ROLES, null);
            ArrayList arrList = new ArrayList();
            while (reader.Read())
            {
                arrList.Add(reader.GetString(0));
            }
            reader.Close();
            return (String[])arrList.ToArray(Type.GetType("System.String"));
        }
        public string[] GetRolesForUser(string username)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user", SqlDbType.VarChar);
            param[0].Value = username;

            IDataReader reader = RN_DataTools.GetReader(GET_ROLES_FOR_USER, param);
            ArrayList arrList = new ArrayList();
            while (reader.Read())
            {
                arrList.Add(reader.GetString(0));
            }
            reader.Close();
            return (String[])arrList.ToArray(Type.GetType("System.String"));
        }
        public string[] GetUsersInRole(string roleName)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@role", SqlDbType.VarChar);
            param[0].Value = roleName;

            IDataReader reader = RN_DataTools.GetReader(GET_USERS_IN_ROLE, param);
            ArrayList arrList = new ArrayList();
            while (reader.Read())
            {
                arrList.Add(reader.GetString(0));
            }
            reader.Close();
            return (String[])arrList.ToArray(Type.GetType("System.String"));
        }
        public bool IsUserInRole(string username, string roleName)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@user", SqlDbType.VarChar);
            param[0].Value = username;
            param[1] = new SqlParameter("@role", SqlDbType.VarChar);
            param[1].Value = roleName;

            IDataReader reader = RN_DataTools.GetReader(IS_USER_IN_ROLE, param);
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }
        public bool RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            SqlParameter[] param = new SqlParameter[2];
            foreach (String userName in usernames)
            {
                param[0] = new SqlParameter("@user", SqlDbType.VarChar);
                param[0].Value = userName;                
                foreach (String roleName in roleNames)
                {
                    param[1] = new SqlParameter("@role", SqlDbType.VarChar);
                    param[1].Value = roleName;                    
                    try
                    {
                        RN_DataTools.ExecuteCommand(REMOVE_USERS_FROM_ROLES, param);
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool RoleExists(string roleName)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@role", SqlDbType.VarChar);
            param[0].Value = roleName;          

            IDataReader reader = RN_DataTools.GetReader(ROLE_EXISTS, param);
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }
        
        public bool CreatePermission(string permissionName)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@permission", SqlDbType.VarChar);
            param[0].Value = permissionName;
            try
            {
                RN_DataTools.ExecuteCommand(CREATE_PERMISSION, param);
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }
        public bool DeletePermission(string permission, bool throwOnPopulatedPerm)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@permission", SqlDbType.VarChar);
            param[0].Value = permission;

            if (throwOnPopulatedPerm)
            {
                try
                {
                    RN_DataTools.ExecuteCommand(DELETE_PERMISSION, param);
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
            else
            {
                RN_DataTools.ExecuteCommand(DELETE_PERMISSIONS_ASSOCIATIONS, param);                
                SqlParameter[] newParam = new SqlParameter[1];
                newParam[0] = new SqlParameter("@permission", SqlDbType.VarChar);
                newParam[0].Value = permission;
                RN_DataTools.ExecuteCommand(DELETE_PERMISSION, newParam);
                return true;
            }
        }
        public String[] GetPermissionsForRole(string roleName)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@role", SqlDbType.VarChar);
            param[0].Value = roleName;

            IDataReader reader = RN_DataTools.GetReader(GET_PERMISSIONS_FOR_ROLE, param);
            ArrayList arrList = new ArrayList();
            while (reader.Read())
            {
                arrList.Add(reader.GetString(0));
            }
            reader.Close();
            return (String[])arrList.ToArray(Type.GetType("System.String"));
        }
        public string[] GetRolesWithPermission(string permissionName)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@permissionName", SqlDbType.VarChar);
            param[0].Value = permissionName;

            IDataReader reader = RN_DataTools.GetReader(GET_ROLES_WITH_PERMISSION, param);
            ArrayList arrList = new ArrayList();
            while (reader.Read())
            {
                arrList.Add(reader.GetString(0));
            }
            reader.Close();
            return (String[])arrList.ToArray(Type.GetType("System.String"));
        }
        public bool RoleHavePermission(string roleName, string permissionName)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@role", SqlDbType.VarChar);
            param[0].Value = roleName;
            param[1] = new SqlParameter("@permission", SqlDbType.VarChar);
            param[1].Value = permissionName;

            IDataReader reader = RN_DataTools.GetReader(ROLE_HAVE_PERMISSION, param);
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }        
        public bool RemoveRolesFromPermissions(string[] roleNames, string[] permissionNames)
        {
            SqlParameter[] param = new SqlParameter[2];
            foreach (String roleName in roleNames)
            {
                param[0] = new SqlParameter("@role", SqlDbType.VarChar);
                param[0].Value = roleName;
                foreach (String permissionName in permissionNames)
                {
                    param[1] = new SqlParameter("@permission", SqlDbType.VarChar);
                    param[1].Value = permissionName;
                    try
                    {
                        RN_DataTools.ExecuteCommand(REMOVE_ROLES_FROM_PERMISSION, param);
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public string[] GetRoleHierarchy(string roleName)
        {
            ArrayList arrList = new ArrayList();
            GetRoleHierarchy(roleName, arrList);            
            return (String[])arrList.ToArray(Type.GetType("System.String"));
        }
        private void GetRoleHierarchy(String roleName, ArrayList returnArr)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@seniorRole", SqlDbType.VarChar);
            param[0].Value = roleName;
            IDataReader reader = RN_DataTools.GetReader(GET_ROLE_HIERARCHY, param);
            while (reader.Read())
            {
                String role = reader.GetString(0);
                if(!returnArr.Contains(role))
                    returnArr.Add(role);
                GetRoleHierarchy(role, returnArr);
            }
            reader.Close();
        }
    }
}
