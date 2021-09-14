using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
       
        AccomodationTypesService AccomodationTypesService = new AccomodationTypesService();
        // GET: Dashboard/AccomodationTypes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listing()
        {
            return PartialView("_Listing");
        }

    }
}