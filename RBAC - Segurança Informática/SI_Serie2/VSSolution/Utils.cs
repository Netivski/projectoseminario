using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSSolution
{
    public class Utils
    {
        const char CHAR_SEP = ' ';

        public static String IntersectStrings(String src, String dest)
        {
            IEnumerable<String> res = src.Split(CHAR_SEP).Intersect(dest.Split(CHAR_SEP));
            if (res.Count() != 0)
            {
                String ret = null;
                foreach (String s in res)
                    ret += (s + CHAR_SEP);
                return ret;
            }
            return null;
        }

        public static String UnionStrings(String src, String dest)
        {
            IEnumerable<String> res = src.Split(CHAR_SEP).Union(dest.Split(CHAR_SEP));
            if (res.Count() != 0)
            {
                String ret = null;
                foreach (String s in res)
                    ret += (s + CHAR_SEP);
                return ret;
            }
            return null;
        }
    }
}
