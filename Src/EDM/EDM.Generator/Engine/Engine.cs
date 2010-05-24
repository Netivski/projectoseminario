using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using EDM.Generator.Exception;
using EDM.Generator.Context;


namespace EDM.Generator.Engine
{
    internal abstract class Engine: IEngine
    {
        readonly GeneratorContext context = null;

        public Engine(String edmFilePath, String resultDirectory)        
        {
            context = new GeneratorContext(edmFilePath, Path.Combine(Environment.CurrentDirectory, @"..\..\EDM.Generator\XSLT"), resultDirectory);
        }

    }
}
