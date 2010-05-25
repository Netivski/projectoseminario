using System;
using EDM.Generator.Context;

namespace EDM.Generator.Engine
{
    internal class EDMParserStep: AbstractStep 
    {
        public override void GenerateStep( GeneratorContext context )
        {
            //Alterar o DOM do context.EDMFile.Content 

            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.Root, "Paulo", "Jorge");
        }
    }
}
