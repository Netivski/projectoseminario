using System;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class GeneratorContext
    {
        ThreeD   edmFile   = null;        
        Transform transform = null;
        Output    output    = null;

        public GeneratorContext() { }

        public GeneratorContext(ThreeD edmFile, Transform transform, Output output)
        {                                    
            this.edmFile = edmFile;
            this.transform = transform;
            this.output = output;
        }

        public ThreeD EDMFile
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
            edmFile = new ThreeD(edmFilePath);
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
