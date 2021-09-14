using HMS.Areas.Dashboard.ViewModel;
using HMS.Entities;
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
            AccomodationTypesListingModel model = new AccomodationTypesListingModel
            {
                AccomodationTypes = AccomodationTypesService.GetAllAccomodationTypes()
            };
            return PartialView("_Listing", model);
        }
        public ActionResult Create()
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();
            return PartialView("_Create", model);
        }
        [HttpPost]
        public JsonResult Create(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();
            AccomodationType accomodationType = new AccomodationType();
            accomodationType.Name = model.Name;
            accomodationType.Description = model.Description;

            var result = AccomodationTypesService.SaveAccomodationType(accomodationType);
            if (result) { json.Data = new { Success = true }; }
            else { json.Data = new { Success = false, Message = " Unable to add Accomodation Type" }; }
            return json;
        }

    }
}