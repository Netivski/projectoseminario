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

        public string RttiBasePath
        {
            get { return Path.Combine(RttiProjectPath, "Base"); }
        }

        public string EntityProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Entity")); }
        }

        public string EntityDataPath
        {
            get { return Path.Combine(resultDirectory.FullName, Path.Combine(EntityProjectPath, "Data")); }
        }

        public string EntityDataBasePath
        {
            get { return Path.Combine(EntityDataPath, "Base"); }
        }

        public string EntityDomainPath
        {
            get { return Path.Combine(resultDirectory.FullName, Path.Combine(EntityProjectPath, "Domain")); }
        }

        public string PersistencePath
        {
            get { return EntityDomainPath; }
        }

        public string EntityDataInterfacesPath
        {
            get { return Path.Combine(resultDirectory.FullName, Path.Combine(EntityProjectPath, "DataInterfaces")); }
        }

        public string EntityDataInterfacesBasePath
        {
            get { return Path.Combine(EntityDataInterfacesPath, "Base"); }
        }        

        public string FeProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Fe")); }
        }

        public string ServicesProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Services")); }
        }

        public string Services
        {
            get { return ServicesProjectPath; }
        }

        public string ServicesBase
        {
            get { return Path.Combine(Services, "Base"); }
        }

        public string WsProjectPath
        {
            get { return Path.Combine(resultDirectory.FullName, string.Format("{0}.{1}", nameSpace, "Ws")); }
        }

        public string WsAsmx
        {
            get { return WsProjectPath; }
        }
        
        public string WsAsmxCs
        {
            get { return WsProjectPath; }
        }

        public string WsBase
        {
            get { return Path.Combine(WsProjectPath, "Base"); }
        }

    }
}
