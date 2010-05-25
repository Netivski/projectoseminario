using System;
using EDM.Generator.Context;

namespace EDM.Generator.Engine
{
    internal abstract class AbstractStep
    {
        public abstract void GenerateStep( GeneratorContext context );
    }
}
