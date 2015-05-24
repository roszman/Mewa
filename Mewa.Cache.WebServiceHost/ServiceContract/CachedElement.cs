using System.Runtime.Serialization;

namespace Mewa.Cache.WebServiceHost.ServiceContract
{

    // since domain object corresponding to CachedElement will not have any behaviour, i wil use CachedElement as domain object. 
    //TODO shoul it be in different assembly?
    [DataContract]
    public class CachedElement
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

        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string TagName { get; set; }

        public string TagAttributeName { get; set; }

        [DataMember]
        public string TagAttributeValue { get; set; }
        [DataMember]
        public string InnerHtml { get; set; }
    }
}