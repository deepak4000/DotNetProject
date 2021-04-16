using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationMvc.Models;
using System.Net;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace RegistrationMvc.Controllers
{
    public class TimeController : Controller
    {
        private UserLoginEntities db = new UserLoginEntities();

        // GET: Time
        public ActionResult Index()
        {
            GetTask();
            GetProject();
            var tbl_TimeEntry = db.tbl_TimeEntry.Include(t => t.tbl_Project).Include(t => t.tbl_task);
            return View(tbl_TimeEntry.ToList());

        }
        // GET:Time/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TimeEntry tbl_TimeEntry = db.tbl_TimeEntry.Find(id);
            if (tbl_TimeEntry == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TimeEntry);
        }


        // GET: Time/Create
        public ActionResult Create()
        {
            ViewBag.Projectid = new SelectList(db.tbl_Project, "id", "ProjectName");
            ViewBag.Taskid = new SelectList(db.tbl_task, "id", "TaskName");
            return View();
        }

        // POST: Time/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserName,Projectid,Taskid,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,Total,IsDeleted,DateCreated,DateModified,DateDeleted")] tbl_TimeEntry tbl_TimeEntry)
        {
            if (ModelState.IsValid)
            {
                db.tbl_TimeEntry.Add(tbl_TimeEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Projectid = new SelectList(db.tbl_Project, "id", "ProjectName", tbl_TimeEntry.Projectid);
            ViewBag.Taskid = new SelectList(db.tbl_task, "id", "TaskName", tbl_TimeEntry.Taskid);
            return View(tbl_TimeEntry);
        }

        // GET: Time/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TimeEntry tbl_TimeEntry = db.tbl_TimeEntry.Find(id);
            if (tbl_TimeEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.Projectid = new SelectList(db.tbl_Project, "id", "ProjectName", tbl_TimeEntry.Projectid);
            ViewBag.Taskid = new SelectList(db.tbl_task, "id", "TaskName", tbl_TimeEntry.Taskid);
            return View(tbl_TimeEntry);
        }

        // POST: Time/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserName,Projectid,Taskid,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,Total,IsDeleted,DateCreated,DateModified,DateDeleted")] tbl_TimeEntry tbl_TimeEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_TimeEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Projectid = new SelectList(db.tbl_Project, "id", "ProjectName", tbl_TimeEntry.Projectid);
            ViewBag.Taskid = new SelectList(db.tbl_task, "id", "TaskName", tbl_TimeEntry.Taskid);
            return View(tbl_TimeEntry);
        }

        // GET: Time/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TimeEntry tbl_TimeEntry = db.tbl_TimeEntry.Find(id);
            if (tbl_TimeEntry == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TimeEntry);
        }

        // POST: Time/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tbl_TimeEntry tbl_TimeEntry = db.tbl_TimeEntry.Find(id);
            db.tbl_TimeEntry.Remove(tbl_TimeEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetProject()
        {
            UserLoginEntities context = new UserLoginEntities();
            List<tbl_Project> projectsList = context.tbl_Project.ToList();

            ViewBag.Projectid = new SelectList(projectsList, "id", "ProjectName");
            return View(projectsList.ToList());

        }


        [HttpGet]
        public ActionResult GetTask()
        {

            UserLoginEntities context = new UserLoginEntities();
            List<tbl_task> tasksList = context.tbl_task.ToList();

            ViewBag.Taskid = new SelectList(tasksList, "id", "TaskName");
            return View(tasksList.ToList());

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

