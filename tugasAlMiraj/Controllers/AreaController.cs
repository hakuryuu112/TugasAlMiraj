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

        public JsonResult SaveData(areaModel areaModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("area_create @name, @description, 1", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", areaModel.name);
                sqlCommand.Parameters.AddWithValue("@description", areaModel.description);
                sqlCommand.ExecuteNonQuery();

            }
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}