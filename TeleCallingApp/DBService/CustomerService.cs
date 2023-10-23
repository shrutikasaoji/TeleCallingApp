using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TeleCallingApp.Models;

namespace TeleCallingApp.DBService
{
    public class CustomerService
    {
        DBConnection _connection;
        public CustomerService()
        {
            _connection = new DBConnection();
        }
        public List<CustomerDetail> GetAllCustomeres()
        {
            List<CustomerDetail> users = new List<CustomerDetail>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT CustomerDetailId, CustomerName, CustMobile, CustEmail, CustAddress, CustPincode, CustCity, CreatedOnUTC, CreatedBy, LastUpdateOnUTC, LastUpdateBy FROM TCS.CustomerDetail";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(MapReaderToCustomer(reader));
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return users;
        }

        public  CustomerDetail GetCustomerById(int id)
        {
            CustomerDetail user = new CustomerDetail();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT CustomerDetailId, CustomerName, CustMobile, CustEmail, CustAddress, CustPincode, CustCity, CreatedOnUTC, CreatedBy, LastUpdateOnUTC, LastUpdateBy "+
                        " FROM TCS.CustomerDetail WHERE CustomerDetailId = "+ id.ToString();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = MapReaderToCustomer(reader);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return user;
        }

        public CustomerDetail MapReaderToCustomer(SqlDataReader reader)
        {
            return new CustomerDetail
            {
                CustomerDetailId = Convert.ToInt32(reader["CustomerDetailId"]),
                CustomerName = Convert.ToString(reader["CustomerName"]),
                CustMobile = Convert.ToString(reader["CustMobile"]),
                CustAddress = Convert.ToString(reader["CustAddress"]),
                CustPincode = Convert.ToString(reader["CustPincode"]),
                CustCity = Convert.ToString(reader["CustCity"]),
                CreatedBy = Convert.ToString(reader["CreatedBy"]),
                LastUpdateBy = Convert.ToString(reader["LastUpdateBy"]),
                CreatedOnUTC = Convert.ToDateTime(reader["CreatedOnUTC"])
                //LastUpdateOnUTC = reader["LastUpdateOnUTC"] != null
            };
        }

        public int AddCustomerDetails(CustomerDetail customer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO TCS.CustomerDetail(CustomerName, CustMobile, CustEmail, CustAddress, CustPincode, CustCity, CreatedOnUTC, CreatedBy, IsActive)" +
                                " VALUES(@CustomerName, @CustMobile, @CustEmail, @CustAddress, @CustPincode, @CustCity, GETUTCDATE(), 'system', 1)";
                    command.CommandType = CommandType.Text;

                    #region Parameters
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@CustMobile", customer.CustMobile);
                    command.Parameters.AddWithValue("@CustEmail", customer.CustEmail);
                    command.Parameters.AddWithValue("@CustAddress", customer.CustAddress);
                    command.Parameters.AddWithValue("@CustPincode", customer.CustPincode);
                    command.Parameters.AddWithValue("@CustCity", customer.CustCity);
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

        public int UpdateCustomerDetails(CustomerDetail customer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE TCS.CustomerDetail CustomerName = @CustomerName, CustMobile = @CustMobile, CustEmail = @CustEmail, CustAddress = @CustAddress, CustPincode = @CustPincode, CustCity = @CustCity, LastUpdateOnUTC = GETUTCTIME(), LastUpdateBy = 'system', IsActive = 1" +
                                " CustomerDetailId = @CustomerDetailId";
                    command.CommandType = CommandType.Text;

                    #region Parameters
                    command.Parameters.AddWithValue("@CustomerDetailId", Convert.ToInt32(customer.CustomerDetailId));
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@CustMobile", customer.CustMobile);
                    command.Parameters.AddWithValue("@CustEmail", customer.CustEmail);
                    command.Parameters.AddWithValue("@CustPincode", customer.CustPincode);
                    command.Parameters.AddWithValue("@CustCity", customer.CustCity);
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