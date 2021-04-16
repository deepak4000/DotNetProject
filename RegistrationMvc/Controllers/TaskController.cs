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
    public class TaskController : Controller
    {
        private UserLoginEntities db = new UserLoginEntities();

        // GET: Task
        public ActionResult Index()
        {
            return View(db.tbl_task.ToList());
        }

        // GET: TaskCrud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_task tbl_task = db.tbl_task.Find(id);
            if (tbl_task == null)
            {
                return HttpNotFound();
            }
            return View(tbl_task);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TaskName,IsActive,DateCreated,DateModified,DateDeleted")] tbl_task tbl_task)
        {
            if (ModelState.IsValid)
            {
                db.tbl_task.Add(tbl_task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_task);
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_task tbl_task = db.tbl_task.Find(id);
            if (tbl_task == null)
            {
                return HttpNotFound();
            }
            return View(tbl_task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TaskName,IsActive,DateCreated,DateModified,DateDeleted")] tbl_task tbl_task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_task);
        }

        // GET: task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_task tbl_task = db.tbl_task.Find(id);
            if (tbl_task == null)
            {
                return HttpNotFound();
            }
            return View(tbl_task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_task tbl_task = db.tbl_task.Find(id);
            db.tbl_task.Remove(tbl_task);
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
