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
        public string OneToOneRelation
        {
            get
            {
                return "//oneToOne";
            }
        }
        public string OneToManyRelation
        {
            get
            {
                return "//oneToMany";
            }
        }
        public string ManyToManyRelation
        {
            get
            {
                return "//manyToMany";
            }
        }
        public string BusinessProcesses
        {
            get
            {
                return string.Concat(Solution, "/businessProcesses");
            }
        }
        public string Component
        {
            get
            {
                return string.Concat(BusinessProcesses, "/component");
            }
        }
        public string BusinessProcess
        {
            get
            {
                return string.Concat(Component, "/businessProcess");
            }
        }
    }
}
