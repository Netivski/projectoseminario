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
            if( !Directory.Exists( baseDirectory ) ) throw new InvalidTransformDirectoryException( baseDirectory );

            this.baseDirectory = new DirectoryInfo( baseDirectory ); 

        }

        public void Render(XmlNode node, string xsltName, string outputFilePath)
        {
            XslCompiledTransform transformer = new XslCompiledTransform();
            transformer.Load( Path.Combine( baseDirectory.FullName, string.Concat(xsltName, ".xslt") ) );

            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(outputFilePath, Encoding.UTF8);
                transformer.Transform(node, writer);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                }
            }




        }
    }
}
