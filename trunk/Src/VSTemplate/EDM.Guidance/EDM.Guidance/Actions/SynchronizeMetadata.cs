#region Using Directives

using System;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;

#endregion

namespace EDM.Guidance.Actions
{
    public class SynchronizeMetadataAction : Action
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

            EDM.Generator.EntryPoint.Generate(
                EDMFilePath,
                solutionDir,
                EDM.Generator.GeneratorTarget.CSharp,
                EDM.Generator.GeneratorEnvironment.EDMBase
            );

        }

        public override void Undo()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion


    }
}
