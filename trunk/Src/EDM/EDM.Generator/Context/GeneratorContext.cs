using System;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class GeneratorContext
    {
        ThreeD    threedFile = null;        
        Transform transform  = null;
        Output    output     = null;

        public GeneratorContext() { }

        public GeneratorContext(ThreeD threedFile, Transform transform, Output output)
        {                                    
            this.threedFile = threedFile;
            this.transform = transform;
            this.output = output;
        }

        public ThreeD ThreeDFile
        {
            get
            {
                return threedFile;
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

        public void SetThreeDFile(string threedFilePath)
        {
            threedFile = new ThreeD(threedFilePath);
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
