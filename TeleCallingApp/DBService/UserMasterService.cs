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
    public interface IUserDBService : IDBService
    {
        List<UserMaster> GetAllUserMasteres();
    }
    public class UserMasterService : IDBService
    {
        DBConnection _connection;
        IDBService _dBService;
        public UserMasterService()
        {
            _connection = new DBConnection();
        }
        public List<UserMaster> GetAllUserMasteres()
        {
            List<UserMaster> users = new List<UserMaster>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT um.UserMasterId, um.UserId, um.LoginPSWD, um.FullName, um.Mobile, um.EmailID, um.DOJ, um.RoleID,rm.RoleName,um.ReportingUserId,rep.FullName AS 'ReportingUser'," +
                            "um.LastLogin, um.Photo, um.CreatedOnUTC, um.CreatedBy, um.LastUpdateOnUTC, um.LastUpdateBy " +
                            "FROM TCS.Usermaster um INNER JOIN tcs.RoleMaster rm ON rm.RoleMasterId = um.RoleID " +
                                "LEFT join TCS.UserMaster rep ON rep.UserMasterId = um.ReportingUserId";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(MapReaderToUserMaster(reader));
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return users;
        }

        public List<SelectListItem> GetUserDropDown()
        {
            List<SelectListItem> userMasters = new List<SelectListItem>();
            userMasters.AddRange(GetAllUserMasteres().Select(x => new SelectListItem() { Text = x.FullName, Value = x.UserMasterId.ToString() }).ToList());
            return userMasters;
        }

        public UserMaster DummyUser()
        {
            RoleService roleService = new RoleService();
            List<SelectListItem> roles = new List<SelectListItem> { new SelectListItem { Text = "Select", Value = "0" } };
                roles.AddRange(roleService.GetAllRoleMasters().Select(x => new SelectListItem() { Text = x.RoleName, Value = x.RoleMasterId.ToString() }).ToList());
            List<SelectListItem> userMasters = new List<SelectListItem> { new SelectListItem { Text = "Select", Value = "0" } }; 
                userMasters.AddRange(GetAllUserMasteres().Select(x => new SelectListItem() { Text = x.FullName, Value = x.UserMasterId.ToString() }).ToList());
            return new UserMaster 
                    { 
                    roles = roles, 
                    reportees = userMasters 
                    };
        }

        public int AddNewUserMaster(UserMaster user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection._conString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO TCS.UserMaster( UserId, LoginPSWD, FullName, Mobile, EmailID, DOJ, RoleID, ReportingUserId, Photo, CreatedOnUTC, CreatedBy, IsActive)" +
                        "VALUES(@UserId, @LoginPSWD, @FullName, @Mobile, @EmailID, @DOJ, @RoleID, @ReportingUserId, @Photo, GETUTCDATE(),'system', 1)";
                    command.CommandType = CommandType.Text;

                    #region Parameters
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@LoginPSWD", user.LoginPSWD);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@Mobile", user.Mobile);
                    command.Parameters.AddWithValue("@EmailID", user.EmailID);
                    command.Parameters.AddWithValue("@DOJ", user.DOJ);
                    command.Parameters.AddWithValue("@RoleID", user.RoleID);
                    command.Parameters.AddWithValue("@ReportingUserId", user.ReportingUserId);
                    command.Parameters.AddWithValue("@Photo", Convert.FromBase64String(user.Photo));
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
        private UserMaster MapReaderToUserMaster(SqlDataReader reader)
        {
            UserMaster user = new UserMaster();
            user.UserMasterId = Convert.ToInt32(reader["UserMasterId"]);
            user.UserId = Convert.ToString(reader["UserId"]);
            user.FullName = Convert.ToString(reader["FullName"]);
            user.EmailID = Convert.ToString(reader["EmailID"]);
            user.Mobile = Convert.ToString(reader["Mobile"]);
            user.DOJ = Convert.ToDateTime(Convert.ToString(reader["DOJ"]));
            user.LastLogin = Convert.ToDateTime(Convert.ToString(reader["LastLogin"]));
            user.LoginPSWD = Convert.ToString(reader["LoginPSWD"]);
            user.Photo = Convert.ToString(reader["Photo"]);
            user.RoleID = Convert.ToInt32(reader["RoleID"]);
            user.ReportingUserId = Convert.ToInt32(reader["ReportingUserId"]);
            user.RoleName = Convert.ToString(reader["RoleName"]);
            user.ReportingUser = Convert.ToString(reader["ReportingUser"]);
            user.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            user.LastUpdateBy = Convert.ToString(reader["LastUpdateBy"]);
            user.CreatedOnUTC = Convert.ToDateTime(reader["CreatedOnUTC"]);
            return user;
        }
    }
}