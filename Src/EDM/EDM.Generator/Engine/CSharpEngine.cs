using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using EDM.Generator.Engine.Step;

namespace EDM.Generator.Engine
{
    internal class CSharpEngine: Engine
    {
        List<AbstractStep> steps = null;
       
        public CSharpEngine(GeneratorTarget target): base(target) { }

        void SetSteps()
        {
            steps = new List<AbstractStep>(){
                                                new EDMParserStep()
                                               ,new GeneratorSteps()
                                            };       
        }

        public override void Generate()
        {
            if (steps == null)
            {
                SetSteps();
            }
            steps.ForEach( step => step.Generate( Context ) ); 
        }
    }
}
