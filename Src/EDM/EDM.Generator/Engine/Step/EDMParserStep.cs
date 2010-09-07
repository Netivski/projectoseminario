using System;
using System.Xml;
using System.Collections.Generic;
using EDM.Generator.Context;
using System.IO;

namespace EDM.Generator.Engine.Step
{
    internal class EDMParserStep: AbstractStep 
    {
        const string RTTI_PROJECT_NAME    = "Rtti";
        const string ENTITY_PROJECT_NAME  = "Entity";
        const string WS_PROJECT_NAME      = "Ws";
        const string SERVICE_PROJECT_NAME = "Services";

        public override void Generate( GeneratorContext context )
        {
            //001 - Alterar o DOM do context.EDMFile.Content
            //001.1 - Adicionar aos fields o atributo edmType com o respectivo baseType
            XmlNodeList nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity/fields/field");
            foreach (XmlNode node in nodeList)
            {
                String baseType = Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat( "/solution/userTypes/*[@name = '", node.Attributes["type"].Value.ToString(), "']")).Name;
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, string.Concat("/solution/entities/entity/fields/field[@name = '", node.Attributes["name"].Value.ToString(), "' and @type = '", node.Attributes["type"].Value.ToString(),"']"), "edmType", baseType);
            }
            //001.2 - Adicionar ao dataEnvironment o atributo Dialect
            XmlNode dataEnvNode = Utils.XML.Get.GetNode(context.EDMFile.Content, "solution/environments/dataEnvironments/*");

            //002   - Add NameSpace Atribute
            //002.1 - Solution Element
            string nameSpace, assemblyName;
            nameSpace    = context.EDMFile.NameSpace;
            assemblyName = context.EDMFile.BaseName;
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, "/solution", "nameSpace", nameSpace);

            //002.2 - userTypes Element
            string rttiNameSpace = string.Concat(nameSpace, ".", RTTI_PROJECT_NAME);
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.UserTypes, "assemblyName"     , string.Format("{0}.{1}", assemblyName, RTTI_PROJECT_NAME));
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.UserTypes, "nameSpace"        , rttiNameSpace);            
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.UserTypes, "generatedFileName", string.Empty );

            //002.3 - Entities Element
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.Entities, "nameSpace", string.Format("{0}.{1}", nameSpace, ENTITY_PROJECT_NAME ));

            //002.4 - Entity Element
            nodeList     = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.Entity);
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "assemblyName"     , string.Format("{0}.{1}"    , assemblyName, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace"        , string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "name")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "baseNameSpace"    , string.Format("{0}.{1}"    , nameSpace, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "servicesNameSpace", string.Format("{0}.{1}"    , nameSpace, SERVICE_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "wsNameSpace"      , string.Format("{0}.{1}"    , nameSpace, WS_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "wsHeaderNameSpace", "http://tempuri.org/");
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "rttiNameSpace"    , rttiNameSpace);
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "generatedFileName", Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "name"));

                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "targetDomainPath" , context.Output.EntityDomainPath);
            }

            //002.5 - oneToOne Relation
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.OneToOneRelation);
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "assemblyName", string.Format("{0}.{1}", assemblyName, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace"   , string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
            }

            //002.6 - oneToMany Relation
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.OneToManyRelation);
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "assemblyName", string.Format("{0}.{1}", assemblyName, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace"   , string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "fkName"      , string.Concat( Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node.ParentNode.ParentNode, "name"), "Id"));
            }

            //002.7 - ManyToMany Relation
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.ManyToManyRelation);
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "assemblyName", string.Format("{0}.{1}", assemblyName, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace"   , string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "tableName"   , string.Concat(Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node.ParentNode.ParentNode, "name"), Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "parentField" , string.Concat( Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node.ParentNode.ParentNode, "name"), "Id"));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "childField"  , string.Concat( Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity"), "Id"));                    
            }

            //003 - Alterar o DOM do context.EDMFile.Content - Elemento businessProcesses
            //003.1 - Adicionar ao elemento generatedFileName
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/businessProcesses/component");
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "generatedFileName", node.Attributes["name"].InnerText);
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "baseNameSpace", string.Format("{0}.{1}", nameSpace, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "servicesNameSpace", string.Format("{0}.{1}", nameSpace, SERVICE_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "wsNameSpace", string.Format("{0}.{1}", nameSpace, WS_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "wsHeaderNameSpace", "http://tempuri.org/");
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "rttiNameSpace", rttiNameSpace);
            }
                        
            //003.2 - Adicionar ao elemento businessProcess/input/param param o atributo edmType com o respectivo baseType nos parametros de entrada
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/businessProcesses/component/businessProcess/input/param");
            foreach (XmlNode node in nodeList)
            {
                XmlNode typeNode = Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat("/solution/userTypes/*[@name = '", node.Attributes["type"].Value.ToString(), "']"));
                String baseType  = typeNode.Name;
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "edmType", baseType);
            }
            //003.3 - Adicionar ao elemento businessProcess/output param o atributo edmType com o respectivo baseType nos parametros de entrada
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/businessProcesses/component/businessProcess/output");
            foreach (XmlNode node in nodeList)
            {
                XmlNode typeNode = Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat("/solution/userTypes/*[@name = '", node.Attributes["type"].Value.ToString(), "']"));
                String baseType = typeNode.Name;
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "edmType", baseType);
            }

        }
    }
}
