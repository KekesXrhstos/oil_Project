using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using EmployeeProject.Models;
using EmployeeProject.Models.DAL;
using EmployeeProject.ViewModels;

namespace EmployeeProject.Controllers
{
    public class DepartmentsController : Controller
    {
        private EmployeeProjectDbContext db = new EmployeeProjectDbContext();

        // GET: Departments
        public ActionResult Index(int? id, int? weeklyScheduleID, int? workDayID,int? shiftID,int? postID)
        {
            var viewModel = new DepartmentData();

            viewModel.Departments = db.Departments;


            if( id != null)
            {
                ViewBag.DepartmentID = id.Value;
                viewModel.WeeklySchedules = viewModel.Departments
                    .Where(d => d.ID == id.Value).Single().WeeklySchedules;
            }
            if( weeklyScheduleID != null)
            {
                ViewBag.WeeklyScheduleID = weeklyScheduleID.Value;
                viewModel.WorkDays = viewModel.WeeklySchedules
                    .Where(w => w.ID == weeklyScheduleID.Value).Single().WorkDays;
            }
            if( workDayID != null)
            {
                ViewBag.WorkDayID = workDayID.Value;
                viewModel.Shifts = viewModel.WorkDays
                    .Where(w => w.ID == workDayID.Value).Single().Shifts;
            }
            if( shiftID !=null)
            {
                ViewBag.ShiftID = shiftID.Value;
                viewModel.Posts = viewModel.Shifts
                    .Where(e => e.ID == shiftID.Value).Single().Posts;
            }
            if( postID !=null)
            {
                ViewBag.PostID = postID.Value;
                viewModel.Assignments = viewModel.Posts
                    .Where(p => p.ID == postID).Single().Assignments;
            }



            

            return View(viewModel);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
                                        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
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
