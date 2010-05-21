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
                return "/EDM";
            }
        }
        public string UserTypes
        {
            get
            {
                return string.Concat(Root, "/userTypes");
            }
        }
        public string Entities
        {
            get
            {
                return string.Concat(Root, "/entities");
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
