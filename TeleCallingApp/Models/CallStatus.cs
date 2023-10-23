using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleCallingApp.Models
{
	public class CallStatus
	{
		public int CallStatusId { get; set; }
		public string CallStatusName { get; set; }
		public string CallStatusDesc { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedOnUTC { get; set; }
		public string CreatedBy { get; set; }
		public DateTime LastUpdateOnUTC { get; set; }
		public string LastUpdateBy { get; set; }

		//public CallStatus(int CallStatusId_, string CallStatusName_, string CallStatusDesc_, bool IsActive_, DateTime CreatedOnUTC_, string CreatedBy_, DateTime LastUpdateOnUTC_, string LastUpdateBy_)
		//{
		//	this.CallStatusId = CallStatusId_;
		//	this.CallStatusName = CallStatusName_;
		//	this.CallStatusDesc = CallStatusDesc_;
		//	this.IsActive = IsActive_;
		//	this.CreatedOnUTC = CreatedOnUTC_;
		//	this.CreatedBy = CreatedBy_;
		//	this.LastUpdateOnUTC = LastUpdateOnUTC_;
		//	this.LastUpdateBy = LastUpdateBy_;
		//}
	}
}