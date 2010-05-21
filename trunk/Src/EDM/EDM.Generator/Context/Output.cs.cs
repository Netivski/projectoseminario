using System;
using System.IO;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class Output
    {
        readonly DirectoryInfo resultDirectory = null;

        public Output(string resultDirectory)
        {
            if (!Directory.Exists(resultDirectory)) throw new InvalidOutputDirectoryException(resultDirectory);

            this.resultDirectory = new DirectoryInfo(resultDirectory);
        }

        public string RttiProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, "GenRtti"); }
        }

        public string EntityProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, "GenEntity"); }
        }
    }
}
