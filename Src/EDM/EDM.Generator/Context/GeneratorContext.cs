using System;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class GeneratorContext
    {

        //readonly GeneratorTarget       target;     
        //readonly GeneratorEnvironment environment;

        EDMFile   edmFile   = null;        
        Transform transform = null;
        Output    output    = null;

        public GeneratorContext() { }

        //public Transformer(GeneratorTarget target, GeneratorEnvironment environment)
        public GeneratorContext(EDMFile edmFile, Transform transform, Output output)
        {                                    
            //this.target      = target;
            //this.environment = environment;
            this.edmFile = edmFile;
            this.transform = transform;
            this.output = output;
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

        //public GeneratorTarget Target
        //{
        //    get
        //    {
        //        return target;
        //    }
        //}

        //public GeneratorEnvironment Environment
        //{
        //    get
        //    {
        //        return environment;
        //    }
        //}

        public void SetEDMFile(string edmFilePath)
        {
            edmFile = new EDMFile(edmFilePath);
        }

        public void SetTransform(  )
        {
            transform = new Transform();
        }

        public void SetOutput(string resultDirectory, string nameSpace)
        {
            output = new Output(resultDirectory, nameSpace);
        }
    }
}
