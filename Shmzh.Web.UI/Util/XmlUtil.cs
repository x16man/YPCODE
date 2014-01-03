using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Shmzh.Web.UI
{
    internal sealed class XmlUtil
    {
        private XmlUtil()
        { }

        public static XmlNode AppendElement(XmlNode node, string newElementName)
        {
            return AppendElement(node, newElementName, null);
        }

        public static XmlNode AppendElement(XmlNode node, string newElementName, string innerValue)
        {
            XmlNode oNode;

            if (node is XmlDocument)
                oNode = node.AppendChild(((XmlDocument)node).CreateElement(newElementName));
            else
                oNode = node.AppendChild(node.OwnerDocument.CreateElement(newElementName));

            if (innerValue != null)
                oNode.AppendChild(node.OwnerDocument.CreateTextNode(innerValue));

            return oNode;
        }

        public static XmlAttribute CreateAttribute(XmlDocument xmlDocument, string name, string value)
        {
            XmlAttribute oAtt = xmlDocument.CreateAttribute(name);
            oAtt.Value = value;
            return oAtt;
        }

        public static void SetAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            if (node.Attributes[attributeName] != null)
                node.Attributes[attributeName].Value = attributeValue;
            else
                node.Attributes.Append(CreateAttribute(node.OwnerDocument, attributeName, attributeValue));
        }

        public static string GetAttribute(XmlNode node, string attributeName, string defaultValue)
        {
            var att = node.Attributes[attributeName];
            return att != null ? att.Value : defaultValue;
        }

        public static string GetNodeValue(XmlNode parentNode, string nodeXPath, string defaultValue)
        {
            var node = parentNode.SelectSingleNode(nodeXPath);
            if (node.FirstChild != null)
                return node.FirstChild.Value;
            else 
                return node != null ? node.Value : defaultValue;
        }
    }
}
