﻿using System.Web;
using System.Web.Mvc;

namespace Mewa.Cache.WebUI.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}