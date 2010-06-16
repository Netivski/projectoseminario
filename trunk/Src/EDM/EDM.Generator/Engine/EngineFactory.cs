using System;
using EDM.Generator.Exception;

namespace EDM.Generator.Engine
{
    internal static class EngineFactory
    {
        public static IEngine GetEngine(GeneratorTarget target, GeneratorEnvironment environment)
        {
            switch (target)
            {
                case GeneratorTarget.CSharp:
                    return new CSharpEngine(target, environment);
                default:
                    throw new TargetNotImplementedException(target);
            }
        }

    }
}
