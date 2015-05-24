using System.Collections.Generic;
using Mewa.Cache.Domain.Model;

namespace Mewa.Cache.Domain.Repository
{
    public interface ICachedHtmlElementsRepository
    {
        IEnumerable<CachedHtmlElement> GetElements();
        void Save(CachedHtmlElement cachedHtmlElement);
    }
}