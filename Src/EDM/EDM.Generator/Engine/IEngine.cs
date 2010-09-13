using System;

namespace EDM.Generator.Engine
{
    internal interface IEngine
    {
        void Generate();
        void SetThreeDFile(string ThreeDFilePath);
        void SetTransform();
        void SetOutput(string resultDirectory);
    }
}
