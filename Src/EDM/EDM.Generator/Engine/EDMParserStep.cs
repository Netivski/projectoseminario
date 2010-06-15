using System;
using System.Xml;
using System.Collections.Generic;
using EDM.Generator.Context;

namespace EDM.Generator.Engine
{
    internal class EDMParserStep: AbstractStep 
    {
        const string RTTI_PROJECT_NAME   = "Rtti";
        const string ENTITY_PROJECT_NAME = "Entity";

        public override void GenerateStep( GeneratorContext context )
        {
            //001 - Alterar o DOM do context.EDMFile.Content
            XmlNodeList nodeList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity/fields/field");
            foreach (XmlNode node in nodeList)
            {
                String baseType = Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat( "/solution/userTypes/*[@name = '", node.Attributes["type"].Value.ToString(), "']")).Name;
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, string.Concat("/solution/entities/entity/fields/field[@name = '", node.Attributes["name"].Value.ToString(), "' and @type = '", node.Attributes["type"].Value.ToString(),"']"), "edmType", baseType);
            }

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
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "rttiNameSpace"    , rttiNameSpace);
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, node, "generatedFileName", Utils.XML.Get.GetAttributeValue(context.EDMFile.Content, node, "name"));                
            }

        }
    }
}
