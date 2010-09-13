using System;
using System.IO;
using EDM.Generator.Engine;


namespace EDM.Generator
{
    public static class EntryPoint
    {
        public static void Generate(String threedFilePath, string genResultPath, GeneratorTarget target, GeneratorEnvironment environment)
        {
            IEngine engine = EngineFactory.GetEngine(target);

            engine.SetThreeDFile(threedFilePath);

            engine.SetTransform(); 
            engine.SetOutput(genResultPath);
            engine.Generate();
        }
    }
}
