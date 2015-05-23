using System.Collections.Generic;
using Mewa.Cache.Domain;
using Mewa.Cache.Domain.Repository;

namespace Mewa.Cache.Infrastructure.Repository
{
    public class CacheRepository : ICacheRepository
    {
        public IEnumerable<CachedElement> GetElements()
        {
            return new List<CachedElement>
            {
                new CachedElement
                {
                    TagName = "tag name",
                    TagValue = "tag value",
                    Url = "url",
                    Value = "<span>Follow us on<a href='https://jabbr.net/#/rooms/Lobby' class='jabbr' title='JabbR'></a><a href='https://www.facebook.com/asp.net' class='facebook' title='Facebook'></a><a href='http://twitter.com/aspnet' class='twitter' title='Twitter'></a></span>"
                },
                new CachedElement
                {
                    TagName = "tag name",
                    TagValue = "tag value",
                    Url = "url",
                    Value = "<span>Follow us on<a href='https://jabbr.net/#/rooms/Lobby' class='jabbr' title='JabbR'></a><a href='https://www.facebook.com/asp.net' class='facebook' title='Facebook'></a><a href='http://twitter.com/aspnet' class='twitter' title='Twitter'></a></span>"
                }

            };
        }
    }
}