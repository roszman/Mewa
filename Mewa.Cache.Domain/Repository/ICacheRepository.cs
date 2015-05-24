using System.Collections.Generic;
using Mewa.Cache.Domain.Model;

namespace Mewa.Cache.Domain.Repository
{
    public interface ICachedHtmlElementsRepository
    {
        IEnumerable<CachedHtmlElement> GetCachedElements();
        void Save(CachedHtmlElement cachedHtmlElement);
    }
}