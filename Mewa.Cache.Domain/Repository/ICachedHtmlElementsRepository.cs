using System.Collections.Generic;
using Mewa.Cache.Domain.Model;

namespace Mewa.Cache.Domain.Repository
{
    public interface ICachedHtmlElementsRepository
    {
        IEnumerable<CachedHtmlElement> GetCachedElements();
        void Update(CachedHtmlElement cachedHtmlElement);
        void Add(CachedHtmlElement cachedHtmlElement);
        IEnumerable<CachedHtmlElement> GetAllHtmlElements();
    }
}