using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleCallingApp.Models
{
	public class CustomerDetail
	{
		public int CustomerDetailId { get; set; }
		public string CustomerName { get; set; }
		public string CustMobile { get; set; }
		public string CustEmail { get; set; }
		public string CustAddress { get; set; }
		public string CustPincode { get; set; }
		public string CustCity { get; set; }
		public DateTime CreatedOnUTC { get; set; }
		public string CreatedBy { get; set; }
		public DateTime LastUpdateOnUTC { get; set; }
		public string LastUpdateBy { get; set; }
		public bool IsActive { get; set; }

		//public CustomerDetail(int CustomerDetailId_, string CustomerName_, string CustMobile_, string CustEmail_, string CustAddress_, int CustPincode_, string CustCity_, DateTime CreatedOnUTC_, string CreatedBy_, DateTime LastUpdateOnUTC_, string LastUpdateBy_)
		//{
		//	this.CustomerDetailId = CustomerDetailId_;
		//	this.CustomerName = CustomerName_;
		//	this.CustMobile = CustMobile_;
		//	this.CustEmail = CustEmail_;
		//	this.CustAddress = CustAddress_;
		//	this.CustPincode = CustPincode_;
		//	this.CustCity = CustCity_;
		//	this.CreatedOnUTC = CreatedOnUTC_;
		//	this.CreatedBy = CreatedBy_;
		//	this.LastUpdateOnUTC = LastUpdateOnUTC_;
		//	this.LastUpdateBy = LastUpdateBy_;
		//}
	}
}