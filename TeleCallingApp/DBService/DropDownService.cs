using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.Interfaces;
using TeleCallingApp.Models;

namespace TeleCallingApp.DBService
{
    public class DropDownService
    {
        private UserMasterService _userDbService;
        private RoleService _roleDbService;
        public DropDownService(UserMasterService userDbService, RoleService roleDbService)
        {
            _userDbService = userDbService;
            _roleDbService = roleDbService;

        }

        public List<SelectListItem> GetRoleDropDown()
        {
            RoleService roleService = new RoleService();
            List<SelectListItem> roles = new List<SelectListItem> { new SelectListItem { Text = "Select", Value = "0" } };
            roles.AddRange(_roleDbService.GetAllRoleMasters().Select(x => new SelectListItem() { Text = x.RoleName, Value = x.RoleMasterId.ToString() }).ToList());
            return roles;
        }

        public List<SelectListItem> GetUserDropDown()
        {
            UserMasterService _userDbService = new UserMasterService();
            List<SelectListItem> userMasters = new List<SelectListItem> { new SelectListItem { Text = "Select", Value = "0" } };
            userMasters.AddRange(_userDbService.GetAllUserMasteres().Select(x => new SelectListItem() { Text = x.FullName, Value = x.UserMasterId.ToString() }).ToList());
            return userMasters;
        }
    }
}