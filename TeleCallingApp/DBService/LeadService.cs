using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.Models;

namespace TeleCallingApp.DBService
{
    public class LeadService
    {
        DBConnection _connection;
        CustomerService customerService;
        public LeadService()
        {
            _connection = new DBConnection();
            customerService = new CustomerService();
        }
        public List<LeadDetail> GetAllLeads()
        {
            List<LeadDetail> leads = new List<LeadDetail>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = command.CommandText = "SELECT leads.LeadDetailId, leads.LeadId, leads.SerialNumber, leads.CustomerDetailId, leads.ProviderName,leads.AssignedTo,um.FullName AS 'AssignedToUser', leads.AssignedDate,leads.Assignment_Remarks, leads.CreatedOnUTC, leads.CreatedBy, leads.LastUpdateOnUTC, leads.LastUpdateBy, leads.IsActive," +
                            " cust.CustomerName, cust.CustMobile, cust.CustEmail, cust.CustAddress, cust.CustPincode, cust.CustCity" +
                            " FROM TCS.LeadDetail leads INNER JOIN TCS.CustomerDetail cust ON cust.CustomerDetailId = leads.CustomerDetailId"+
                            " LEFT JOIN TCS.UserMaster um ON um.UserMasterId = leads.AssignedTo";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        leads.Add(MapReaderToLead(reader));
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return leads;
        }

        public List<SelectListItem> GetCustomerDropDown()
        {
            List<SelectListItem> customers = new List<SelectListItem>();
            customers.AddRange(customerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList());
            return customers;
        }

        public int AddNewLead(LeadDetail lead)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO TCS.LeadDetail( LeadId, SerialNumber, CustomerDetailId, ProviderName,AssignedTo,AssignedDate,Assignment_Remarks, CreatedOnUTC, CreatedBy, IsActive )" +
                        " VALUES(@LeadId, @SerialNumber, @CustomerDetailId, @ProviderName,@AssignedTo,null,@Assignment_Remarks, GETUTCDATE(), 'system', 1)";
                    command.CommandType = CommandType.Text;

                    #region Parameters
                    command.Parameters.AddWithValue("@LeadId", lead.LeadId);
                    command.Parameters.AddWithValue("@SerialNumber", lead.SerialNumber);
                    command.Parameters.AddWithValue("@CustomerDetailId", lead.CustomerDetailId);
                    command.Parameters.AddWithValue("@ProviderName", lead.ProviderName);
                    command.Parameters.AddWithValue("@AssignedTo", lead.AssignedTo);
                    //command.Parameters.AddWithValue("@AssignedDate", lead.AssignedDate);
                    command.Parameters.AddWithValue("@Assignment_Remarks", string.IsNullOrEmpty(lead.Assignment_Remarks)?"": lead.Assignment_Remarks);
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

        public LeadDetail GetLeadById(int id)
        {
            LeadDetail lead = new LeadDetail();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = command.CommandText = "SELECT leads.LeadDetailId, leads.LeadId, leads.SerialNumber, leads.CustomerDetailId, leads.ProviderName,leads.AssignedTo,um.FullName AS 'AssignedToUser', leads.AssignedDate,leads.Assignment_Remarks, leads.CreatedOnUTC, leads.CreatedBy, leads.LastUpdateOnUTC, leads.LastUpdateBy, leads.IsActive," +
                            " cust.CustomerName, cust.CustMobile, cust.CustEmail, cust.CustAddress, cust.CustPincode, cust.CustCity" +
                            " FROM TCS.LeadDetail leads INNER JOIN TCS.CustomerDetail cust ON cust.CustomerDetailId = leads.CustomerDetailId" +
                            " LEFT JOIN TCS.UserMaster um ON um.UserMasterId = leads.AssignedTo"+
                            " WHERE leads.LeadDetailId = "+id.ToString();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lead = MapReaderToLead(reader);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return lead;
        }

        public int UpdateLead(LeadDetail lead)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE TCS.LeadDetail " +
                        "SET LeadId = @LeadId, SerialNumber = @SerialNumber, CustomerDetailId = @CustomerDetailId, ProviderName = @ProviderName, AssignedDate = @AssignedDate, AssignedTo = @AssignedTo, Assignment_Remarks = @Assignment_Remarks, IsActive = @IsActive, LastUpdateOnUTC = GETUTCDATE(), LastUpdateBy = 'system' " +
                        "WHERE LeadDetailId = @LeadDetailId";
                    command.CommandType = CommandType.Text;

                    #region Parameters
                    command.Parameters.AddWithValue("@LeadId", lead.LeadId);
                    command.Parameters.AddWithValue("@SerialNumber", lead.SerialNumber);
                    command.Parameters.AddWithValue("@CustomerDetailId", lead.CustomerDetailId);
                    command.Parameters.AddWithValue("@ProviderName", lead.ProviderName);
                    command.Parameters.AddWithValue("@AssignedTo", lead.AssignedTo);
                    //command.Parameters.AddWithValue("@AssignedDate", lead.AssignedDate);
                    command.Parameters.AddWithValue("@Assignment_Remarks", string.IsNullOrEmpty(lead.Assignment_Remarks) ? "" : lead.Assignment_Remarks);
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

        private LeadDetail MapReaderToLead(SqlDataReader reader)
        {
            LeadDetail lead = new LeadDetail();
            if(reader["LeadDetailId"] != null)
                lead.LeadDetailId = Convert.ToInt32(reader["LeadDetailId"]);
            if (reader["CustomerDetailId"] != null)
                lead.CustomerDetailId = Convert.ToInt32(reader["CustomerDetailId"]);
            if (reader["LeadId"] != null)
                lead.LeadId = Convert.ToString(reader["LeadId"]);
            if (reader["SerialNumber"] != null)
                lead.SerialNumber = Convert.ToString(reader["SerialNumber"]);
            if (reader["ProviderName"] != null)
                lead.ProviderName = Convert.ToString(reader["ProviderName"]);
            if (reader["AssignedTo"] != null)
                lead.AssignedTo = Convert.ToInt32(reader["AssignedTo"]);
            //if (reader["AssignedDate"] != null)
            //    lead.AssignedDate = Convert.ToDateTime(reader["AssignedDate"]);
            if (reader["Assignment_Remarks"] != DBNull.Value)
                lead.Assignment_Remarks = Convert.ToString(reader["Assignment_Remarks"]);
            if (reader["AssignedToUser"] != null)
                lead.AssignedToUser = Convert.ToString(reader["AssignedToUser"]);
            if (reader["CustomerDetailId"] != null)
                lead.customer = customerService.MapReaderToCustomer(reader);
            if (reader["CreatedBy"] != null)
                lead.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            if (reader["LastUpdateBy"] != null)
                lead.LastUpdateBy = Convert.ToString(reader["LastUpdateBy"]);
            if (reader["CreatedOnUTC"] != null)
                lead.CreatedOnUTC = Convert.ToDateTime(reader["CreatedOnUTC"]);

            return lead;
        }
    }
}