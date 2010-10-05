#region Using Directives

using System;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;
using EDM.Template.Utils;
using VSLangProj;
using System.Collections.Generic;

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
            DTE m_application = GetService<DTE>(true);
            string solutionPath = (string)m_application.Solution.Properties.Item("Path").Value;
            string solutionDir = Path.GetDirectoryName(solutionPath);

            string threedFilePath = Path.Combine(solutionDir, @"3D\3D.xml");

            StartTime = DateTime.Now;

            m_application.StatusBar.Text = "Starting code generation...";

            EDM.Generator.EntryPoint.Generate(
                threedFilePath,
                solutionDir,
                EDM.Generator.GeneratorTarget.CSharp,
                EDM.Generator.GeneratorEnvironment.EDMBase
            );

            m_application.StatusBar.Text = "Code generation finished!";
            m_application.StatusBar.Highlight(true);
            
            UpdateProject(m_application, "Rtti");
            UpdateProject(m_application, "Entity");
            UpdateProject(m_application, "Services");
            UpdateProject(m_application, "Ws");
            UpdateProject(m_application, "UnitTest");

            m_application.StatusBar.Text = "Synchronization finished!";
            m_application.StatusBar.Highlight(true);
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

        private void UpdateProject(DTE m_application, String projectName)
        {
            //Include files in project with pattern "AppCompany.AppProject.projectName"

            Project targetProject = ProjectFinder.GetProject(m_application, ProjectSufix + "." + projectName);
            string projectPath = Path.GetDirectoryName(targetProject.FullName + "\\");

            m_application.StatusBar.Text = "Updating project '" + projectName + "' files...";

            foreach (String fileName in Directory.GetFiles(
                                Path.GetDirectoryName(projectPath),
                                "*.*",
                                SearchOption.AllDirectories))
            {
                if (File.GetLastWriteTime(fileName).CompareTo(StartTime) > 0)
                {
                    targetProject.ProjectItems.AddFromFile(fileName);

                    if (fileName.EndsWith(".hbm.xml"))
                    {
                        //Deal with NHibernate mappings
                        m_application.Solution.FindProjectItem(fileName)
                            .Properties.Item("BuildAction").Value = prjBuildAction.prjBuildActionEmbeddedResource;
                    }
                    else if (fileName.EndsWith(".cfg.xml"))
                    {
                        //Deal with NHibernate configuration file
                        m_application.Solution.FindProjectItem(fileName)
                            .Properties.Item("BuildAction").Value = prjBuildAction.prjBuildActionNone;
                        m_application.Solution.FindProjectItem(fileName)
                            .Properties.Item("CopyToOutputDirectory").Value = 1;
                    }
                }
            }
        }
        #endregion

    }
}
