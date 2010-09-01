using System;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class Transform
    {
        public XslCompiledTransform GetTemplateFile(string xsltName)
        {
            //Solução de leitura de resources em http://www.tkachenko.com/blog/archives/000653.html
            
            XslCompiledTransform transformer = new XslCompiledTransform();
            transformer.Load( string.Concat( xsltName, ".xslt" ), XsltSettings.TrustedXslt, new Utils.EmbeddedResourceResolver());

            return transformer;
        }
    }
}
