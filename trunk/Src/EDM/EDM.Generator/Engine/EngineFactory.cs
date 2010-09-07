using System;
using EDM.Generator.Exception;

namespace EDM.Generator.Engine
{
    internal static class EngineFactory
    {
        public static IEngine GetEngine(GeneratorTarget target)
        {
            switch (target)
            {
                case GeneratorTarget.CSharp:
                    return new CSharpEngine(target);
                default:
                    throw new TargetNotImplementedException(target);
            }
        }

    }
}
