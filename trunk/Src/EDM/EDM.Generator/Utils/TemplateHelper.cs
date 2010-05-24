using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;

namespace EDM.Generator.Utils
{
    internal class TemplateHelper
    {
        public TemplateHelper()
        {
        }

        Encoding outputEncoding = Encoding.UTF8;

        public Encoding OutputEncoding
        {
            get { return outputEncoding; }
            set { outputEncoding = value; }
        }

        public void Render(XmlNode node, XslCompiledTransform template, string outputFilePath)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(outputFilePath, OutputEncoding);
                template.Transform(node, writer);
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
