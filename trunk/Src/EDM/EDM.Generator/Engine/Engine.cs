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

        public Engine(GeneratorTarget target, GeneratorEnvironment environment)        
        {
            //context = new Transformer(  target ,environment );
            context = new GeneratorContext();
        }

        protected GeneratorContext Context { get { return context; } }

        public abstract void Generate();

        public void SetEDMFile(string edmFilePath)
        {
            context.SetEDMFile(edmFilePath);
        }

        public void SetTransform(string xsltPath)
        {
            context.SetTransform(xsltPath);
        }

        public void SetOutput(string resultDirectory)
        {

            if (context.EDMFile == null) throw new InvalidEDMStateException();

            context.SetOutput(resultDirectory, context.EDMFile.NameSpace);
        }

    }
}
