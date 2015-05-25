using System.Collections.Generic;
using System.ServiceModel;

namespace Mewa.Cache.WebServiceHost.ServiceContract
{
    [ServiceContract]
    public interface ICache
    {
        [OperationContract]
        IEnumerable<CachedElement> GetElements();
    }
}
