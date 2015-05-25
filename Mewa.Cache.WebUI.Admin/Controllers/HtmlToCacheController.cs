using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mewa.Cache.Domain.Repository;

namespace Mewa.Cache.WebUI.Admin.Controllers
{
    public class HtmlToCacheController : Controller
    {
        private readonly ICachedHtmlElementsRepository _cachedHtmlElementsRepository;

        public HtmlToCacheController(ICachedHtmlElementsRepository cachedHtmlElementsRepository)
        {
            _cachedHtmlElementsRepository = cachedHtmlElementsRepository;
        }

        //
        // GET: /HtmlToCache/

        public ActionResult Index()
        {
            return View();
        }

    }
}
