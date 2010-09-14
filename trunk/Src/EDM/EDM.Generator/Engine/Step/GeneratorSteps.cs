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
                     new ThreeDPreExecuteStep()
                    ,new Step( "BaseTypes"                , Path.Combine( context.Output.RttiBasePath                , "BaseUserTypeMetadata.cs"         ), context.ThreeDFile.XPath.UserTypes, true  )
                    ,new Step( "Types"                    , Path.Combine( context.Output.RttiProjectPath             , "UserTypeMetadata.cs"             ), context.ThreeDFile.XPath.UserTypes, false )
                    ,new Step( "DomainEntity"             , Path.Combine( context.Output.EntityDomainPath            , "{0}Domain.cs"                    ), context.ThreeDFile.XPath.Entity   , true  )
                    ,new Step( "Entity"                   , Path.Combine( context.Output.EntityProjectPath           , "{0}.cs"                          ), context.ThreeDFile.XPath.Entity   , false )
                    ,new Step( "BaseIDaoFactory"          , Path.Combine( context.Output.EntityDataInterfacesBasePath, "IDaoFactoryBase.cs"              ), context.ThreeDFile.XPath.Root     , true  )
                    ,new Step( "BaseIDaoInterface"        , Path.Combine( context.Output.EntityDataInterfacesBasePath, "IDaoInterfaceBase.cs"            ), context.ThreeDFile.XPath.Root     , true  )                                                    
                    ,new Step( "IDaoFactory"              , Path.Combine( context.Output.EntityDataInterfacesPath    , "IDaoFactory.cs"                  ), context.ThreeDFile.XPath.Root     , false )
                    ,new Step( "IDaoInterfacePartial"     , Path.Combine( context.Output.EntityDataInterfacesPath    , "IDaoInterfacePartial.cs"         ), context.ThreeDFile.XPath.Root     , true )                                                                                                        
                    ,new Step( "IDaoInterface"            , Path.Combine( context.Output.EntityDataInterfacesPath    , "IDaoInterface.cs"                ), context.ThreeDFile.XPath.Root     , false )
                    ,new Step( "BaseNHibernateDaoFactory" , Path.Combine( context.Output.EntityDataPath              , "DaoFactoryPartial.cs"            ), context.ThreeDFile.XPath.Root     , true  )                                 
                    ,new Step( "DAOImplementationPartial" , Path.Combine( context.Output.EntityDataPath              , "DAOImplementationPartial.cs"     ), context.ThreeDFile.XPath.Root     , true  )                                 
                    ,new Step( "DAOImplementation"        , Path.Combine( context.Output.EntityDataPath              , "DAOImplementation.cs"            ), context.ThreeDFile.XPath.Root     , false )                                 
                    ,new Step( "NHibernateDaoFactory"     , Path.Combine( context.Output.EntityDataPath              , "DaoFactory.cs"                   ), context.ThreeDFile.XPath.Root     , false )                                 
                    ,new Step( "NHibernateMapping"        , Path.Combine( context.Output.EntityDomainPath            , "{0}.hbm.xml"                     ), context.ThreeDFile.XPath.Entity   , true  )
                    ,new Step( "NHibernateConfig"         , Path.Combine( context.Output.WsAsmx                      , "hibernate.cfg.xml"               ), context.ThreeDFile.XPath.Solution , true  )
                    ,new Step( "ServicesBase"             , Path.Combine( context.Output.ServicesBase                , "{0}BaseService.cs"               ), context.ThreeDFile.XPath.Entity   , true  )
                    ,new Step( "Services"                 , Path.Combine( context.Output.Services                    , "{0}Service.cs"                   ), context.ThreeDFile.XPath.Entity   , false )
                    ,new Step( "WsBase"                   , Path.Combine( context.Output.WsBase                      , "{0}BaseWs.cs"                    ), context.ThreeDFile.XPath.Entity   , true  )
                    ,new Step( "WsAsmx"                   , Path.Combine( context.Output.WsAsmx                      , "{0}Ws.asmx"                      ), context.ThreeDFile.XPath.Entity   , false )
                    ,new Step( "WsAsmxCs"                 , Path.Combine( context.Output.WsAsmxCs                    , "{0}Ws.asmx.cs"                   ), context.ThreeDFile.XPath.Entity   , false )                    
                    ,new Step( "BPServicesBase"           , Path.Combine( context.Output.ServicesBase                , "{0}BaseService.cs"               ), context.ThreeDFile.XPath.Component, true  )
                    ,new Step( "BPServices"               , Path.Combine( context.Output.Services                    , "{0}Service.cs"                   ), context.ThreeDFile.XPath.Component, false )
                    ,new Step( "BPWsBase"                 , Path.Combine( context.Output.WsBase                      , "{0}BaseWs.cs"                    ), context.ThreeDFile.XPath.Component, true  )
                    ,new Step( "BPWsAsmx"                 , Path.Combine( context.Output.WsAsmx                      , "{0}Ws.asmx"                      ), context.ThreeDFile.XPath.Component, false )
                    ,new Step( "BPWsAsmxCs"               , Path.Combine( context.Output.WsAsmxCs                    , "{0}Ws.asmx.cs"                   ), context.ThreeDFile.XPath.Component, false )
                    ,new Step( "UnitTest"                 , Path.Combine( context.Output.UnitTestPath                , "{0}Test.cs"                      ), context.ThreeDFile.XPath.Entity   , false )
            };
        }

        public override void Generate(GeneratorContext context)
        {
            SetSteps( context );

            foreach (AbstractStep step in steps)
            {
                step.Generate(context);
            }
        }
    }
}