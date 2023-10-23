using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.DBService;
using TeleCallingApp.Models;

namespace TeleCallingApp.Controllers
{
    public class LeadController : Controller
    {
        LeadService _dbService;
        CustomerService _customerService;
        UserMasterService _userMasterService;
        public LeadController()
        {
            _dbService = new LeadService();
            _customerService = new CustomerService();
            _userMasterService = new UserMasterService();
        }
        // GET: Lead
        public ActionResult Index()
        {
            List<LeadDetail> leads = _dbService.GetAllLeads();
            return View(leads);
        }

        // GET: Lead/Details/5
        public ActionResult Details(int id)
        {
            LeadDetail lead = new LeadDetail
            {
                customers = _customerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList(),
                assignmentUsers = _userMasterService.GetAllUserMasteres().Select(x => new SelectListItem() { Text = x.FullName, Value = x.UserMasterId.ToString() }).ToList()
            };
            return View(lead);
        }

        // GET: Lead/Create
        public ActionResult Create()
        {
            LeadDetail lead = new LeadDetail
            {
                customers = _customerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList(),
                assignmentUsers = _userMasterService.GetAllUserMasteres().Select(x => new SelectListItem() { Text = x.FullName, Value = x.UserMasterId.ToString() }).ToList()
            };
            return View(lead);
        }

        // POST: Lead/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int rowAffected = _dbService.AddNewLead(MapFormCollectionToRoleMaster(collection));
                if (rowAffected == 0)
                {
                    ViewBag.Error = "Something went wrong! Please try again!";
                    LeadDetail lead = MapFormCollectionToRoleMaster(collection);
                    lead.customers = _customerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList();
                    
                    return View("Create", lead);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Something went wrong! Please try again!";
                LeadDetail lead = MapFormCollectionToRoleMaster(collection);
                lead.customers = _customerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList();

                return View("Create", lead);
            }
            return RedirectToAction("Index");
        }

        // GET: Lead/Edit/5
        public ActionResult Edit(int id)
        {
            LeadDetail lead = _dbService.GetLeadById(id);
            lead.customers = _customerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList();
            lead.assignmentUsers = _userMasterService.GetAllUserMasteres().Select(x => new SelectListItem() { Text = x.FullName, Value = x.UserMasterId.ToString() }).ToList();
            lead.customers.Where(x => x.Value == lead.CustomerDetailId.ToString()).ToList().ForEach(x => x.Selected = true);
            lead.assignmentUsers.Where(x => x.Value == lead.AssignedTo.ToString()).ToList().ForEach(x => x.Selected = true);
            return View(lead);
        }

        // POST: Lead/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                int updateReturn = _dbService.UpdateLead(MapFormCollectionToRoleMaster(collection));
                if (updateReturn == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Something went wrong. Try again!";
                    return View("Edit", MapFormCollectionToRoleMaster(collection));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Lead/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lead/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private LeadDetail MapFormCollectionToRoleMaster(FormCollection collection)
        {
            LeadDetail lead = new LeadDetail();
            lead.LeadId = collection["LeadId"];
            lead.SerialNumber = collection["SerialNumber"];
            lead.ProviderName = collection["ProviderName"];
            lead.LeadDetailId = Convert.ToInt32(collection["LeadDetailId"]);
            lead.CustomerDetailId = Convert.ToInt32(collection["CustomerDetailId"]);
            return lead;
        }
    }
}
