using System;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.Web.Security;
using System.Collections;

namespace EDM.FoundationClasses.Security.Permissions
{
    internal static class RuntimeRoleProviderFactory
    {
        public static RuntimeRoleProvider GetRoleProvider()
        {
            return ( Roles.Enabled && Roles.Provider is RuntimeRoleProvider ) ? (RuntimeRoleProvider)Roles.Provider : null;
        }
    }
}