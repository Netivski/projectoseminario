using System;
using EDM.Generator.Context;

namespace EDM.Generator.Engine.Step
{
    internal abstract class AbstractStep
    {
        public abstract void Generate( GeneratorContext context );
    }
}
