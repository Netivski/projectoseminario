#region Using Directives

using System;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;
using EDM.Template.Utils;

#endregion

namespace EDM.Template.Actions
{
    public class SynchronizeMetadataAction : Microsoft.Practices.RecipeFramework.Action
    {
        #region Input Properties

        [Input(Required = true)]
        public string AppCompany { get; set; }

        [Input(Required = true)]
        public string AppProject { get; set; }

        #endregion

        #region IAction Members

        public override void Execute()
        {
            DTE vs = GetService<DTE>(true);
            string solutionPath = (string)vs.Solution.Properties.Item("Path").Value;
            string solutionDir = Path.GetDirectoryName(solutionPath);

            string EDMFilePath = Path.Combine(solutionDir, @"3D\3D.xml");

            StartTime = DateTime.Now;

            EDM.Generator.EntryPoint.Generate(
                EDMFilePath,
                solutionDir,
                EDM.Generator.GeneratorTarget.CSharp,
                EDM.Generator.GeneratorEnvironment.EDMBase
            );

            UpdateProject(vs, "Rtti");
            UpdateProject(vs, "Entity");

            Project domainObjects = ProjectFinder.GetProject(vs, ProjectSufix + "." + "Entity");
            System.Windows.Forms.MessageBox.Show(domainObjects.GetType().Assembly.FullName);
        }

        public override void Undo()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region SynchronizeMetadataAction Private Members

        private DateTime StartTime { get; set; }

        private String ProjectSufix
        {
            get { return AppCompany + "." + AppProject; }
        }

        private void UpdateProject(DTE vs, String projectName)
        {
            //Include files in project with pattern "AppCompany.AppProject.projectName"

            Project targetProject = ProjectFinder.GetProject(vs, ProjectSufix + "." + projectName);
            string projectPath = Path.GetDirectoryName(targetProject.FullName + "\\");
            foreach (String fileName in Directory.GetFiles(
                                Path.GetDirectoryName(projectPath),
                                "*.*",
                                SearchOption.AllDirectories))
            {
                if (File.GetLastWriteTime(fileName).CompareTo(StartTime) > 0)
                {
                    targetProject.ProjectItems.AddFromFile(fileName);
                }
            }
        }

        #endregion

    }
}
