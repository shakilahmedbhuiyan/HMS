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
       
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();

        

        // GET: Dashboard/AccomodationTypes
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return view of all accomodation types 
        /// </summary>
        /// <returns></returns>
        public ActionResult Listing()
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();
            model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            return PartialView("_Listing", model);
           
        }

        /// <summary>
        /// Call for get the modal for create or update operation
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Action(int? Id)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            //If call for edit with an id
            if (Id.HasValue)
            {
                var accomodationType = accomodationTypesService.GeAccomodationTypeByID(Id.Value);
                model.Id = accomodationType.Id;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }
            return PartialView("_Action", model);
        }

        /// <summary>
        /// Update or create by using ajax call
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Action(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();

            bool result;
            if (model.Id > 0)
            {
                var accomodationType = accomodationTypesService.GeAccomodationTypeByID(model.Id);
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                result = accomodationTypesService.UpdateAccomodationType(accomodationType);

            }
            else
            {

                AccomodationType accomodationType = new AccomodationType
                {
                    Name = model.Name,
                    Description = model.Description
                };

                result = accomodationTypesService.SaveAccomodationType(accomodationType);
            }

            if (result){ json.Data = new { Success = true }; }
            else { json.Data = new { Success = false, Message = " Unable to perform action on Accomodation Type" }; }
            return json;
        }



        /// <summary>
        /// Delete operation using ajax call
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            if (Id.HasValue)
            {
                var accomodationType = accomodationTypesService.GeAccomodationTypeByID(Id.Value);
                model.Id = accomodationType.Id;
                accomodationTypesService.DeleteAccomodationType(accomodationType);
            }
            return Listing();
        }


    }
}