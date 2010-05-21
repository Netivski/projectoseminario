using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using EDM.Generator.Exception;
using EDM.Generator.Context;

namespace EDM.Generator
{
    internal class Generator : IGenerator
    {
        readonly GeneratorContext context = null;       

        public Generator(String edmFilePath, String resultDirectory)        
        {
            context = new GeneratorContext(edmFilePath, Path.Combine(Environment.CurrentDirectory, @"..\..\EDM.Generator\XSLT"), resultDirectory);
        }

        #region IGenerator Members

        public void Generate()
        {

            //XmlNodeList list = doc.GetElementsByTagName("userTypes");

            //if(list.Count > 0)
            //    generateType(list[0]);

            //XmlNodeList list = doc.GetElementsByTagName("entity");
            //foreach (XmlNode entityNode in list)
            //{
            //    GenerateEntity(entityNode);
            //}

            
        }

        #endregion

        public void GenerateType(XmlNode typeNode)
        {
            //_transformer.Load(_xsltDictionary["Types"]);
            //_transformer.Transform(typeNode, new XmlTextWriter( Path.Combine(_destFolder, "UserTypeMetadata.cs"), Encoding.UTF8));
        }

        public void GenerateEntity(XmlNode entityNode)
        {
            //_transformer.Load(_xsltDictionary["Entities"]);
            //_transformer.Transform(entityNode, new XmlTextWriter(  Path.Combine( _destFolder, string.Concat( entityNode.Attributes["name"].Value, ".cs")) , Encoding.UTF8));
        }
    }
}
