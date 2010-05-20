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
using Exception_lib;

namespace Generator
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
                throw new NotExpectedException("Unable to locate the specified file. - " + xmlFileLocation);            

            _xmlFileLocation = xmlFileLocation;                        
            _xsltBag = xsltBag;

            DirectoryInfo dInfo = new DirectoryInfo(_xsltBag);
            _xsltDictionary = (from f in dInfo.GetFiles() select f).ToDictionary();
            
            _transformer = new XslCompiledTransform();
        }

        #region IGenerator Members

        public void generate(string destFolder)
        {
            _destFolder = destFolder + "\\";

            XmlDocument doc = new XmlDocument();
            doc.Load(_xmlFileLocation);

            XmlNodeList list = doc.GetElementsByTagName("userTypes");

            if(list.Count > 0)
                generateType(list[0]);

            //list = doc.GetElementsByTagName("entity");
            //foreach (XmlNode entityNode in list)
            //{
            //    generateEntity(entityNode);
            //}

            
        }

        #endregion

        public void generateType(XmlNode typeNode)
        {
            _transformer.Load(_xsltDictionary["Types"]);
            _transformer.Transform(typeNode, new XmlTextWriter(_destFolder + "UserTypeMetadata.cs", Encoding.UTF8));
        }

        public void generateEntity(XmlNode entityNode)
        {
            _transformer.Load(_xsltDictionary["Entities"]);
            _transformer.Transform(entityNode, new XmlTextWriter(_destFolder + entityNode.Attributes["name"].Value + ".cs", Encoding.UTF8));
        }
    }
}
