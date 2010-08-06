using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;

namespace EDM.Guidance.Utils
{
    public class ProjectFinder
    {
        public static Project GetProject(DTE dte, String name)
        {
            foreach (Project p in dte.Solution.Projects)
                if (p.Name.Equals(name))
                    return p;
            return null;
        }

        public static ProjectItem GetProjectItem(Project p, String itemName)
        {
            foreach (ProjectItem item in p.ProjectItems)
            {
                if (item.Name.Equals(itemName))
                    return item;
            }
            return null;
        }
    }
}
