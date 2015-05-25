using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mewa.Cache.WebServiceHost.ServiceContract
{

    // since domain object corresponding to CachedElement will not have any behaviour, i wil use CachedElement as domain object. 
    //TODO shoul it be in different assembly?
    public class CachedElement : IXmlSerializable
    {
        //TODO remove constructor ?
        public CachedElement(
            string url, 
            string tagName, 
            string tagAttributeName, 
            string tagAttributeValue, 
            string innerHtml)
        {
            TagName = tagName;
            TagAttributeName = tagAttributeName;
            TagAttributeValue = tagAttributeValue;
            Url = url;
            InnerHtml = innerHtml;
        }

        public CachedElement()
        {
        }

        public string Url { get; set; }
        public string TagName { get; set; }

        public string TagAttributeName { get; set; }

        public string TagAttributeValue { get; set; }
        public string InnerHtml { get; set; }

        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader reader) { }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("url", Url);
            writer.WriteAttributeString("tag_name", TagName);
            writer.WriteAttributeString("attribute_name", TagAttributeName);
            writer.WriteAttributeString("attribute_value", TagAttributeValue);
            writer.WriteElementString("innerHtml", InnerHtml);
        }
    }
}