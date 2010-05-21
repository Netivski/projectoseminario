using System;
using EDM.Generator.Exception;

namespace EDM.Generator.Context
{
    internal class GeneratorContext
    {
        readonly EDMFile   edmFile   = null;
        readonly Transform transform = null;
        readonly Output    output    = null;

        public GeneratorContext(string edmFilePath, string xsltPath, string resultDirectory)
        {
            edmFile   = new EDMFile(edmFilePath);
            transform = new Transform(xsltPath);
            output    = new Output(resultDirectory);
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
    }
}
