#region Using Directives

using System;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using EDM.Template.Utils;


#endregion

namespace EDM.Template.Actions
{
    public class GenerateSchemaAction : Microsoft.Practices.RecipeFramework.Action
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
            m_ApplicationObject = GetService<DTE>(true);
            m_BuildEvents = m_ApplicationObject.Events.BuildEvents;
            if (ACT_ON_BUILD)
            {
                m_BuildEvents.OnBuildProjConfigDone += new _dispBuildEvents_OnBuildProjConfigDoneEventHandler(m_BuildEvents_OnBuildProjConfigDone);
                GetService<DTE>(true).ExecuteCommand("Build.BuildSolution", String.Empty);
            }
            else
            {
                m_ApplicationObject.StatusBar.Text = "Schema generation is disabled.";
                m_ApplicationObject.StatusBar.Highlight(true);
            }
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GenerateSchema private members

        EnvDTE.DTE m_ApplicationObject;
        EnvDTE.BuildEvents m_BuildEvents;
        readonly Boolean ACT_ON_BUILD = true;

        void m_BuildEvents_OnBuildProjConfigDone(string Project, string ProjectConfig, string Platform, string SolutionConfig, bool Success)
        {
            string pName = AppCompany + "." + AppProject + ".Entity";

            if (Success && Path.GetDirectoryName(Project).Equals(pName))
            {
                m_ApplicationObject.StatusBar.Text =
                    "Schema generation starting."
                    + "This may take a while! Please be patient...";
                m_ApplicationObject.StatusBar.Highlight(false);

                string targetSolDir = Path.GetDirectoryName(
                    (string)m_ApplicationObject.Solution.Properties.Item("Path").Value
                );
                string targetCreateLocation = Path.Combine(targetSolDir, @"Persistence\dbSchemaCreate.sql");
                string targetUpdateLocation = Path.Combine(targetSolDir, @"Persistence\dbSchemaUpdate.sql");

                try
                {
                    DirectoryInfo d = new DirectoryInfo(
                        Path.Combine(targetSolDir, pName + @"\bin\" + ProjectConfig + @"\")
                    );

                    foreach (FileInfo f in d.GetFiles("*.dll"))
                    {
                        AppDomain.CurrentDomain.Load(Assembly.LoadFrom(f.FullName).GetName());
                    }

                    string hibernateCfg = Path.Combine(targetSolDir, AppCompany + "." + AppProject + @".Ws\hibernate.cfg.xml");
                    NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();

                    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

                    try { cfg.Configure(hibernateCfg); }
                    finally { AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve; }

                    //Schema Creation Script
                    SchemaExport sExport = new SchemaExport(cfg);
                    TextWriter createWriter = new StreamWriter(File.Create(targetCreateLocation));
                    sExport.Execute(txt => createWriter.WriteLine(txt), false, false);
                    createWriter.Close();

                    //Schema Update Script
                    SchemaUpdate sUpdate = new SchemaUpdate(cfg);
                    TextWriter updateWriter = new StreamWriter(File.Create(targetUpdateLocation));
                    sUpdate.Execute(txt => updateWriter.WriteLine(txt), false);
                    updateWriter.Close();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Exception caught while generating schema!\n" + e.InnerException.Message
                    );
                }
                finally
                {
                    m_BuildEvents.OnBuildProjConfigDone -= m_BuildEvents_OnBuildProjConfigDone;
                }
                Project targetProject = ProjectFinder.GetProject(m_ApplicationObject, "Persistence");
                targetProject.ProjectItems.AddFromFile(targetCreateLocation);
                targetProject.ProjectItems.AddFromFile(targetUpdateLocation);
                m_ApplicationObject.StatusBar.Text = "Schema generation completed successfuly!";
                m_ApplicationObject.StatusBar.Highlight(true);
            }
            else if (!Success)
            {
                m_ApplicationObject.StatusBar.Text =
                    "Schema generation failed to initialize due to project build error!";
                m_ApplicationObject.StatusBar.Highlight(true);
                m_BuildEvents.OnBuildProjConfigDone -= m_BuildEvents_OnBuildProjConfigDone;
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            AssemblyName aName = new AssemblyName(args.Name);
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (a.GetName().Name.Equals(aName.Name))
                    return a;
            }
            return null;
        }
        #endregion
    }
}
