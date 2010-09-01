using System;
using System.Reflection;
using System.IO;
using System.Xml;


namespace EDM.Generator.Utils
{
    internal class EmbeddedResourceResolver : XmlUrlResolver
    {
        const string NAME_SPACE = "EDM.Generator.XSLT.";

        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(string.Concat( NAME_SPACE, Path.GetFileName(absoluteUri.AbsolutePath)));
        }
    }
}
