using System.Collections.Generic;
using System.ServiceModel;

namespace Mewa.Cache.WebServiceHost.ServiceContract
{
    // Since it is simple service contract i will keep it in ServiceHost app, in more complicated solutions I will consider extracting it to different project
    [ServiceContract]
    public interface ICache
    {
        [OperationContract]
        IEnumerable<CachedElement> GetElements();
    }
}
