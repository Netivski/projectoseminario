using System;
using System.Xml;
using EDM.Generator.Context;

namespace EDM.Generator.Engine
{
    internal class EDMParserStep: AbstractStep 
    {
        public override void GenerateStep( GeneratorContext context )
        {
            //Alterar o DOM do context.EDMFile.Content
            XmlNodeList fieldList = Utils.XML.Get.GetNodeList(context.EDMFile.Content, "/solution/entities/entity/fields/field");
            foreach (XmlNode node in fieldList)
            {
                String baseType = Utils.XML.Get.GetNode(context.EDMFile.Content, string.Concat( "/solution/userTypes/*[@name = '", node.Attributes["type"].Value.ToString(), "']")).Name;
                Utils.XML.Set.AddAttribute(context.EDMFile.Content, string.Concat("/solution/entities/entity/fields/field[@name = '", node.Attributes["name"].Value.ToString(), "' and @type = '", node.Attributes["type"].Value.ToString(),"']"), "edmType", baseType);
            }
        }
    }
}
