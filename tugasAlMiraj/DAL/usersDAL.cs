using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using tugasAlMiraj.Common;
using tugasAlMiraj.Models.masterModel;

namespace tugasAlMiraj.DAL
{
    public class usersDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["koneksi"].ToString();

        Password EncryptData = new Password();

        //Register
        public bool insertRegister(usersModel usersModel)
        {
            int id = 0;

            using (SqlConnection sqlConnection = new SqlConnection(conString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("users_register", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@username", usersModel.username);
                sqlCommand.Parameters.AddWithValue("@name", usersModel.name);
                sqlCommand.Parameters.AddWithValue("@email", usersModel.email);
                sqlCommand.Parameters.AddWithValue("@password", EncryptData.Encode(usersModel.password));
                sqlCommand.Parameters.AddWithValue("@address", usersModel.address);
                sqlCommand.Parameters.AddWithValue("@telephone", usersModel.telephone);

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