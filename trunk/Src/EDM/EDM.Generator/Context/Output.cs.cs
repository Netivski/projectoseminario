using System;
using System.IO;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class Output
    {
        readonly DirectoryInfo resultDirectory = null;
        readonly string        nameSpace       = null; 

        public Output(string resultDirectory, string nameSpace )
        {
            if (!Directory.Exists(resultDirectory)) throw new InvalidOutputDirectoryException(resultDirectory);

            this.resultDirectory = new DirectoryInfo(resultDirectory);
            this.nameSpace       = nameSpace; 
        }

        public string RttiProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Rtti")); }
        }

        public string RttiBase
        {
            get { return Path.Combine(RttiProjectPath, "Base"); }
        }

        public string EntityProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Entity")); }
        }

        public string EntityDomainProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, Path.Combine(EntityProjectPath, "Domain")); }
        }

        public string FeProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Fe")); }
        }

        public string ServicesProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Services")); }
        }

        public string WsProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Ws")); }
        }

    }
}
