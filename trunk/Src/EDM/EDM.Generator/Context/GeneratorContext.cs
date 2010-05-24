using System;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class GeneratorContext
    {

        readonly GeneratorTarget       target;     
        readonly GeneratortEnvironment environment;

        EDMFile   edmFile   = null;        
        Transform transform = null;
        Output    output    = null;

        public GeneratorContext(GeneratorTarget target, GeneratortEnvironment environment)
        {                                    
            this.target      = target;
            this.environment = environment;
        }

        public EDMFile EDMFile
        {
            get
            {
                return edmFile;
            }
        }

        public Transform Transform
        {
            get
            {
                return transform;
            }
        }

        public Output Output
        {
            get
            {
                return output;
            }
        }

        public GeneratorTarget Target
        {
            get
            {
                return target;
            }
        }

        public GeneratortEnvironment Environment
        {
            get
            {
                return environment;
            }
        }

        public void SetEDMFile(string edmFilePath)
        {
            edmFile = new EDMFile(edmFilePath);
        }

        public void SetTransform( string xsltPath )
        {
            transform = new Transform(xsltPath);
        }

        public void SetOutput(string resultDirectory)
        {
            output = new Output(resultDirectory);
        }
    }
}
