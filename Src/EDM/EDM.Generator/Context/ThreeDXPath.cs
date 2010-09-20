﻿using System;

namespace EDM.Generator.Context
{
    internal class ThreeDXPath
    {
        public ThreeDXPath() { }

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
        public string EntitiesRelations
        {
            get
            {
                return string.Concat(Entities, "/relations");
            }
        }
        public string EntitiesRelation
        {
            get
            {
                return string.Concat(EntitiesRelations, "/relation");
            }
        }
        public string EntitiesRelationOneToMany
        {
            get
            {
                return string.Concat(EntitiesRelation, "[@type = 'OneToMany']");
            }
        }
        public string EntitiesRelationManyToOne
        {
            get
            {
                return string.Concat(EntitiesRelation, "[@type = 'ManyToOne']");
            }
        }
        public string EntitiesRelationManyToMany
        {
            get
            {
                return string.Concat(EntitiesRelation, "[@type = 'ManyToMany']");
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
        public string ManyToOneRelation
        {
            get
            {
                return "//manyToOne";
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
        public string EntityNotAbstract
        {
            get
            {
                return string.Concat(Entity,"[@type != 'abstract' and @type != 'abstractdependent']");
            }
        }
    }
}
