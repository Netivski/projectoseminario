#region Using Directives

using System;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Xml;
using EnvDTE80;
using EDM.Template.Utils;
using VSLangProj;

#endregion

namespace EDM.Template.Actions
{
    class CopySolutionItemsAction : Microsoft.Practices.RecipeFramework.Action
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
            Assembly execAsm = Assembly.GetExecutingAssembly();
            DTE vs = GetService<DTE>();

            string asmDirectory = Path.Combine(Path.GetDirectoryName(execAsm.Location), @"Solution Items");
            string solutionDirectory = Path.GetDirectoryName((string)vs.Solution.Properties.Item("Path").Value);

            DoCopy(vs, asmDirectory, solutionDirectory, "3D");
            DoCopy(vs, asmDirectory, solutionDirectory, "Assembly");

            UpdateDictionaryHeader(
                Path.Combine(solutionDirectory, @"3d\3d.xml"), solutionDirectory
            );
        }

        public override void Undo()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region CopySolutionItemsAction Private Members
        private void UpdateDictionaryHeader(String filePath, String solutionDirectory)
        {
            XmlDocument data = new XmlDocument();
            data.Load(Path.Combine(solutionDirectory, @"3d\3d.xml"));
            XmlNode root = data.SelectSingleNode("solution");
            root.Attributes["companyName"].Value = AppCompany;
            root.Attributes["projectName"].Value = AppProject;
            data.Save(Path.Combine(solutionDirectory, @"3d\3d.xml"));
        }

        private void DoCopy(DTE m_application, String srcLocation, String destLocation, String folderName)
        {
            m_application.StatusBar.Text = "Starting copy of solution folder '" + folderName + "' items";

            String sourceDir = Path.Combine(srcLocation, folderName);
            String targetDir = Path.Combine(destLocation, folderName);

            Project targetProj = ProjectFinder.GetProject(m_application, folderName);

            foreach (String file in Directory.GetFiles(sourceDir))
            {
                File.Copy(
                    Path.GetFullPath(file),
                    Path.Combine(targetDir, Path.GetFileName(file)),
                    true
                );
                targetProj.ProjectItems.AddFromFile(Path.Combine(targetDir, Path.GetFileName(file)));
                m_application.ActiveWindow.Close(EnvDTE.vsSaveChanges.vsSaveChangesNo);
            }

            m_application.StatusBar.Text = "Copy of solution folder '" + folderName + "' items finished!";
            m_application.StatusBar.Highlight(true);
        }
        #endregion
    }
}
