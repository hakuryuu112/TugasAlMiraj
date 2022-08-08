using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tugasAlMiraj.DAL;
using tugasAlMiraj.Models;
using tugasAlMiraj.Models.masterModel;

namespace tugasAlMiraj.Controllers
{
    public class AreaController : Controller
    {
        areasDAL _areasDAL = new areasDAL();

        // GET: Area
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(areaModel areaModel)
        {

            bool isInserted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    isInserted = _areasDAL.insertArea(areaModel);

                    if (isInserted)
                    {
                        TempData["SuccessMessagae"] = "Successfully...";
                    }
                    else
                    {
                        TempData["ErrorMessagae"] = "Unable to Add";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessagae"] = ex.Message;

                return View();
            }
        }
    }
}