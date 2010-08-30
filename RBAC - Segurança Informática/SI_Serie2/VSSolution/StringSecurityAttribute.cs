using System;
using System.Security.Permissions;
using System.Text;
using System.Security;

namespace VSSolution
{
    [AttributeUsage (AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]    
    [Serializable]
    public sealed class StringSecurityAttribute : CodeAccessSecurityAttribute
    {

        #region CustomSecAttribute members

        private String _name = null;
        private bool _unrestricted = false;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public new bool Unrestricted
        {
            get { return _unrestricted; }
            set { _unrestricted = value; }
        }

        public StringSecurityAttribute(SecurityAction action) : base(action){ }

        #endregion

        #region CodeAccessSecurityAttribute Members
        
        public override IPermission CreatePermission()
        {
            if (_unrestricted)
                return new StringPermission(PermissionState.Unrestricted);
            return new StringPermission(_name);
        }

        #endregion

    }
}
