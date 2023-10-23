using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.DBService;
using TeleCallingApp.Models;

namespace TeleCallingApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerService _dbService;
        public CustomerController()
        {
            _dbService = new CustomerService();
        }
        // GET: Customer
        public ActionResult Index()
        {
            List<CustomerDetail> customers = _dbService.GetAllCustomeres();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View(new CustomerDetail());
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int updateReturn = _dbService.AddCustomerDetails(MapFormCollectionToCustomer(collection));
                if (updateReturn == 0)
                {
                    ViewBag.Error = "Something went wrong. Try again!";
                    return View("Edit", MapFormCollectionToCustomer(collection));
                }
            }
            catch
            {
                ViewBag.Error = "Something went wrong. Try again!";
                return View("Edit", MapFormCollectionToCustomer(collection));
            }
            return View("Index");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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

        private CustomerDetail MapFormCollectionToCustomer(FormCollection collection)
        {
            return new CustomerDetail {
                CustomerDetailId = Convert.ToInt32(collection["CustomerDetailId"]),
                CustomerName = collection["CustomerName"],
                CustMobile = collection["CustMobile"],
                CustEmail = collection["CustEmail"],
                CustAddress = collection["CustAddress"],
                CustPincode = collection["CustPincode"],
                CustCity = collection["CustCity"]
            };
        }
    }
}
