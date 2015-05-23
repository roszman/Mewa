using System.Runtime.Serialization;

namespace Mewa.Cache.WebServiceHost.ServiceContract
{

    // since domain object corresponding to CachedElement will not have any behaviour, i wil use CachedElement as domain object. 
    //TODO shoul it be in different assembly?
    [DataContract]
    public class CachedElement
    {
        public CachedElement(string tagName, string tagValue, string url, string value)
        {
            TagName = tagName;
            TagValue = tagValue;
            Url = url;
            Value = value;
        }

        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string TagName { get; set; }
        [DataMember]
        public string TagValue { get; set; }
        [DataMember]
        public string Value { get; set; }
    }
}