using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.DBService;
using TeleCallingApp.Models;

namespace TeleCallingApp.Controllers
{
    public class CallStatusController : Controller
    {
        CallStatusService _dbService;

        public CallStatusController()
        {
            _dbService = new CallStatusService();
        }
        // GET: CallStatus
        public ActionResult Index()
        {
            List<CallStatus> statuses = _dbService.GetAllCallStatuses();
            return View(statuses);
        }

        // GET: CallStatus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CallStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CallStatus/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CallStatus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CallStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CallStatus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CallStatus/Delete/5
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
    }
}
