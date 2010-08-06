using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using EDM.Generator.Exception;
using System.Reflection;

namespace EDM.Generator.Context
{
    class EmbeddedResourceResolver : XmlUrlResolver
    {
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(
            "EDM.Generator.XSLT." + Path.GetFileName(absoluteUri.AbsolutePath));
        }
    }

    internal class Transform
    {
        //readonly DirectoryInfo baseDirectory = null;
        readonly string resourcePrefix;

        public Transform( string baseDirectory )
        {
            this.resourcePrefix = baseDirectory;
            //this.baseDirectory = new DirectoryInfo( baseDirectory );
            //if (!this.baseDirectory.Exists) throw new InvalidTransformDirectoryException(baseDirectory);
        }

        public XslCompiledTransform GetTemplateFile(string xsltName)
        {

            //Solução de leitura de resources em http://www.tkachenko.com/blog/archives/000653.html
            
            XslCompiledTransform transformer = new XslCompiledTransform();
            EmbeddedResourceResolver resolver = new EmbeddedResourceResolver();
            transformer.Load(xsltName + ".xslt", XsltSettings.TrustedXslt, resolver);



            //transformer.Load(
            //    XmlReader.Create(
            //        this.GetType().Assembly.GetManifestResourceStream(resourcePrefix + "." + xsltName + ".xslt")
            //    )
            //);

            //transformer.Load(Path.Combine(baseDirectory.FullName, string.Concat(xsltName, ".xslt")));

            return transformer;
        }
    }
}
