using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeleCallingApp.Models
{
	public class LeadDetail
	{
		public int LeadDetailId { get; set; }
		public string LeadId { get; set; }
		public string SerialNumber { get; set; }
		public int CustomerDetailId { get; set; }
		public CustomerDetail customer { get; set; }
		public string ProviderName { get; set; }
		public DateTime CreatedOnUTC { get; set; }
		public string CreatedBy { get; set; }
		public DateTime LastUpdateOnUTC { get; set; }
		public string LastUpdateBy { get; set; }
		public DateTime AssignedDate { get; set; }
		public int AssignedTo { get; set; }
		public string AssignedToUser { get; set; }
		public string Assignment_Remarks { get; set; }
		public List<SelectListItem> customers { get; set; }
		public List<SelectListItem> assignmentUsers { get; set; }
		public LeadDetail()
        {
			customer = new CustomerDetail();
			customers = new List<SelectListItem>();
			assignmentUsers = new List<SelectListItem>();
		}
	}
}