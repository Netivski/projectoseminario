using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml;

namespace EDM.Generator.Engine
{
    internal class CSharpEngine: Engine
    {
        List<GeneratedFileInfo> steps = null;

        public CSharpEngine(GeneratorTarget target, GeneratortEnvironment environment): base(target, environment)
        {
            steps = new List<GeneratedFileInfo>(){
                                                    new GeneratedFileInfo( "Types"   , Path.Combine( Context.Output.RttiProjectPath, "{0}.cs" ), Context.EDMFile.XPath.UserTypes )
                                                   ,new GeneratedFileInfo( "Entities", Path.Combine( Context.Output.EntityProjectPath, "{0}.cs" ), Context.EDMFile.XPath.Entities )
                                                 };       

        }

        public override void Generate()
        {
            // .: Falta definir o atributo que tem o nome do ficheiro :.  

            foreach (GeneratedFileInfo fileInfo in steps) 
            {
                XmlNodeList nodes = Context.EDMFile.Content.SelectNodes(fileInfo.XPath);
                foreach (XmlNode node in nodes)
                {
                    Utils.TemplateHelper.Render(node, Context.Transform.GetTemplateFile(fileInfo.TemplateName), fileInfo.GetOutputFile(node.Attributes[""].InnerText));
                }                                               
            }
        }

    }
}
