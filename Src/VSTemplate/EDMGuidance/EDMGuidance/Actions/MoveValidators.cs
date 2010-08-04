#region Using Directives

using System;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;
using System.IO;

#endregion

namespace EDM.Guidance.Actions
{
    class MoveValidatorsAction : Action
    {
        #region Input Properties

        [Input]
        public string RTTIProjectName
        {
            get { return rttiName; }
            set { rttiName = value; }
        } string rttiName;

        #endregion

        #region IAction Members

        public override void Execute()
        {
            DTE vs = GetService<DTE>();
            string solutionDirectory = Path.GetDirectoryName((string)vs.Solution.Properties.Item("Path").Value);
            //string _3DPath = Path.Combine(solutionDirectory, RTTIProjectName + @"\3D");
            //System.Windows.Forms.MessageBox.Show(RTTIProjectName, "Project Name");
            //System.Windows.Forms.MessageBox.Show(solutionDirectory, "Solution Dir");
            //System.Windows.Forms.MessageBox.Show(Path.Combine(_3DPath, @"\3dvalidator.xsd"));
            //vs.ItemOperations.AddExistingItem(Path.Combine(_3DPath, @"\3dvalidator.xsd"));
            //vs.ActiveWindow.Close(EnvDTE.vsSaveChanges.vsSaveChangesNo);
        }

        public override void Undo()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
