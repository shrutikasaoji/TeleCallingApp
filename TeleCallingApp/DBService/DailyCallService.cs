using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TeleCallingApp.Models;

namespace TeleCallingApp.DBService
{
    public class DailyCallService
    {
        DBConnection _connection;
        public DailyCallService()
        {
            _connection = new DBConnection();
        }
        public List<DailyCallDetail> GetAllDailyCalls()
        {
            List<DailyCallDetail> users = new List<DailyCallDetail>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT calls.DailyCallDetailId, calls.CallDate, calls.CallTime, calls.CustomerDetailId, cust.CustomerName, calls.CallDuration, calls.CallRemark, calls.WhatsAppRemark, calls.SMSRemark, calls.EmailRemark, calls.CallStatusID, sts.CallStatusName, calls.CreatedOnUTC, calls.CreatedBy, calls.LastUpdateOnUTC, calls.LastUpdateBy" +
                                " FROM TCS.DailyCallDetail calls INNER JOIN TCS.CustomerDetail cust ON cust.CustomerDetailId = calls.CustomerDetailId"+
                                " INNER JOIN TCS.CallStatus sts ON sts.CallStatusId = calls.CallStatusID";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new DailyCallDetail
                        {
                            DailyCallDetailId = Convert.ToInt32(reader["DailyCallDetailId"]),
                            CallDate = Convert.ToDateTime(Convert.ToString(reader["CallDate"])),
                            CallTime = Convert.ToDateTime(Convert.ToString(reader["CallTime"])),
                            CallDuration = Convert.ToInt32(reader["CallDuration"]),
                            CustomerDetailId = Convert.ToInt32(reader["CustomerDetailId"]),
                            CustomerName = Convert.ToString(reader["CustomerName"]),
                            CallRemark = Convert.ToString(reader["CallRemark"]),
                            WhatsAppRemark = Convert.ToString(reader["WhatsAppRemark"]),
                            SMSRemark = Convert.ToString(reader["SMSRemark"]),
                            EmailRemark = Convert.ToString(reader["EmailRemark"]),
                            CallStatusID = Convert.ToInt32(reader["CallStatusID"]),
                            CallingStatus = Convert.ToString(reader["CallStatusName"]),
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

            return users;
        }

        public int AddCallDetails(DailyCallDetail dailyCall)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO TCS.DailyCallDetail(CallDate, CallTime, CustomerDetailId, CallDuration, CallRemark, WhatsAppRemark, SMSRemark, EmailRemark, CallStatusID, CreatedOnUTC, CreatedBy, IsActive)" +
                                " VALUES(@CallDate, @CallTime, @CustomerDetailId, @CallDuration, @CallRemark, @WhatsAppRemark, @SMSRemark, @EmailRemark, @CallStatusID, GETUTCDATE(), 'system', 1)";
                    command.CommandType = CommandType.Text;

                    #region Parameters
                    command.Parameters.AddWithValue("@CallDate", Convert.ToDateTime(dailyCall.CallDate));
                    command.Parameters.AddWithValue("@CallTime", Convert.ToDateTime(dailyCall.CallTime));
                    command.Parameters.AddWithValue("@CustomerDetailId", Convert.ToInt32(dailyCall.CustomerDetailId));
                    command.Parameters.AddWithValue("@CallDuration", Convert.ToInt32(dailyCall.CallDuration));
                    command.Parameters.AddWithValue("@CallRemark", dailyCall.CallRemark);
                    command.Parameters.AddWithValue("@WhatsAppRemark", dailyCall.WhatsAppRemark);
                    command.Parameters.AddWithValue("@SMSRemark", dailyCall.SMSRemark);
                    command.Parameters.AddWithValue("@EmailRemark", dailyCall.EmailRemark);
                    command.Parameters.AddWithValue("@CallStatusID", Convert.ToInt32(dailyCall.CallStatusID));
                    #endregion

                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DailyCallDetail GetDailyCallById(int id)
        {
            DailyCallDetail dailyCall = new DailyCallDetail();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT calls.DailyCallDetailId, calls.CallDate, calls.CallTime, calls.CustomerDetailId, cust.CustomerName, calls.CallDuration, calls.CallRemark, calls.WhatsAppRemark, calls.SMSRemark, calls.EmailRemark, calls.CallStatusID, sts.CallStatusName, calls.CreatedOnUTC, calls.CreatedBy, calls.LastUpdateOnUTC, calls.LastUpdateBy" +
                                " FROM TCS.DailyCallDetail calls INNER JOIN TCS.CustomerDetail cust ON cust.CustomerDetailId = calls.CustomerDetailId" +
                                " INNER JOIN TCS.CallStatus sts ON sts.CallStatusId = calls.CallStatusID";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MapReaderToDailyCall(reader, dailyCall);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dailyCall;
        }

        private void MapReaderToDailyCall(SqlDataReader reader,DailyCallDetail dailyCall)
        {
            dailyCall.DailyCallDetailId = Convert.ToInt32(reader["DailyCallDetailId"]);
            dailyCall.CallDate = Convert.ToDateTime(Convert.ToString(reader["CallDate"]));
            dailyCall.CallTime = Convert.ToDateTime(Convert.ToString(reader["CallTime"]));
            dailyCall.CallDuration = Convert.ToInt32(reader["CallDuration"]);
            dailyCall.CustomerDetailId = Convert.ToInt32(reader["CustomerDetailId"]);
            dailyCall.CustomerName = Convert.ToString(reader["CustomerName"]);
            dailyCall.CallRemark = Convert.ToString(reader["CallRemark"]);
            dailyCall.WhatsAppRemark = Convert.ToString(reader["WhatsAppRemark"]);
            dailyCall.SMSRemark = Convert.ToString(reader["SMSRemark"]);
            dailyCall.EmailRemark = Convert.ToString(reader["EmailRemark"]);
            dailyCall.CallStatusID = Convert.ToInt32(reader["CallStatusID"]);
            dailyCall.CallingStatus = Convert.ToString(reader["CallingStatus"]);
            dailyCall.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            dailyCall.LastUpdateBy = Convert.ToString(reader["LastUpdateBy"]);
            dailyCall.CreatedOnUTC = Convert.ToDateTime(reader["CreatedOnUTC"]);
            //LastUpdateOnUTC = reader["LastUpdateOnUTC"] != null
        }

        public int UpdateCallDetails(DailyCallDetail dailyCall)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE TCS.DailyCallDetail SET CallDate = @CallDate, CallTime = @CallTime, CustomerDetailId = @CustomerDetailId, CallDuration = @CallDuration, CallRemark = @CallRemark, WhatsAppRemark = @WhatsAppRemark, SMSRemark = @SMSRemark, EmailRemark = @EmailRemark, CallStatusID = @CallStatusID, LastUpdateOnUTC = GETUTCDATE(), LastUpdateBy = 'system', IsActive = @IsActive " +
                                " WHERE DailyCallDetailId = @DailyCallDetailId)";
                    command.CommandType = CommandType.Text;

                    #region Parameters
                    command.Parameters.AddWithValue("@DailyCallDetailId", Convert.ToInt32(dailyCall.DailyCallDetailId));
                    command.Parameters.AddWithValue("@CallDate", Convert.ToDateTime(dailyCall.CallDate));
                    command.Parameters.AddWithValue("@CallTime", Convert.ToDateTime(dailyCall.CallTime));
                    command.Parameters.AddWithValue("@CustomerDetailId", Convert.ToInt32(dailyCall.CustomerDetailId));
                    command.Parameters.AddWithValue("@CallDuration", Convert.ToInt32(dailyCall.CallDuration));
                    command.Parameters.AddWithValue("@CallRemark", dailyCall.CallRemark);
                    command.Parameters.AddWithValue("@WhatsAppRemark", dailyCall.WhatsAppRemark);
                    command.Parameters.AddWithValue("@SMSRemark", dailyCall.SMSRemark);
                    command.Parameters.AddWithValue("@EmailRemark", dailyCall.EmailRemark);
                    command.Parameters.AddWithValue("@CallStatusID", Convert.ToInt32(dailyCall.CallStatusID));
                    #endregion

                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}