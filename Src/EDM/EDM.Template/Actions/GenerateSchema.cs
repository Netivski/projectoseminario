#region Using Directives

using System;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;

#endregion

namespace EDM.Template.Actions
{
    public class GenerateSchemaAction : Microsoft.Practices.RecipeFramework.Action
    {
        public override void Execute()
        {            
            GetService<DTE>(true).ExecuteCommand("Build.BuildSolution", String.Empty);
        }

        public override void Undo() { throw new NotImplementedException(); }
    }
}
