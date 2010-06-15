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
                                                     new GeneratedFileInfo( "BaseTypes"            , Path.Combine( context.Output.RttiBase                , "BaseUserTypeMetadata.cs"  ), context.EDMFile.XPath.UserTypes, true  )
                                                    ,new GeneratedFileInfo( "Types"                , Path.Combine( context.Output.RttiProjectPath         , "UserTypeMetadata.cs"      ), context.EDMFile.XPath.UserTypes, false )
                                                    ,new GeneratedFileInfo( "Entity"               , Path.Combine( context.Output.EntityDomainProjectPath , "{0}.cs"                   ), context.EDMFile.XPath.Entity   , true  )
                                                    ,new GeneratedFileInfo( "BaseEntity"           , Path.Combine( context.Output.EntityProjectPath       , "{0}.cs"                   ), context.EDMFile.XPath.Entity   , true  )
                                                   //,new GeneratedFileInfo( "IDaoFactory"         , Path.Combine( context.Output.EntityProjectPath , "IDaoFactory.cs"           ), "/"                             )
                                                   //,new GeneratedFileInfo( "NHibernateDaoFactory", Path.Combine( context.Output.EntityProjectPath , "NHibernateDaoFactory.cs"  ), "/"                             )     
                                                   //,new GeneratedFileInfo( "NHibernateMapping"   , Path.Combine( context.Output.EntityProjectPath , "{0}.hbm.xml"              ), context.EDMFile.XPath.Entity    )                                                                                                      
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
                    string outputFile = file.GetOutputFile(Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "generatedFileName"));
                    if (!file.Mandatory && File.Exists(outputFile)) continue;

                    Utils.TemplateHelper.Render(node, context.Transform.GetTemplateFile(file.TemplateName), outputFile);
                }
            }
        }
    }
}
