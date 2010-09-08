﻿using System;
using System.Security.Permissions;
using System.Security;

namespace EDM.FoundationClasses.Security.Permissions
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    [Serializable]
    public sealed class RuntimeSecurityAttribute : CodeAccessSecurityAttribute
    {
        public String MethodName{ get;  set; }

        public RuntimeSecurityAttribute(SecurityAction action) : base(action) { }

        public override IPermission CreatePermission()
        {
            return Unrestricted ? new RuntimePermission(PermissionState.Unrestricted) : new RuntimePermission(MethodName);
        }
    }
}
