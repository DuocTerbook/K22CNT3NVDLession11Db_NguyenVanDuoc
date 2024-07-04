using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nvd_Lession11Db.Controllers
{
    public class NvdHomeController : Controller
    {
        public ActionResult NvdIndex()
        {
            return View();
        }

        public ActionResult NvdAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult NvdContact()
        {
            ViewBag.msv = "2210900016";
            ViewBag.fullname = "Nguyễn Văn Được";

            return View();
        }
    }
}