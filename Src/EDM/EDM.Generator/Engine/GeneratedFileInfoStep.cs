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
                                                    new GeneratedFileInfo( "Types"               , Path.Combine( context.Output.RttiProjectPath   , "UserTypeMetadata.cs"      ), context.EDMFile.XPath.UserTypes )
                                                   ,new GeneratedFileInfo( "Entity"              , Path.Combine( context.Output.EntityProjectPath , "{0}.cs"                   ), context.EDMFile.XPath.Entity    )
                                                   ,new GeneratedFileInfo( "IDaoFactory"         , Path.Combine( context.Output.EntityProjectPath , "IDaoFactory.cs"           ), "/"                             )
                                                   ,new GeneratedFileInfo( "NHibernateDaoFactory", Path.Combine( context.Output.EntityProjectPath , "NHibernateDaoFactory.cs"  ), "/"                             )     
                                                   ,new GeneratedFileInfo( "NHibernateMapping"   , Path.Combine( context.Output.EntityProjectPath , "{0}.hbm.xml"              ), context.EDMFile.XPath.Entity    )                                                                                                      
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
                    Utils.TemplateHelper.Render(node, context.Transform.GetTemplateFile(file.TemplateName), file.GetOutputFile( Utils.XML.Get.GetAttributeValue( context.EDMFile.Content, node, "generatedFileName" )));
                }
            }
        }
    }
}
