using System;
using System.Xml;

namespace EDM.Generator.Utils.XML
{
    internal static class Get
    {
        public static XmlNodeList GetNodeList(XmlDocument dom, string xPath)
        {
            return (dom.SelectNodes(xPath));
        }

        public static string GetAttributeValue(XmlDocument dom, string xPath, string attributeName)
        {
            string returnValue = null;
            XmlNode node = GetNode(dom, xPath);
            if (node != null)
            {
                returnValue = node.Attributes[attributeName].Value.ToString();
            }
            return (returnValue);
        }

        public static string GetNodeText(XmlDocument dom, string xPath)
        {
            string returnValue = null;
            XmlNode node = GetNode(dom, xPath);
            if (node != null)
            {
                returnValue = node.InnerText.ToString();
            }
            return (returnValue);
        }


        public static XmlNode GetNode(XmlDocument dom, string xPath)
        {
            return (dom.SelectSingleNode(xPath));
        }
    }
}
