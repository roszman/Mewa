using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.WebUI.Admin.Mappers;
using Mewa.Cache.WebUI.Admin.Models;

namespace Mewa.Cache.WebUI.Admin.Controllers
{
    public class HtmlToCacheController : Controller
    {
        private readonly ICachedHtmlElementsRepository _cachedHtmlElementsRepository;
        private readonly IViewModelMapper<CachedHtmlElement> _viewModelMapper;

        public HtmlToCacheController(ICachedHtmlElementsRepository cachedHtmlElementsRepository, IViewModelMapper<CachedHtmlElement> viewModelMapper)
        {
            _cachedHtmlElementsRepository = cachedHtmlElementsRepository;
            _viewModelMapper = viewModelMapper;
        }

        //
        // GET: /HtmlToCache/

        public ActionResult Index()
        {
            var cachedHtmlElements = _cachedHtmlElementsRepository.GetAllHtmlElements();
            var htmlElementsToCache = cachedHtmlElements.Select(che => _viewModelMapper.Map(che));
            return View(htmlElementsToCache);
        }

        public ActionResult Edit(long id)
        {
            var cachedHtmlElement = _cachedHtmlElementsRepository.GetCachedElementById(id);
            var htmlElelmentToCache = _viewModelMapper.Map(cachedHtmlElement);
            return View(htmlElelmentToCache);
        }


        public ActionResult Create()
        {
            return View(new HtmlElelmentToCache());
        }

        [HttpPost]
        public ActionResult Create(HtmlElelmentToCache htmlElelmentToCache)
        {
            if (ModelState.IsValid)
            {
                CreateCacheHtmlElement(htmlElelmentToCache);
                return this.RedirectToAction("Index");
            }
            return this.View(htmlElelmentToCache);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            //TODO info when sucess or error
            _cachedHtmlElementsRepository.Delete(id);
            return this.RedirectToAction("Index");
        }

        private void CreateCacheHtmlElement(HtmlElelmentToCache htmlElelmentToCache)
        {
            var cachedHtmlElement = new CachedHtmlElement
            {
                HtmlElementAddress = new HtmlElementAddress
                {
                    Url = htmlElelmentToCache.Url,
                    HtmlTag = new HtmlTag
                    {
                        Name = htmlElelmentToCache.TagName,
                        Attribute = new HtmlTagAttribute
                        {
                            Name = htmlElelmentToCache.TagAttributeName,
                            Value = htmlElelmentToCache.TagAttributeValue
                        }
                       
                    }
                },
                LastRefreshDate = null
            };
            _cachedHtmlElementsRepository.Add(cachedHtmlElement);
        }

        [HttpPost]
        public ActionResult Edit(HtmlElelmentToCache htmlElelmentToCache)
        {
            if (ModelState.IsValid)
            {
                UpdateCacheHtmlElement(htmlElelmentToCache);
                return this.RedirectToAction("Index");
            }


            return this.View(htmlElelmentToCache);
        }

        private void UpdateCacheHtmlElement(HtmlElelmentToCache htmlElelmentToCache)
        {
            var cachedHtmlElement = _cachedHtmlElementsRepository.GetCachedElementById(htmlElelmentToCache.Id);
            cachedHtmlElement.HtmlElementAddress.Url = htmlElelmentToCache.Url;
            cachedHtmlElement.HtmlElementAddress.HtmlTag.Name = htmlElelmentToCache.TagName;
            cachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Name = htmlElelmentToCache.TagAttributeName;
            cachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Value = htmlElelmentToCache.TagAttributeValue;
            _cachedHtmlElementsRepository.Update(cachedHtmlElement);
        }
    }
}
