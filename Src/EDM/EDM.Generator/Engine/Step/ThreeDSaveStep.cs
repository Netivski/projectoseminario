using System;
using System.IO;
using EDM.Generator.Context;

namespace EDM.Generator.Engine.Step
{
    internal class ThreeDSaveStep: AbstractStep 
    {      
        public override void Generate( GeneratorContext context )        
        {            
            context.ThreeDFile.Content.Save( Path.Combine(  Environment.GetEnvironmentVariable("temp"),  "ThreeD.xml") );
        }
    }
}
