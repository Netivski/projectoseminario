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

        public static string GetAttributeValue(XmlDocument dom, XmlNode node, string attributeName)
        {
            if (node != null)
            {
                try { return node.Attributes[attributeName].Value; }
                catch (NullReferenceException) { return null; } //attribute does not exist
            }
            return null;
        }


        public static string GetAttributeValue(XmlDocument dom, string xPath, string attributeName)
        {
            return GetAttributeValue(dom, GetNode(dom, xPath), attributeName);
        }

        public static string GetNodeText(XmlDocument dom, string xPath)
        {
            string returnValue = null;
            XmlNode node = GetNode(dom, xPath);
            if (node != null)
            {
                returnValue = node.InnerText.ToString();
            }
            return returnValue;
        }


        public static XmlNode GetNode(XmlDocument dom, string xPath)
        {
            return dom.SelectSingleNode(xPath);
        }
    }
}
