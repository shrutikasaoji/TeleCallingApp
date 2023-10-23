using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TeleCallingApp.DBService
{
    public class DBConnection
    {
        public string _conString;

        public string ConString { get { return _conString; } }
        public DBConnection()
        {
            _conString = ConfigurationManager.ConnectionStrings["tcs"].ToString(); ;
        }

        public bool ConnectToDatabase()
        {
            bool isConnected = false;
            string connectionString = ConfigurationManager.ConnectionStrings["tcs"].ToString();
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    sqlconnection.Open();
                    isConnected = true;
                }
            }
            catch(Exception ex)
            {

            }
            return isConnected;
        }
        public bool DisconnectDatabase()
        {
            bool isConnected = false;
            string connectionString = ConfigurationManager.ConnectionStrings["tcs"].ToString();
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    sqlconnection.Open();
                    isConnected = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isConnected;
        }
    }
}