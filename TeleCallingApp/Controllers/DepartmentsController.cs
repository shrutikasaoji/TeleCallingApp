using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TeleCallingApp;

namespace TeleCallingApp.Controllers
{
    public class DepartmentsController : ApiController
    {
        private ArohiInfoDBEntities db = new ArohiInfoDBEntities();

        // GET: api/Departments
        public IQueryable<tblDepartment> GettblDepartments()
        {
            return db.tblDepartments;
        }

        // GET: api/Departments/5
        [ResponseType(typeof(tblDepartment))]
        public IHttpActionResult GettblDepartment(int id)
        {
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            return Ok(tblDepartment);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblDepartment(int id, tblDepartment tblDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblDepartment.ID)
            {
                return BadRequest();
            }

            db.Entry(tblDepartment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblDepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Departments
        [ResponseType(typeof(tblDepartment))]
        public IHttpActionResult PosttblDepartment(tblDepartment tblDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblDepartments.Add(tblDepartment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblDepartment.ID }, tblDepartment);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(tblDepartment))]
        public IHttpActionResult DeletetblDepartment(int id)
        {
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            db.tblDepartments.Remove(tblDepartment);
            db.SaveChanges();

            return Ok(tblDepartment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblDepartmentExists(int id)
        {
            return db.tblDepartments.Count(e => e.ID == id) > 0;
        }
    }
}