using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.Interfaces;
using TeleCallingApp.Models;

namespace TeleCallingApp.DBService
{
    public class RoleService: IDBService
    {
        DBConnection _connection;
        public RoleService()
        {
            _connection = new DBConnection();
        }
        public List<RoleMaster> GetAllRoleMasters()
        {
            List<RoleMaster> roleMasters = new List<RoleMaster>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM TCS.RoleMaster";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        roleMasters.Add(MapReaderToRoleMaster(reader));
                    }                    
                }
            }
            catch(Exception ex)
            {

            }

            return roleMasters;
        } 

        public void CreateRoleMaster(RoleMaster role)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }

        }

        public List<SelectListItem> GetRoleDropDown()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            roles.AddRange(GetAllRoleMasters().Select(x => new SelectListItem() { Text = x.RoleName, Value = x.RoleMasterId.ToString() }).ToList());
            return roles;
        }

        public RoleMaster GetRoleMasterById(int id)
        {
            RoleMaster role = new RoleMaster();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM TCS.RoleMaster WHERE RoleMasterId = "+id.ToString();
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        role = MapReaderToRoleMaster(reader);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return role;
        }

        public int UpdateRoleMaster(RoleMaster role)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE TCS.RoleMaster "+
                        "SET RoleName = @RoleName, RoleDesc = @RoleDesc, LastUpdateOnUTC = GETUTCDATE(), LastUpdateBy = 'system' "+
                        "WHERE RoleMasterId = @RoleMasterId";
                    command.CommandType = CommandType.Text;
                    MapRoleMasterParameters(command.Parameters, role);
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

        private void MapRoleMasterParameters(SqlParameterCollection collection,RoleMaster role)
        {
            collection.AddWithValue("@RoleName", role.RoleName);
            collection.AddWithValue("@RoleDesc", role.RoleDesc);
            collection.AddWithValue("@RoleMasterId", role.RoleMasterId);
        }
        private RoleMaster MapReaderToRoleMaster(SqlDataReader reader)
        {
            return new RoleMaster
            {
                RoleMasterId = Convert.ToInt32(reader["RoleMasterId"]),
                RoleId = Convert.ToString(reader["RoleId"]),
                RoleName = Convert.ToString(reader["RoleName"]),
                RoleDesc = Convert.ToString(reader["RoleDesc"]),
                CreatedBy = Convert.ToString(reader["CreatedBy"]),
                LastUpdateBy = Convert.ToString(reader["LastUpdateBy"]),
                CreatedOnUTC = Convert.ToDateTime(reader["CreatedOnUTC"])
                //LastUpdateOnUTC = reader["LastUpdateOnUTC"] != null
            };
        }
    }
}