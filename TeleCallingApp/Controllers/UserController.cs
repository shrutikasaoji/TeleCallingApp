using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.DBService;
using TeleCallingApp.Models;
using TeleCallingApp.Interfaces;

namespace TeleCallingApp.Controllers
{
    public class UserController : Controller
    {
        UserMasterService _dbService;
        RoleService _dbRoleService;
        public UserController()
        {
            _dbService = new UserMasterService();
            _dbRoleService = new RoleService();
        }
        // GET: User
        public ActionResult Index()
        {
            List<UserMaster> users = _dbService.GetAllUserMasteres();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        [ActionName("CreateUser")]
        public ActionResult Create()
        {
            UserMaster user = new UserMaster { roles = _dbRoleService.GetRoleDropDown(), reportees = _dbService.GetUserDropDown() };
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        [ActionName("CreateUser")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                UserMaster user = MapFormCollectionToUserMaster(collection);
                int insertedRec = _dbService.AddNewUserMaster(user);
                if (insertedRec == 0)
                {
                    ViewBag.Error = "Something went wrong! Try again!";
                    return View("CreateUser", user);
                }
            }
            catch
            {
                ViewBag.Error = "Something went wrong! Try again!";
            }
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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

        private UserMaster MapFormCollectionToUserMaster(FormCollection collection)
        {
            UserMaster user = new UserMaster();
            user.UserMasterId = Convert.ToInt32(collection["UserMasterId"]);
            user.UserId = Convert.ToString(collection["UserId"]);
            user.FullName = Convert.ToString(collection["FullName"]);
            user.EmailID = Convert.ToString(collection["EmailID"]);
            user.Mobile = Convert.ToString(collection["Mobile"]);
            user.DOJ = Convert.ToDateTime(Convert.ToString(collection["DOJ"]));
            user.LastLogin = Convert.ToDateTime(Convert.ToString(collection["LastLogin"]));
            user.LoginPSWD = Convert.ToString(collection["LoginPSWD"]);
            user.Photo = Convert.ToString(collection["Photo"]);
            user.RoleID = Convert.ToInt32(collection["RoleID"]);
            user.ReportingUserId = Convert.ToInt32(collection["ReportingUserId"]);

            return user;
        }
    }
}
