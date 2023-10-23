using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeleCallingApp.Models
{
	public class DailyCallDetail
	{
		public int DailyCallDetailId { get; set; }
		public DateTime CallDate { get; set; }
		public DateTime CallTime { get; set; }
		public int CustomerDetailId { get; set; }
		public string CustomerName { get; set; }
		public decimal CallDuration { get; set; }
		public string CallRemark { get; set; }
		public string WhatsAppRemark { get; set; }
		public string SMSRemark { get; set; }
		public string EmailRemark { get; set; }
		public string CallingStatus { get; set; }
		public int CallStatusID { get; set; }
		public DateTime CreatedOnUTC { get; set; }
		public string CreatedBy { get; set; }
		public DateTime LastUpdateOnUTC { get; set; }
		public string LastUpdateBy { get; set; }
		public bool IsActive { get; set; }

		public List<SelectListItem> customers { get; set; }
		public List<SelectListItem> statuses { get; set; }

		public DailyCallDetail()
        {
			customers = new List<SelectListItem>();
			statuses = new List<SelectListItem>();

		}
		//public DailyCallDetail(int DailyCallDetailId_, DateTime CallDate_, TimeSpan CallTime_, int CustomerDetailId_, decimal CallDuration_, string CallRemark_, string WhatsAppRemark_, string SMSRemark_, string EmailRemark_, int CallingStatus_, DateTime CreatedOnUTC_, string CreatedBy_, DateTime LastUpdateOnUTC_, string LastUpdateBy_)
		//{
		//	this.DailyCallDetailId = DailyCallDetailId_;
		//	this.CallDate = CallDate_;
		//	this.CallTime = CallTime_;
		//	this.CustomerDetailId = CustomerDetailId_;
		//	this.CallDuration = CallDuration_;
		//	this.CallRemark = CallRemark_;
		//	this.WhatsAppRemark = WhatsAppRemark_;
		//	this.SMSRemark = SMSRemark_;
		//	this.EmailRemark = EmailRemark_;
		//	this.CallingStatus = CallingStatus_;
		//	this.CreatedOnUTC = CreatedOnUTC_;
		//	this.CreatedBy = CreatedBy_;
		//	this.LastUpdateOnUTC = LastUpdateOnUTC_;
		//	this.LastUpdateBy = LastUpdateBy_;
		//}
	}
}