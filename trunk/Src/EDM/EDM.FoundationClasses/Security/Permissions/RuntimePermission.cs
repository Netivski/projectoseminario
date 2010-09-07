using System;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace EDM.FoundationClasses.Security.Permissions
{
    public class RuntimePermission : IPermission, IUnrestrictedPermission, ISecurityEncodable
    {
        public String Name { get; protected set; }

        public bool Unrestricted{ get; protected set; }

        public RuntimePermission(String name)
        {
            Name = name;
        }

        public RuntimePermission(PermissionState state): this( state, string.Empty ) {}

        protected RuntimePermission(PermissionState state, string name)
        {
            Unrestricted = state == PermissionState.Unrestricted;
            Name = name;
        }


        RuntimePermission VerifyTypeMatch(IPermission target)
        {
            // ????? tem que ser utilizado o 
            if (GetType() != target.GetType()) throw new ArgumentException( String.Format("Target permission must be of the {0} type.", GetType().FullName) );

            return (RuntimePermission)target;
        }


        #region IPermission Members

        public IPermission Copy()
        {
            return new RuntimePermission(IsUnrestricted() ? PermissionState.Unrestricted : PermissionState.None, Name);
        }

        public void Demand()
        {
            if (IsUnrestricted()) return;

            if (PDP.PermissionChecker.CheckUserPermission(Thread.CurrentPrincipal, Name))  return;

            throw new SecurityException(Thread.CurrentPrincipal.Identity.Name + " does not have " + Name + " permission.");
        }

        public IPermission Intersect(IPermission target)
        {
            if (target == null) return null;

            RuntimePermission custom = VerifyTypeMatch(target);

            //In case both permissions are unrestrictered return an unrestrictered one
            if (this.IsUnrestricted() && custom.IsUnrestricted()) return new RuntimePermission(PermissionState.Unrestricted);

            return new RuntimePermission(Utils.IntersectStrings(Name, custom.Name));
        }

        public bool IsSubsetOf(IPermission target)
        {
            if (target == null) return false;

            RuntimePermission custom = VerifyTypeMatch(target);

            if (custom.IsUnrestricted()) return true;
            if (this.IsUnrestricted()) return false;

            return (custom.Name.Contains(Name));
        }

        public IPermission Union(IPermission target)
        {
            if (target == null) return Copy();

            RuntimePermission custom = VerifyTypeMatch(target);

            if (this.IsUnrestricted() || custom.IsUnrestricted()) return new RuntimePermission(PermissionState.Unrestricted);

            return new RuntimePermission(Utils.UnionStrings(Name, custom.Name));
        }

        #endregion

        #region IUnrestrictedPermission Members

        public bool IsUnrestricted()
        {
            return Unrestricted;
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
