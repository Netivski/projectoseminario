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
                                                     new GeneratedFileInfo( "BaseTypes"                , Path.Combine( context.Output.RttiBasePath                , "BaseUserTypeMetadata.cs"         ), context.EDMFile.XPath.UserTypes, true  )
                                                    ,new GeneratedFileInfo( "Types"                    , Path.Combine( context.Output.RttiProjectPath             , "UserTypeMetadata.cs"             ), context.EDMFile.XPath.UserTypes, false )
                                                    ,new GeneratedFileInfo( "DomainEntity"             , Path.Combine( context.Output.EntityDomainPath            , "{0}Domain.cs"                    ), context.EDMFile.XPath.Entity   , true  )
                                                    ,new GeneratedFileInfo( "Entity"                   , Path.Combine( context.Output.EntityProjectPath           , "{0}.cs"                          ), context.EDMFile.XPath.Entity   , false )
                                                    ,new GeneratedFileInfo( "BaseIDaoFactory"          , Path.Combine( context.Output.EntityDataInterfacesBasePath, "IDaoFactoryBase.cs"              ), context.EDMFile.XPath.Root     , true  )
                                                    ,new GeneratedFileInfo( "BaseIDaoInterface"        , Path.Combine( context.Output.EntityDataInterfacesBasePath, "IDaoInterface.cs"                ), context.EDMFile.XPath.Root     , true  )                                                    
                                                    ,new GeneratedFileInfo( "IDaoFactory"              , Path.Combine( context.Output.EntityDataInterfacesPath    , "IDaoFactory.cs"                  ), context.EDMFile.XPath.Root     , false )
                                                    ,new GeneratedFileInfo( "IDaoInterface"            , Path.Combine( context.Output.EntityDataInterfacesPath    , "IDaoInterface.cs"                ), context.EDMFile.XPath.Root     , false )                                                                                                        
                                                    ,new GeneratedFileInfo( "BaseNHibernateDaoFactory" , Path.Combine( context.Output.EntityDataBasePath          , "NHibernateDaoFactoryBase.cs"     ), context.EDMFile.XPath.Root     , true  )                                 
                                                    ,new GeneratedFileInfo( "NHibernateDaoFactory"     , Path.Combine( context.Output.EntityDataPath              , "NHibernateDaoFactory.cs"         ), context.EDMFile.XPath.Root     , false )                                 
                                                    ,new GeneratedFileInfo( "NHibernateMapping"        , Path.Combine( context.Output.EntityDomainPath            , "{0}.hbm.xml"                     ), context.EDMFile.XPath.Entity   , true  )
                                                    ,new GeneratedFileInfo( "NHibernateConfig"         , Path.Combine( context.Output.PersistencePath             , "hibernate.cfg.xml"               ), context.EDMFile.XPath.Solution , true  )
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
