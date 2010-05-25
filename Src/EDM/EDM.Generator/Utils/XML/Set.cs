using System;
using System.Xml;

namespace EDM.Generator.Utils.XML
{
    internal static class Set
    {
        public static void SetAttributeValue(XmlDocument dom, string xPath, string attributeName, string attributeValue)
        {
            XmlNode node = Get.GetNode(dom, xPath);
            if (node != null)
            {
                node.Attributes[attributeName].Value = attributeValue;
            }
        }

        public static void AddAttribute(XmlDocument dom, string xPath, string attributeName, string attributeValue)
        {
            XmlNode node = Get.GetNode(dom, xPath);
            if (node != null)
            {
                XmlAttribute newAttribute = dom.CreateAttribute(attributeName);
                newAttribute.Value = attributeValue;
                node.Attributes.Append(newAttribute);
            }
        }

        public static void SetNodeText(XmlDocument dom, string xPath, string value)
        {
            XmlNode node = Get.GetNode(dom, xPath);
            if (node != null)
            {
                node.InnerText = value;
            }
        }
    }
}
