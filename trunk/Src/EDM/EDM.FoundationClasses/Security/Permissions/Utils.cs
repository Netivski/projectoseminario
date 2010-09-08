using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDM.FoundationClasses.Security.Permissions
{
    internal static class Utils
    {
        const char CHAR_SEP = ' ';

        public static RuntimePermission IntersectRuntimePermission(RuntimePermission a, RuntimePermission b)
        {
            return CreateRuntimePermission( a.Name.Split(CHAR_SEP).Intersect(b.Name.Split(CHAR_SEP)), a );
        }

        public static RuntimePermission UnionRuntimePermission(RuntimePermission a, RuntimePermission b)
        {
            return CreateRuntimePermission( a.Name.Split(CHAR_SEP).Union(b.Name.Split(CHAR_SEP)), a );
        }

        static RuntimePermission CreateRuntimePermission(IEnumerable<String> permissions, RuntimePermission basePermission)
        {
            RuntimePermission rPermission = null;
            if (permissions.Count() != 0)
            {
                StringBuilder ret = new StringBuilder();
                foreach (String s in permissions)
                {
                    ret.Append(s);
                    ret.Append(CHAR_SEP);
                }
                return new RuntimePermission( basePermission.PermissionState, ret.ToString() );
            }

            return rPermission;
        }
    }
}
