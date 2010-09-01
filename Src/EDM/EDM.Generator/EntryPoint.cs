﻿using System;
using System.IO;
using EDM.Generator.Engine;


namespace EDM.Generator
{
    public static class EntryPoint
    {
        public static void Generate(String edmFilePath, string genResultPath, GeneratorTarget target, GeneratorEnvironment environment)
        {
            IEngine engine = EngineFactory.GetEngine(target, environment);

            engine.SetEDMFile(edmFilePath);

            engine.SetTransform(); 
            engine.SetOutput(genResultPath);
            engine.Generate();
        }
    }
}
