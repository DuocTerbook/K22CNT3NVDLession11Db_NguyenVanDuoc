﻿using System.Web;
using System.Web.Mvc;

namespace Nvd_Lession11Db
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
