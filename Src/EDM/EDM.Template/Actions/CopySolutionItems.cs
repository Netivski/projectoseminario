#region Using Directives

using System;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using EnvDTE80;
using EDM.Template.Utils;

#endregion

namespace EDM.Template.Actions
{
    class CopySolutionItemsAction : Microsoft.Practices.RecipeFramework.Action
    {
        #region Input Properties

        //[Input(Required = true)]
        //public string Source { get; set; }

        //[Input(Required = true)]
        //public string Destination { get; set; }

        #endregion

        #region IAction Members

        public override void Execute()
        {
            List<String> schemaLoc = new List<String>()
                {
                    @"3D\3dvalidator.xsd", @"3d\entities\entityValidator.xsd",
                    @"3d\types\typeModelValidator.xsd", @"3d\environments\environmentValidator.xsd"
                };

            List<String> asmLoc = new List<string>()
                {
                    @"Assembly\EDM.FoundationClasses.dll", @"Assembly\Iesi.Collections.dll",
                    @"Assembly\Iesi.Collections.license.txt", @"Assembly\Iesi.Collections.xml",
                    @"Assembly\log4net.dll", @"Assembly\log4net.license.txt",
                    @"Assembly\log4net.xml", @"Assembly\NHibernate.dll",
                    @"Assembly\NHibernate.license.txt", @"Assembly\nunit.framework.dll",
                    @"Assembly\NUnitAsp.dll", @"Assembly\Rhino.Mocks.dll",
                    @"Assembly\Rhino.Mocks.xml"
                };

            Assembly execAsm = Assembly.GetExecutingAssembly();
            DTE vs = GetService<DTE>();

            string asmDirectory = Path.Combine(Path.GetDirectoryName(execAsm.Location), @"Solution Items");
            string solutionDirectory = Path.GetDirectoryName((string)vs.Solution.Properties.Item("Path").Value);

            //Copy the validator files and include them in the solution
            Project folder3D = ProjectFinder.GetProject(vs, "3D");

            foreach (String file in schemaLoc)
            {
                File.Copy(
                    Path.Combine(asmDirectory, file),
                    Path.Combine(solutionDirectory, file)
                );
                folder3D.ProjectItems.AddFromFile(Path.Combine(solutionDirectory, file));
                vs.ActiveWindow.Close(EnvDTE.vsSaveChanges.vsSaveChangesNo);
            }

            //Copy the external assemblies and include them in the solution
            Project folderAsm = ProjectFinder.GetProject(vs, "Assembly");

            foreach (String file in asmLoc)
            {
                File.Copy(
                    Path.Combine(asmDirectory, file),
                    Path.Combine(solutionDirectory, file)
                );
                folderAsm.ProjectItems.AddFromFile(Path.Combine(solutionDirectory, file));
                vs.ActiveWindow.Close(EnvDTE.vsSaveChanges.vsSaveChangesNo);
            }

        }

        public override void Undo()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}