using System;
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

            //001.1 - Verificação de entidades
            XmlNodeList nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity");
            foreach (XmlNode node in nodeList)
            {
                if (CSharpKeywords.IsReserved(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Entity cannot be named {0}.", node.Attributes["name"].Value));
            }
            //001.2 - Verificação de fields
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity/fields/field");
            foreach (XmlNode node in nodeList)
            {
                if (CSharpKeywords.IsReserved(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Field cannot be named {0}.", node.Attributes["name"].Value));
            }
            //001.3 - Verificação de tipos
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/userTypes/*");
            foreach (XmlNode node in nodeList)
            {
                if (CSharpKeywords.IsReserved(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Type cannot be named {0}.", node.Attributes["name"].Value));
            }
            //001.4 - Verificação de components
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/businessProcesses/component");
            foreach (XmlNode node in nodeList)
            {
                if (CSharpKeywords.IsReserved(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Component cannot be named {0}.", node.Attributes["name"].Value));
            }
            //001.5 - Verificação de business process
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/businessProcesses/component/businessProcess");
            foreach (XmlNode node in nodeList)
            {
                if (CSharpKeywords.IsReserved(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Business Process cannot be named {0}.", node.Attributes["name"].Value));
            }
            //001.6 - Verificação de business process params
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/businessProcesses/component/businessProcess/input/param");
            foreach (XmlNode node in nodeList)
            {
                if (CSharpKeywords.IsReserved(node.Attributes["name"].Value)) throw new KeyWordUsageException(string.Format("Business Process Param cannot be named {0}.", node.Attributes["name"].Value));
            }

            //002 - Alterar o DOM do context.EDMFile.Content
            //002.1 - Adicionar aos fields o atributo edmType com o respectivo baseType e o atributo nillable
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity/fields/field");
            foreach (XmlNode node in nodeList)
            {
                if (node.Attributes["nillable"] == null) Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nillable", bool.FalseString.ToLower());
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

            //Resolve Relations
            //003.6 - oneToMany Relation
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.EntitiesRelationOneToMany);
            foreach (XmlNode node in nodeList)
            {
                string rName      = Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "name");
                string oneEntity  = Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "oneEntity");
                string manyEntity = Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "manyEntity");
                string nillable   = Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "nillable");
                bool   inverse    = bool.Parse( Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "inverse") );
                string minOccurs  = Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "minOccurs");
                string maxOccurs = Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "maxOccurs");


                XmlNode oneToManyRelations = context.EDMFile.Content.CreateElement("relations");               
                XmlNode oneToMany = context.EDMFile.Content.CreateElement("oneToMany");                               
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, oneToMany, "entity", manyEntity);
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, oneToMany, "name", manyEntity);
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, oneToMany, "minOccurs", minOccurs);
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, oneToMany, "maxOccurs", maxOccurs);
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, oneToMany, "nillable", nillable);

                oneToManyRelations.AppendChild(oneToMany);
                Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat(context.EDMFile.XPath.Entity, string.Format("[@name = '{0}']", oneEntity))).AppendChild(oneToManyRelations);                

                if (inverse)
                {
                    XmlNode manyToOneRelations = context.EDMFile.Content.CreateElement("relations");               
                    XmlNode manyToOne = context.EDMFile.Content.CreateElement("manyToOne");

                    if (bool.Parse(nillable))
                    {
                        minOccurs = "0";
                        maxOccurs = "1";
                    }
                    else
                    {
                        minOccurs = "1";
                        maxOccurs = "1";
                    }

                    Utils.XML.Set.AddAttribute(context.EDMFile.Content, manyToOne, "entity", oneEntity);
                    Utils.XML.Set.AddAttribute(context.EDMFile.Content, manyToOne, "name", oneEntity);
                    Utils.XML.Set.AddAttribute(context.EDMFile.Content, manyToOne, "minOccurs", minOccurs);
                    Utils.XML.Set.AddAttribute(context.EDMFile.Content, manyToOne, "maxOccurs", maxOccurs);
                    Utils.XML.Set.AddAttribute(context.EDMFile.Content, manyToOne, "nillable", nillable);

                    manyToOneRelations.AppendChild(manyToOne);
                    Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat(context.EDMFile.XPath.Entity, string.Format("[@name = '{0}']", manyEntity))).AppendChild(manyToOneRelations);                
                }
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
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace", string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "fkName", string.Concat(Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node.ParentNode.ParentNode, "name"), "Id"));
            }

            //003.6 - manyToOne Relation
            nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, context.EDMFile.XPath.ManyOneToRelation);
            foreach (XmlNode node in nodeList)
            {
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "assemblyName", string.Format("{0}.{1}", assemblyName, ENTITY_PROJECT_NAME));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "nameSpace", string.Format("{0}.{1}.{2}", nameSpace, ENTITY_PROJECT_NAME, Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "entity")));
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "fkName", string.Concat(Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node.ParentNode.ParentNode, "name"), "Id"));
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
