using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Configuration;
using EDM.Generator.Exception;

namespace EDM.Generator
{
    internal class Generator : IGenerator
    {
        private String _destFolder;
        private readonly String _xmlFileLocation;
        private readonly String _xsltBag;
        private readonly XslCompiledTransform _transformer;
        
        private readonly IDictionary<String, String> _xsltDictionary;

        public Generator(String xmlFileLocation, String xsltBag)
        {   
            if (!File.Exists(xmlFileLocation))
                throw new NotExpectedException( string.Format( "Unable to locate the specified file. - {0}", xmlFileLocation));            

            _xmlFileLocation = xmlFileLocation;                        
            _xsltBag = xsltBag;

            DirectoryInfo dInfo = new DirectoryInfo(_xsltBag);
            _xsltDictionary = (from f in dInfo.GetFiles() select f).ToDictionary();
            
            _transformer = new XslCompiledTransform();
        }

        #region IGenerator Members

        public void Generate(string destFolder)
        {
            _destFolder = destFolder + "\\";

            XmlDocument doc = new XmlDocument();
            doc.Load(_xmlFileLocation);

            //XmlNodeList list = doc.GetElementsByTagName("userTypes");

            //if(list.Count > 0)
            //    generateType(list[0]);

            XmlNodeList list = doc.GetElementsByTagName("entity");
            foreach (XmlNode entityNode in list)
            {
                GenerateEntity(entityNode);
            }

            
        }

        #endregion

        public void GenerateType(XmlNode typeNode)
        {
            _transformer.Load(_xsltDictionary["Types"]);
            _transformer.Transform(typeNode, new XmlTextWriter( Path.Combine(_destFolder, "UserTypeMetadata.cs"), Encoding.UTF8));
        }

        public void GenerateEntity(XmlNode entityNode)
        {
            _transformer.Load(_xsltDictionary["Entities"]);
            _transformer.Transform(entityNode, new XmlTextWriter(  Path.Combine( _destFolder, string.Concat( entityNode.Attributes["name"].Value, ".cs")) , Encoding.UTF8));
        }
    }
}
