using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tugasAlMiraj.Models;
using tugasAlMiraj.Models.masterModel;

namespace tugasAlMiraj.DAL
{
    public class areasDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["koneksi"].ToString();

        //Area
        public bool insertArea(areaModel areaModel)
        {
            int id = 0;

            using (SqlConnection sqlConnection = new SqlConnection(conString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("area_create", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", areaModel.name);
                sqlCommand.Parameters.AddWithValue("@description", areaModel.description);

                id = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}