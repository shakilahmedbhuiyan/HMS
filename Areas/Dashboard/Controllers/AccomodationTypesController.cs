using HMS.Areas.Dashboard.ViewModel;
using HMS.Services; //manually added refrence file
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
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();
            model.AccomodationTypes = AccomodationTypesService.GetAllAccomodationTypes();
            return PartialView("_Listing", model);
        }

    }
}