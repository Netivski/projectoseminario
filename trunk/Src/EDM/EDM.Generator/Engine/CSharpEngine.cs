using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml;

namespace EDM.Generator.Engine
{
    internal class CSharpEngine: Engine
    {
        List<AbstractStep> steps = null;
       
        public CSharpEngine(GeneratorTarget target, GeneratorEnvironment environment): base(target, environment) { }

        void SetSteps()
        {
            steps = new List<AbstractStep>(){
                                                new EDMParserStep()
                                               ,new GeneratedFileInfoStep()
                                            };       
        }

        public override void Generate()
        {
            if (steps == null)
            {
                SetSteps();
            }
            steps.ForEach( step => step.GenerateStep( Context ) ); 
        }
    }
}
