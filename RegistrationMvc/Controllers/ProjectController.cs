using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationMvc.Models;
using System.Data.Entity;
using System.Net;

namespace RegistrationMvc.Controllers
{
    public class ProjectController : Controller
    {
        private UserLoginEntities db = new UserLoginEntities();

        // GET: Project
        public ActionResult Index()
        {
            return View(db.tbl_Project.ToList());
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Project tbl_Project = db.tbl_Project.Find(id);
            if (tbl_Project == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ProjectName,IsActive,DateCreated,DateModified,DateDeleted")] tbl_Project tbl_Project)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Project.Add(tbl_Project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Project tbl_Project = db.tbl_Project.Find(id);
            if (tbl_Project == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ProjectName,IsActive,DateCreated,DateModified,DateDeleted")] tbl_Project tbl_Project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Project tbl_Project = db.tbl_Project.Find(id);
            if (tbl_Project == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Project tbl_Project = db.tbl_Project.Find(id);
            db.tbl_Project.Remove(tbl_Project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
