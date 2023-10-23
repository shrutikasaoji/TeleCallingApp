using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleCallingApp.DBService;
using TeleCallingApp.Models;

namespace TeleCallingApp.Controllers
{
    public class RoleMasterController : Controller
    {
        RoleService roleService;
        public RoleMasterController()
        {
            roleService = new RoleService();
        }
        // GET: RoleMaster
        public ActionResult Index()
        {
            List<RoleMaster> roles = roleService.GetAllRoleMasters();
            return View("RoleMasterList",roles);
        }

        // GET: RoleMaster/RoleDetail/5
        [ActionName("RoleDetail")]
        public ActionResult Details(int id)
        {
            return View("RoleDetail",roleService.GetRoleMasterById(id));
        }

        // GET: RoleMaster/CreateRole
        [ActionName("CreateRole")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleMaster/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here                
                if (ModelState.IsValid)
                {
                    roleService.CreateRoleMaster(MapFormCollectionToRoleMaster(collection));
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleMaster/Edit/5
        public ActionResult Edit(int id)
        {
            RoleMaster role = roleService.GetRoleMasterById(id);
            return View(role);
        }

        // POST: RoleMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                int updateReturn = roleService.UpdateRoleMaster(MapFormCollectionToRoleMaster(collection));
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

        // GET: RoleMaster/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: RoleMaster/Delete/5
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

        private RoleMaster MapFormCollectionToRoleMaster(FormCollection collection)
        {
            RoleMaster role = new RoleMaster();
            role.RoleId = collection["RoleId"];
            role.RoleName = collection["RoleName"];
            role.RoleDesc = collection["RoleDesc"];
            role.RoleMasterId = Convert.ToInt32(collection["RoleMasterId"]);
            return role;
        }
    }
}
