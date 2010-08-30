using System;
using System.Text;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using PDP;

namespace VSSolution
{
    public class StringPermission : IPermission, IUnrestrictedPermission, ISecurityEncodable
    {

        #region CustomPermission members

        public String Name { get; private set; }
        private bool _unrestricted = false;

        public StringPermission(String name)
        {
            Name = name;
        }

        public StringPermission(PermissionState state)
        {
            _unrestricted = (state == PermissionState.Unrestricted ? true : false);
            Name = "";
        }

        private StringPermission VerifyTypeMatch(IPermission target)
        {
            if (GetType() != target.GetType())
            {
                throw new ArgumentException
                    (String.Format("Target permission must be of the {0} type.", GetType().FullName));
            }
            return (StringPermission)target;
        }

        #endregion

        #region IPermission Members

        public IPermission Copy()
        {
            PermissionState state = (IsUnrestricted() ? PermissionState.Unrestricted : PermissionState.None);
            StringPermission custom = new StringPermission(state);
            custom.Name = Name;
            return custom;
        }

        public void Demand()
        {
            if (IsUnrestricted())
                return;
            if (PDP.PermissionChecker.CheckUserPermission(Thread.CurrentPrincipal, Name))
                return;
            throw new SecurityException(Thread.CurrentPrincipal.Identity.Name + " does not have " + Name + " permission.");
        }

        public IPermission Intersect(IPermission target)
        {
            if (target == null) return null;

            StringPermission custom = VerifyTypeMatch(target);

            //In case both permissions are unrestrictered return an unrestrictered one
            if (this.IsUnrestricted() && custom.IsUnrestricted())
                return new StringPermission(PermissionState.Unrestricted);
            return new StringPermission(Utils.IntersectStrings(Name, custom.Name));
        }

        public bool IsSubsetOf(IPermission target)
        {
            if (target == null) return false;

            StringPermission custom = VerifyTypeMatch(target);

            if (custom.IsUnrestricted()) return true;
            if (this.IsUnrestricted()) return false;

            return (custom.Name.Contains(Name));
        }

        public IPermission Union(IPermission target)
        {
            if (target == null) return Copy();

            StringPermission custom = VerifyTypeMatch(target);

            if (this.IsUnrestricted() || custom.IsUnrestricted())
                return new StringPermission(PermissionState.Unrestricted);

            return new StringPermission(Utils.UnionStrings(Name, custom.Name));
        }

        #endregion

        #region IUnrestrictedPermission Members

        public bool IsUnrestricted()
        {
            return _unrestricted;
        }

        #endregion

        #region ISecurityEncodable Members

        void ISecurityEncodable.FromXml(SecurityElement e)
        {
            throw new NotImplementedException();
        }

        SecurityElement ISecurityEncodable.ToXml()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
