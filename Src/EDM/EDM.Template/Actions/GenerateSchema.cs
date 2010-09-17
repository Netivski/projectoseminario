#region Using Directives

using System;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using System.Windows.Forms;

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
            m_BuildEvents.OnBuildProjConfigDone += new _dispBuildEvents_OnBuildProjConfigDoneEventHandler(m_BuildEvents_OnBuildProjConfigDone);
            GetService<DTE>(true).ExecuteCommand("Build.BuildSolution", String.Empty);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GenerateSchema private members

        EnvDTE.DTE m_ApplicationObject;
        EnvDTE.BuildEvents m_BuildEvents;
        readonly bool ACT_ON_BUILD = false;

        void m_BuildEvents_OnBuildProjConfigDone(string Project, string ProjectConfig, string Platform, string SolutionConfig, bool Success)
        {
            if (Path.GetDirectoryName(Project)
                    .Equals(AppCompany + "." + AppProject + ".Entity"))
            {
                if (!ACT_ON_BUILD)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Database schema generation not available!",
                        AppCompany + "." + AppProject,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    string targetSolDir = Path.GetDirectoryName(
                        (string)m_ApplicationObject.Solution.Properties.Item("Path").Value
                    );
                    string hibernateCfg = Path.Combine(targetSolDir, AppCompany + "." + AppProject + @".Ws\hibernate.cfg.xml");

                    try
                    {
                        NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
                        cfg.Configure(hibernateCfg);

                        SchemaUpdate sUpdate = new SchemaUpdate(cfg);
                        TextWriter fileWriter = new StreamWriter(
                            File.Create(
                                Path.Combine(targetSolDir, @"\Persistence\dbSchema.sql")
                            )
                        );
                        sUpdate.Execute(txt => fileWriter.WriteLine(txt), false);
                        fileWriter.Close();
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(
                            "Schema not generated!\n" + e.InnerException.Message
                        );
                    }
                }
            }
            m_BuildEvents.OnBuildProjConfigDone -= m_BuildEvents_OnBuildProjConfigDone;
        }
        #endregion
    }
}
