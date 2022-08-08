using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using tugasAlMiraj.Models.masterModel;
using tugasAlMiraj.DAL;
using tugasAlMiraj.Common;

namespace tugasAlMiraj.Controllers
{
    public class UsersController : Controller
    {
        //SqlConnection sqlConnection = new SqlConnection();
        //SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;

        usersDAL _usersDAL = new usersDAL();
        Password EncryptData = new Password();
        string conString = ConfigurationManager.ConnectionStrings["koneksi"].ToString();

        // GET: Users
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(usersModel usersModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("users_login", sqlConnection);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@email", usersModel.email);
                sqlCommand.Parameters.AddWithValue("@password", EncryptData.Encode(usersModel.password));

                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    sqlConnection.Close();

                    return RedirectToAction("Register");
                }
                else
                {
                    sqlConnection.Close();

                    return RedirectToAction("Login");
                }
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Register(usersModel usersModel)
        {
            bool isInserted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    isInserted = _usersDAL.insertRegister(usersModel);

                    if (isInserted)
                    {
                        TempData["SuccessMessagae"] = "Register Successfully";
                    }
                    else
                    {
                        TempData["ErrorMessagae"] = "Unable to Register";
                    }
                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessagae"] = ex.Message;

                return View();
            }
        }
    }
}