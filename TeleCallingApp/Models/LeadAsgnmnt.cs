using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleCallingApp.Models
{
	public class LeadAsgnmnt
	{
		public int LeadAsgnmntId { get; set; }
		public DateTime LeadAssignedDate { get; set; }
		public int LeadId { get; set; }
		public int UserId { get; set; }
		public DateTime CreatedOnUTC { get; set; }
		public string CreatedBy { get; set; }
		public DateTime LastUpdateOnUTC { get; set; }
		public string LastUpdateBy { get; set; }
		public bool IsActive { get; set; }
		public LeadAsgnmnt(int LeadAsgnmntId_, DateTime LeadAssignedDate_, int LeadId_, int UserId_, DateTime CreatedOnUTC_, string CreatedBy_, DateTime LastUpdateOnUTC_, string LastUpdateBy_)
		{
			this.LeadAsgnmntId = LeadAsgnmntId_;
			this.LeadAssignedDate = LeadAssignedDate_;
			this.LeadId = LeadId_;
			this.UserId = UserId_;
			this.CreatedOnUTC = CreatedOnUTC_;
			this.CreatedBy = CreatedBy_;
			this.LastUpdateOnUTC = LastUpdateOnUTC_;
			this.LastUpdateBy = LastUpdateBy_;
		}
	}
}