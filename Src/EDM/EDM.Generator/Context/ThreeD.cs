using System;
using System.IO;
using System.Xml;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class ThreeD
    {
        readonly FileInfo    threedFile = null;
        readonly XmlDocument content    = null;
        readonly ThreeDXPath    xPath      = null;

        public ThreeD( string filePath ) 
        {
            if (!File.Exists(filePath)) throw new ThreeDNotFoundException(filePath);

            try
            {
                threedFile = new FileInfo(filePath);
                content    = new XmlDocument();
                content.Load(filePath);
                xPath      = new ThreeDXPath();
            }
            catch (System.Exception e)
            {
                throw new UnexpectedException(e); 
            }
        }

        public string FullName
        {
            get { return threedFile.FullName; }
        }

        public string Name
        {
            get { return threedFile.Name; }
        }

        public string DirectoryFullName
        {
            get { return threedFile.Directory.FullName; }
        }

        public XmlDocument Content
        {
            get { return content; }
        }

        public ThreeDXPath XPath
        {
            get { return xPath; }
        }

        public string CompanyName
        {
            get
            {
                return Utils.XML.Get.GetAttributeValue(Content, xPath.Solution, "companyName");
            }
        }

        public string ProjectName
        {
            get
            {
                return Utils.XML.Get.GetAttributeValue(Content, xPath.Solution, "projectName");
            }
        }


        public string NameSpace
        {
            get
            {
                return string.Format("{0}.{1}", CompanyName, ProjectName);
            }
        }

        public string BaseName
        {
            get
            {
                return NameSpace;
            }
        }    
    }
}
