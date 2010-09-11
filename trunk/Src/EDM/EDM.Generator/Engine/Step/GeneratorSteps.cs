using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using EDM.Generator.Context;

namespace EDM.Generator.Engine.Step
{
    internal class GeneratorSteps : AbstractStep
    {
        List<AbstractStep> steps = null;

        void SetSteps(GeneratorContext context)
        {
            steps = new List<AbstractStep>(){
                     new EDMParserStep()
                    ,new Step( "BaseTypes"                , Path.Combine( context.Output.RttiBasePath                , "BaseUserTypeMetadata.cs"         ), context.EDMFile.XPath.UserTypes, true  )
                    ,new Step( "Types"                    , Path.Combine( context.Output.RttiProjectPath             , "UserTypeMetadata.cs"             ), context.EDMFile.XPath.UserTypes, false )
                    ,new Step( "DomainEntity"             , Path.Combine( context.Output.EntityDomainPath            , "{0}Domain.cs"                    ), context.EDMFile.XPath.Entity   , true  )
                    ,new Step( "Entity"                   , Path.Combine( context.Output.EntityProjectPath           , "{0}.cs"                          ), context.EDMFile.XPath.Entity   , false )
                    ,new Step( "BaseIDaoFactory"          , Path.Combine( context.Output.EntityDataInterfacesBasePath, "IDaoFactoryBase.cs"              ), context.EDMFile.XPath.Root     , true  )
                    ,new Step( "BaseIDaoInterface"        , Path.Combine( context.Output.EntityDataInterfacesBasePath, "IDaoInterface.cs"                ), context.EDMFile.XPath.Root     , true  )                                                    
                    ,new Step( "IDaoFactory"              , Path.Combine( context.Output.EntityDataInterfacesPath    , "IDaoFactory.cs"                  ), context.EDMFile.XPath.Root     , false )
                    ,new Step( "IDaoInterface"            , Path.Combine( context.Output.EntityDataInterfacesPath    , "IDaoInterface.cs"                ), context.EDMFile.XPath.Root     , false )                                                                                                        
                    ,new Step( "BaseNHibernateDaoFactory" , Path.Combine( context.Output.EntityDataBasePath          , "NHibernateDaoFactoryBase.cs"     ), context.EDMFile.XPath.Root     , true  )                                 
                    ,new Step( "NHibernateDaoFactory"     , Path.Combine( context.Output.EntityDataPath              , "NHibernateDaoFactory.cs"         ), context.EDMFile.XPath.Root     , false )                                 
                    ,new Step( "NHibernateMapping"        , Path.Combine( context.Output.EntityDomainPath            , "{0}.hbm.xml"                     ), context.EDMFile.XPath.Entity   , true  )
                    ,new Step( "NHibernateConfig"         , Path.Combine( context.Output.PersistencePath             , "hibernate.cfg.xml"               ), context.EDMFile.XPath.Solution , true  )
                    ,new Step( "ServicesBase"             , Path.Combine( context.Output.ServicesBase                , "{0}BaseService.cs"               ), context.EDMFile.XPath.Entity   , true  )
                    ,new Step( "Services"                 , Path.Combine( context.Output.Services                    , "{0}Service.cs"                   ), context.EDMFile.XPath.Entity   , false )
                    ,new Step( "WsBase"                   , Path.Combine( context.Output.WsBase                      , "{0}BaseWs.cs"                    ), context.EDMFile.XPath.Entity   , true  )
                    ,new Step( "WsAsmx"                   , Path.Combine( context.Output.WsAsmx                      , "{0}Ws.asmx"                      ), context.EDMFile.XPath.Entity   , false )
                    ,new Step( "WsAsmxCs"                 , Path.Combine( context.Output.WsAsmxCs                    , "{0}Ws.asmx.cs"                   ), context.EDMFile.XPath.Entity   , false )                    
                    ,new Step( "BPServicesBase"           , Path.Combine( context.Output.ServicesBase                , "{0}BaseService.cs"               ), context.EDMFile.XPath.Component, true  )
                    ,new Step( "BPServices"               , Path.Combine( context.Output.Services                    , "{0}Service.cs"                   ), context.EDMFile.XPath.Component, false )
                    ,new Step( "BPWsBase"                 , Path.Combine( context.Output.WsBase                      , "{0}BaseWs.cs"                    ), context.EDMFile.XPath.Component, true  )
                    ,new Step( "BPWsAsmx"                 , Path.Combine( context.Output.WsAsmx                      , "{0}Ws.asmx"                      ), context.EDMFile.XPath.Component, false )
                    ,new Step( "BPWsAsmxCs"               , Path.Combine( context.Output.WsAsmxCs                    , "{0}Ws.asmx.cs"                   ), context.EDMFile.XPath.Component, false )
                    ,new Step( "UnitTest"                 , Path.Combine( context.Output.UnitTestPath                , "{0}Test.cs"                      ), context.EDMFile.XPath.Entity   , false )
            };
        }

        public override void Generate(GeneratorContext context)
        {
            SetSteps( context );

            foreach (AbstractStep step in steps)
            {
                step.Generate(context);

                //XmlNodeList nodes = context.EDMFile.Content.SelectNodes(step.XPath);
                //foreach (XmlNode node in nodes)
                //{
                //    string outputFile = step.GetOutputFile(Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "generatedFileName"));
                //    if (!step.Mandatory && File.Exists(outputFile)) continue;

                //    Utils.TemplateHelper.Render(node, context.Transform.GetTemplateFile(step.TemplateName), outputFile);
                //}
            }
        }
    }
}