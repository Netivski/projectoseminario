using System;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace EDM.FoundationClasses.Security.Permissions
{
    internal class RuntimePermission : IPermission, IUnrestrictedPermission, ISecurityEncodable
    {
        public PermissionState PermissionState { get; protected set; }

        public String Name { get; protected set; }

        public bool Unrestricted
        {
            get { return PermissionState == PermissionState.Unrestricted; }
        }

        public RuntimePermission(String name)
        {
            Name = name;
        }

        public RuntimePermission(PermissionState state): this( state, string.Empty ) {}

        internal RuntimePermission(PermissionState state, string name)
        {
            PermissionState = state; 
            Name            = name;
        }


        RuntimePermission VerifyTypeMatch(IPermission target)
        {
            //if( !( target is RuntimePermission ) ) throw new ... Alterar a implementação
            if (GetType() != target.GetType()) throw new ArgumentException( String.Format("Target permission must be of the {0} type.", GetType().FullName) );

            return (RuntimePermission)target;
        }

        #region IPermission Members

        public IPermission Copy()
        {
            return new RuntimePermission(PermissionState, Name);
        }

        public void Demand()
        {
            if (IsUnrestricted()) return;

            if (RuntimePermissionChecker.HasPermission(Thread.CurrentPrincipal, this))  return;

            throw new SecurityException(string.Format("{0} does not have {1} permission", Thread.CurrentPrincipal.Identity.Name, Name) );
        }

        public IPermission Intersect(IPermission target)
        {
            if (target == null) return null;

            RuntimePermission custom = VerifyTypeMatch(target);

            //In case both permissions are unrestrictered return an unrestrictered one
            if (this.IsUnrestricted() && custom.IsUnrestricted()) return new RuntimePermission(PermissionState.Unrestricted);

            return Utils.IntersectRuntimePermission(this, custom);
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

            return Utils.UnionRuntimePermission(this, custom);
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
