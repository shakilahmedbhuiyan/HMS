using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationPackagesController : Controller
    {
        /// <summary>
        /// GET: Dashboard/AccomodationPackages
        /// </summary>
        /// <returns></returns>
        [HttpGet]       
        public ActionResult Index()
        {
            return View();
        }
    }
}