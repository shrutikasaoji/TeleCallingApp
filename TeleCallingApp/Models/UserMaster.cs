using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.DBService;

namespace TeleCallingApp.Models
{
	public class UserMaster
	{
		public int UserMasterId { get; set; }
		public string UserId { get; set; }
		public string LoginPSWD { get; set; }
		public string FullName { get; set; }
		public string Mobile { get; set; }
		public string EmailID { get; set; }
		public DateTime DOJ { get; set; }
		public int RoleID { get; set; }
		public string RoleName { get; set; }
		public int ReportingUserId { get; set; }
		public string ReportingUser { get; set; }
		public DateTime LastLogin { get; set; }
		public string Photo { get; set; }
		public DateTime CreatedOnUTC { get; set; }
		public string CreatedBy { get; set; }
		public DateTime LastUpdateOnUTC { get; set; }
		public string LastUpdateBy { get; set; }
		public bool IsActive { get; set; }

		public List<SelectListItem> roles { get; set; }
		public List<SelectListItem> reportees { get; set; }

		public UserMaster()
        {
			roles = new List<SelectListItem>();
			reportees = new List<SelectListItem>();
		}
		//public UserMaster(int UserMasterId_, string UserId_, string LoginPSWD_, string FullName_, string Mobile_, string EmailID_, DateTime DOJ_, int RoleID_, int ReportingUserId_, DateTime LastLogin_, byte[] Photo_, DateTime CreatedOnUTC_, string CreatedBy_, DateTime LastUpdateOnUTC_, string LastUpdateBy_)
		//{
		//	this.UserMasterId = UserMasterId_;
		//	this.UserId = UserId_;
		//	this.LoginPSWD = LoginPSWD_;
		//	this.FullName = FullName_;
		//	this.Mobile = Mobile_;
		//	this.EmailID = EmailID_;
		//	this.DOJ = DOJ_;
		//	this.RoleID = RoleID_;
		//	this.ReportingUserId = ReportingUserId_;
		//	this.LastLogin = LastLogin_;
		//	this.Photo = Photo_;
		//	this.CreatedOnUTC = CreatedOnUTC_;
		//	this.CreatedBy = CreatedBy_;
		//	this.LastUpdateOnUTC = LastUpdateOnUTC_;
		//	this.LastUpdateBy = LastUpdateBy_;
		//}
	}
}