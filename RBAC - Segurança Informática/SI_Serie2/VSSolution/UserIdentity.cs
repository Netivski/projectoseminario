using System;
using System.Text;
using System.Threading;
using System.Security.Principal;
using System.Web.Security;
using RN_RoleProvider;

namespace VSSolution
{
    public class UserIdentity : IPrincipal
    {

        #region UserIdentity Members

        IIdentity _id;
        String[] _roles;

        public UserIdentity(String name)
        {
            _id = new GenericIdentity(name);
            _roles = RN_Role_Provider_Manager.GetRoleProvider().GetRolesForUser(name);
        }        

        #endregion

        #region IPrincipal Members

        public IIdentity Identity
        {
            get { return _id; }
        }

        public bool IsInRole(string role)
        {
            foreach (String r in _roles)
                if (r.Equals(role)) return true;
            return false;
        }

        #endregion
    }
}
