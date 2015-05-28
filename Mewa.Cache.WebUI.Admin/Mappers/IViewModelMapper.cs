using Mewa.Cache.WebUI.Admin.Models;

namespace Mewa.Cache.WebUI.Admin.Mappers
{
    public interface IViewModelMapper<TDomainModel>
    {
        HtmlElelmentToCache Map(TDomainModel domainModel);
    }
}