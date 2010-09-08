﻿using System;
using System.Linq;
using System.Xml;
using System.Collections.Generic;
using EDM.Generator.Context;
using EDM.Generator.Exception;
using System.IO;
using System.Xml.Linq;

namespace EDM.Generator.Engine.Step
{
    internal class EDMParserStep: AbstractStep 
    {
        const string RTTI_PROJECT_NAME      = "Rtti";
        const string ENTITY_PROJECT_NAME    = "Entity";
        const string WS_PROJECT_NAME        = "Ws";
        const string SERVICE_PROJECT_NAME   = "Services";
        const string UNIT_TEST_PROJECT_NAME = "UnitTest";

        public override void Generate( GeneratorContext context )
        {
            //001 - Verificação da não existência de conflito entre nomes de entidades, tipos ou fields com as KeyWords de C#
            XDocument doc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, @"../../../EDM.Generator/Engine/XML/CSharpKeywords.xml"), LoadOptions.None);
            XElement root = doc.Root;

            List<String> keyWordList = (from c in root.Elements() select c.Value).ToList();

            //001.1 - Verificação de entidades
            XmlNodeList nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity");
            foreach (XmlNode node in nodeList)
            {
                if (keyWordList.Contains(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Entities cannot be named {0}.", node.Attributes["name"].Value));
            }
            //001.2 - Verificação de fields
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity/fields/field");
            foreach (XmlNode node in nodeList)
            {
                if (keyWordList.Contains(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Fields cannot be named {0}.", node.Attributes["name"].Value));
            }
            //001.3 - Verificação de tipos
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/userTypes/*");
            foreach (XmlNode node in nodeList)
            {
                if (keyWordList.Contains(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Fields cannot be named {0}.", node.Attributes["name"].Value));
            }

            //002 - Alterar o DOM do context.EDMFile.Content
            //002.1 - Adicionar aos fields o atributo edmType com o respectivo baseType
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity/fields/field");
            foreach (XmlNode node in nodeList)
            {
                String baseType = Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat( "/solution/userTypes/*[@name = '", node.Attributes["type"].Value.ToString(), "']")).Name;
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, string.Concat("/solution/entities/entity/fields/field[@name = '", node.Attributes["name"].Value.ToString(), "' and @type = '", node.Attributes["type"].Value.ToString(),"']"), "edmType", baseType);
            }
            //002.2 - Adicionar ao dataEnvironment o atributo Dialect
            XmlNode dataEnvNode = Utils.XML.Get.GetNode(context.EDMFile.Content, "solution/environments/dataEnvironments/*");

            //003   - Add NameSpace Atribute
            //003.1 - Solution Element
            string nameSpace, assemblyName;
            nameSpace    = context.EDMFile.NameSpace;
            assemblyName = context.EDMFile.BaseName;
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, "/solution", "nameSpace", nameSpace);

            //003.2 - userTypes Element
            string rttiNameSpace = string.Concat(nameSpace, ".", RTTI_PROJECT_NAME);
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.UserTypes, "assemblyName"     , string.Format("{0}.{1}", assemblyName, RTTI_PROJECT_NAME));
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.UserTypes, "nameSpace"        , rttiNameSpace);            
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.UserTypes, "generatedFileName", string.Empty );

            //003.3 - Entities Element
            Utils.XML.Set.AddAttribute(context.EDMFile.Content, context.EDMFile.XPath.Entities, "nameSpace", string.Format("{0}.{1}", nameSpace, ENTITY_PROJECT_NAME ));

            //003.4 - Entity Element
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
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "unitTestNameSpace", string.Format("{0}.{1}"    , nameSpace, UNIT_TEST_PROJECT_NAME));

                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "targetDomainPath" , context.Output.EntityDomainPath);
            }
            
            //003.5 - oneToOne Relation
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.OneToOneRelation);
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "assemblyName", string.Format("{0}.{1}", assemblyName, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace"   , string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
            }

            //003.6 - oneToMany Relation
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.OneToManyRelation);
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "assemblyName", string.Format("{0}.{1}", assemblyName, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace"   , string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "fkName"      , string.Concat( Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node.ParentNode.ParentNode, "name"), "Id"));
            }

            //003.7 - ManyToMany Relation
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.ManyToManyRelation);
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "assemblyName", string.Format("{0}.{1}", assemblyName, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace"   , string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "tableName"   , string.Concat(Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node.ParentNode.ParentNode, "name"), Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "parentField" , string.Concat( Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node.ParentNode.ParentNode, "name"), "Id"));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "childField"  , string.Concat( Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity"), "Id"));                    
            }

            //004 - Alterar o DOM do context.EDMFile.Content - Elemento businessProcesses
            //004.1 - Adicionar ao elemento generatedFileName
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
                        
            //004.2 - Adicionar ao elemento businessProcess/input/param param o atributo edmType com o respectivo baseType nos parametros de entrada
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/businessProcesses/component/businessProcess/input/param");
            foreach (XmlNode node in nodeList)
            {
                XmlNode typeNode = Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat("/solution/userTypes/*[@name = '", node.Attributes["type"].Value.ToString(), "']"));
                String baseType  = typeNode.Name;
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "edmType", baseType);
            }
            //004.3 - Adicionar ao elemento businessProcess/output param o atributo edmType com o respectivo baseType nos parametros de entrada
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
