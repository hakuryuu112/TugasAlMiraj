using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        string conString = ConfigurationManager.ConnectionStrings["koneksi"].ToString();
        areasDAL _areasDAL = new areasDAL();

        // GET: Area
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Create(areaModel areaModel)
        {
            bool isInserted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    isInserted = _areasDAL.insertArea(areaModel);

                    using (SqlConnection sqlConnection = new SqlConnection(conString))
                    {
                        var example = areaModel.name;
                        sqlConnection.Open();

                        SqlCommand sqlCommand = new SqlCommand("area_create", sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@name", areaModel.name);
                        sqlCommand.Parameters.AddWithValue("@description", areaModel.description);

                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                    }

                    if (isInserted)
                    {
                        TempData["SuccessMessagae"] = "Add Successfully";
                    }
                    else
                    {
                        TempData["ErrorMessagae"] = "Unable to Add";
                    }
                }
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessagae"] = ex.Message;

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}