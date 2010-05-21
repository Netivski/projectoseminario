using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EDM.Generator
{
    public static class ExtensionMethods
    {
        public static IDictionary<String, String> ToDictionary(this IEnumerable<FileInfo> list)
        {
            IDictionary<String, String> retDic = new Dictionary<String, String>();
            foreach (FileInfo fi in list)
                retDic.Add(fi.Name.Remove(fi.Name.Length - 5), fi.FullName);
            return retDic;
        }
        
    }
}
