using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TeleCallingApp.Models;

namespace TeleCallingApp.DBService
{
    public class CallStatusService
    {
        DBConnection _connection;
        public CallStatusService()
        {
            _connection = new DBConnection();
        }
        public List<CallStatus> GetAllCallStatuses()
        {
            List<CallStatus> statuses = new List<CallStatus>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM TCS.CallStatus";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        statuses.Add(new CallStatus
                        {
                            CallStatusId = Convert.ToInt32(reader["CallStatusId"]),
                            CallStatusName = Convert.ToString(reader["CallStatusName"]),
                            CallStatusDesc = Convert.ToString(reader["CallStatusDesc"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"]),
                            CreatedBy = Convert.ToString(reader["CreatedBy"]),
                            LastUpdateBy = Convert.ToString(reader["LastUpdateBy"]),
                            CreatedOnUTC = Convert.ToDateTime(reader["CreatedOnUTC"])
                            //LastUpdateOnUTC = reader["LastUpdateOnUTC"] != null
                        });
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return statuses;
        }
    }
}