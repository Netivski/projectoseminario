#region Using Directives

using System;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using System.Windows.Forms;
using System.Reflection;

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
                m_BuildEvents.OnBuildProjConfigDone += new _dispBuildEvents_OnBuildProjConfigDoneEventHandler(m_BuildEvents_OnBuildProjConfigDone);
            else
                System.Windows.Forms.MessageBox.Show("Schema not being generated!");
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
        readonly Boolean ACT_ON_BUILD = false;

        void m_BuildEvents_OnBuildProjConfigDone(string Project, string ProjectConfig, string Platform, string SolutionConfig, bool Success)
        {
            string pName = AppCompany + "." + AppProject + ".Entity";

            if (Success && Path.GetDirectoryName(Project).Equals(pName))
            {
                string targetSolDir = Path.GetDirectoryName(
                    (string)m_ApplicationObject.Solution.Properties.Item("Path").Value
                );
                try
                {
                    Assembly ent = Assembly.LoadFrom(
                        Path.Combine(targetSolDir, pName + @"\bin\" + ProjectConfig + @"\" + pName + ".dll")
                    );

                    string hibernateCfg = Path.Combine(targetSolDir, AppCompany + "." + AppProject + @".Ws\hibernate.cfg.xml");
                    NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
                    cfg.AddAssembly(ent);
                    cfg.Configure(hibernateCfg);

                    //Schema Creation Script
                    SchemaExport sExport = new SchemaExport(cfg);
                    TextWriter createWriter = new StreamWriter(
                        File.Create(
                            Path.Combine(targetSolDir, @"\Persistence\dbSchemaCreate.sql")
                        )
                    );
                    sExport.Execute(txt => createWriter.WriteLine(txt), false, false);
                    createWriter.Close();

                    //Schema Update Script
                    SchemaUpdate sUpdate = new SchemaUpdate(cfg);
                    sUpdate.Execute(txt => createWriter.WriteLine(txt), false);
                    TextWriter updateWriter = new StreamWriter(
                        File.Create(
                            Path.Combine(targetSolDir, @"\Persistence\dbSchemaUpdate.sql")
                        )
                    );
                    sUpdate.Execute(txt => updateWriter.WriteLine(txt), false);
                    updateWriter.Close();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Exception caught while generating schema!\n" + e.InnerException.Message
                    );
                }
                m_BuildEvents.OnBuildProjConfigDone -= m_BuildEvents_OnBuildProjConfigDone;
            }
            else if (!Success)
            {
                System.Windows.Forms.MessageBox.Show("Schema was not generated.");
                m_BuildEvents.OnBuildProjConfigDone -= m_BuildEvents_OnBuildProjConfigDone;
            }
        }
        #endregion
    }
}
