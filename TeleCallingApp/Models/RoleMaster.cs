using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleCallingApp.Models
{
	public class RoleMaster
	{
		public int RoleMasterId { get; set; }
		public string RoleId { get; set; }
		public string RoleName { get; set; }
		public string RoleDesc { get; set; }
		public DateTime CreatedOnUTC { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? LastUpdateOnUTC { get; set; }
		public string LastUpdateBy { get; set; }
		public bool IsActive { get; set; }
		//public RoleMaster();
		//public RoleMaster(int RoleMasterId_, string RoleId_, string RoleName_, string RoleDesc_, DateTime CreatedOnUTC_, string CreatedBy_, DateTime LastUpdateOnUTC_, string LastUpdateBy_)
		//{
		//	this.RoleMasterId = RoleMasterId_;
		//	this.RoleId = RoleId_;
		//	this.RoleName = RoleName_;
		//	this.RoleDesc = RoleDesc_;
		//	this.CreatedOnUTC = CreatedOnUTC_;
		//	this.CreatedBy = CreatedBy_;
		//	this.LastUpdateOnUTC = LastUpdateOnUTC_;
		//	this.LastUpdateBy = LastUpdateBy_;
		//}
	}
}