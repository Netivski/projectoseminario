using System;
using System.IO;
using System.Xml;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class EDMFile
    {
        readonly FileInfo    edmFile = null;
        readonly XmlDocument content = null;
        readonly EDMXPath    xPath   = null;

        public EDMFile( string filePath ) 
        {
            if (!File.Exists(filePath)) throw new EDMFileNotFoundException(filePath);

            try
            {
                edmFile = new FileInfo(filePath);
                content = new XmlDocument();
                content.Load(filePath);
                xPath   = new EDMXPath();
            }
            catch (System.Exception e)
            {
                throw new UnexpectedException(e); 
            }
        }

        public string FullName
        {
            get { return edmFile.FullName; }
        }

        public string Name
        {
            get { return edmFile.Name; }
        }

        public string DirectoryFullName
        {
            get { return edmFile.Directory.FullName; }
        }

        public XmlDocument Content
        {
            get { return content; }
        }

        public EDMXPath XPath
        {
            get { return xPath; }
        }
    }
}
