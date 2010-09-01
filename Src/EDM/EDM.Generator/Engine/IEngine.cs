using System;

namespace EDM.Generator.Engine
{
    internal interface IEngine
    {
        void Generate();
        void SetEDMFile(string edmFilePath);
        void SetTransform();
        void SetOutput(string resultDirectory);
    }
}
