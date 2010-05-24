using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class Transform
    {
        readonly DirectoryInfo baseDirectory = null;

        public Transform( string baseDirectory )
        {
            this.baseDirectory = new DirectoryInfo( baseDirectory );
            if (!this.baseDirectory.Exists) throw new InvalidTransformDirectoryException(baseDirectory);
        }

        public XslCompiledTransform GetTemplateFile(string xsltName)
        {
            XslCompiledTransform transformer = new XslCompiledTransform();
            transformer.Load(Path.Combine(baseDirectory.FullName, string.Concat(xsltName, ".xslt")));

            return transformer;
        }
    }
}
