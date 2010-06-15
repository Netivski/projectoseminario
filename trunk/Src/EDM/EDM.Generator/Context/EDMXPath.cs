using System;

namespace EDM.Generator.Context
{
    internal class EDMXPath
    {
        public EDMXPath() { }

        public string Root
        {
            get
            {
                return "/";
            }
        }
        public string Solution
        {
            get
            {
                return string.Concat(Root, "solution");
            }
        }
        public string UserTypes
        {
            get
            {
                return string.Concat(Solution, "/userTypes");
            }
        }
        public string Entities
        {
            get
            {
                return string.Concat(Solution, "/entities");
            }
        }
        public string Entity
        {
            get
            {
                return string.Concat(Entities, "/entity");
            }
        }
        public string EntityFields
        {
            get
            {
                return "./fields";
            }
        }
    }
}
