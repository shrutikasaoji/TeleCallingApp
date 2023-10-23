using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.DBService;
using TeleCallingApp.Models;

namespace TeleCallingApp.Controllers
{
    public class DailyCallController : Controller
    {
        DailyCallService _dbService;
        CustomerService _dbCustomerService;
        CallStatusService _dbStatusService;
        public DailyCallController()
        {
            _dbService = new DailyCallService();
            _dbCustomerService = new CustomerService();
            _dbStatusService = new CallStatusService();
        }
        // GET: DailyCall
        public ActionResult Index()
        {
            List<DailyCallDetail> calls = _dbService.GetAllDailyCalls();
            return View(calls);
        }

        // GET: DailyCall/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DailyCall/Create
        public ActionResult AddCallDetail()
        {
            DailyCallDetail dailyCall = new DailyCallDetail {
                customers = _dbCustomerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList(),
                statuses = _dbStatusService.GetAllCallStatuses().Select(x => new SelectListItem() { Text = x.CallStatusName, Value = x.CallStatusId.ToString() }).ToList()
            };
            return View(dailyCall);
        }

        // POST: DailyCall/Create
        [HttpPost]
        public ActionResult AddCallDetail(FormCollection collection)
        {
            try
            {
                int rowAffected = _dbService.AddCallDetails(MapFormCollectionToDailyCall(collection));
                if (rowAffected == 0)
                {
                    ViewBag.Error = "Something went wrong! Please try again!";
                    DailyCallDetail dailyCall = MapFormCollectionToDailyCall(collection);
                    dailyCall.customers = _dbCustomerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList();
                    dailyCall.statuses = _dbStatusService.GetAllCallStatuses().Select(x => new SelectListItem() { Text = x.CallStatusName, Value = x.CallStatusId.ToString() }).ToList();


                    return View("AddCallDetail", dailyCall);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Something went wrong! Please try again!";
                DailyCallDetail dailyCall = MapFormCollectionToDailyCall(collection);
                dailyCall.customers = _dbCustomerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList();
                dailyCall.statuses = _dbStatusService.GetAllCallStatuses().Select(x => new SelectListItem() { Text = x.CallStatusName, Value = x.CallStatusId.ToString() }).ToList();

                return View("AddCallDetail", dailyCall);
            }
            return RedirectToAction("Index");
        }

        // GET: DailyCall/Edit/5
        public ActionResult Edit(int id)
        {
            DailyCallDetail dailyCall = _dbService.GetDailyCallById(id);

            dailyCall.customers = _dbCustomerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList();
            dailyCall.statuses = _dbStatusService.GetAllCallStatuses().Select(x => new SelectListItem() { Text = x.CallStatusName, Value = x.CallStatusId.ToString() }).ToList();
          
           return View(dailyCall);
        }

        // POST: DailyCall/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            DailyCallDetail dailyCall = MapFormCollectionToDailyCall(collection);
            try
            {                
                int rowAffected = _dbService.UpdateCallDetails(dailyCall);
                if (rowAffected == 0)
                {
                    ViewBag.Error = "Something went wrong! Please try again!";
                    dailyCall.customers = _dbCustomerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList();
                    dailyCall.statuses = _dbStatusService.GetAllCallStatuses().Select(x => new SelectListItem() { Text = x.CallStatusName, Value = x.CallStatusId.ToString() }).ToList();
                    return RedirectToAction("Edit", dailyCall);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Something went wrong! Please try again!";
                dailyCall.customers = _dbCustomerService.GetAllCustomeres().Select(x => new SelectListItem() { Text = x.CustomerName, Value = x.CustomerDetailId.ToString() }).ToList();
                dailyCall.statuses = _dbStatusService.GetAllCallStatuses().Select(x => new SelectListItem() { Text = x.CallStatusName, Value = x.CallStatusId.ToString() }).ToList();
                return RedirectToAction("Edit", dailyCall);
            }
            return RedirectToAction("Index");
        }

        // GET: DailyCall/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DailyCall/Delete/5
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

        private DailyCallDetail MapFormCollectionToDailyCall(FormCollection collection)
        {
            DailyCallDetail dailyCallDetail = new DailyCallDetail();
            dailyCallDetail.DailyCallDetailId= Convert.ToInt32(collection ["DailyCallDetailId"]);
            dailyCallDetail.CallDate = Convert.ToDateTime(collection["CallDate"]);
            dailyCallDetail.CallTime = Convert.ToDateTime(collection["CallTime"]);
            dailyCallDetail.CustomerDetailId= string.IsNullOrEmpty(collection ["CustomerDetailId"])?0: Convert.ToInt32(collection["CustomerDetailId"]);
            dailyCallDetail.CallDuration = Convert.ToDecimal(collection["CallDuration"]);
            dailyCallDetail.CallRemark = collection["CallRemark"];
            dailyCallDetail.WhatsAppRemark = collection["WhatsAppRemark"];
            dailyCallDetail.EmailRemark = collection["EmailRemark"];
            dailyCallDetail.SMSRemark = collection["SMSRemark"];
            dailyCallDetail.CallStatusID = Convert.ToInt32(collection["CallStatusID"]);
            return dailyCallDetail;
        }
    }
}
