using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using EDM.Generator.Context;

namespace EDM.Generator.Engine
{
    internal class GeneratedFileInfoStep : AbstractStep
    {
        List<GeneratedFileInfo> files = null;

        void SetFiles(GeneratorContext context)
        {
            files = new List<GeneratedFileInfo>(){
                                                    new GeneratedFileInfo( "Types"    , Path.Combine( context.Output.RttiProjectPath   , "{0}.cs"  ), context.EDMFile.XPath.UserTypes )
                                                   ,new GeneratedFileInfo( "Entity"   , Path.Combine( context.Output.EntityProjectPath , "{0}.cs"  ), context.EDMFile.XPath.Entity )
                                                 };
        }

        public override void GenerateStep(GeneratorContext context)
        {
            SetFiles( context );

            foreach (GeneratedFileInfo file in files)
            {
                XmlNodeList nodes = context.EDMFile.Content.SelectNodes(file.XPath);
                foreach (XmlNode node in nodes)
                {
                    Utils.TemplateHelper.Render(node, context.Transform.GetTemplateFile(file.TemplateName), file.GetOutputFile(node.Attributes["generatedFileName"].InnerText));
                }
            }
        }
    }
}
