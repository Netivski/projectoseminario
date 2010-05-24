using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;

namespace EDM.Generator.Utils
{
    internal static class TemplateHelper
    {
        public static void Render(XmlNode node, XslCompiledTransform template, string outputFile, Encoding outputEncoding)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(outputFile, outputEncoding);
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

        public static void Render(XmlNode node, XslCompiledTransform template, string outputFile)
        {
            Render(node, template, outputFile, Encoding.UTF8);
        }
    }
}
