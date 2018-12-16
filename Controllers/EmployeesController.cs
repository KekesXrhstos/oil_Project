using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeProject.Models;
using EmployeeProject.Models.DAL;

namespace EmployeeProject.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeProjectDbContext db = new EmployeeProjectDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Account).Include(e => e.ContactDetails).Include(e => e.Department).Include(e => e.PersonalDetails).Include(e => e.WorkContract);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // get leave/create
        public ActionResult RequestLeave()
        {
            return View();
        }

        //Post leave/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestLeave([Bind(Include = "StartDateOfLeave,EndDateOfLeave,Type")] Leave leave, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {                
                employee.MakeARequestForLeave(db, employee, leave); //edw mesa apothikeuw kai thn adeia alla kai thn aithsh
                ViewBag.LeaveID = leave.ID;
                return RedirectToAction("Index");
            }




            return View(leave);
        }


        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Accounts, "EmployeeID", "Email");
            ViewBag.ID = new SelectList(db.ContactDetails, "EmployeeID", "MobilePhone");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            ViewBag.ID = new SelectList(db.PersonalDetails, "EmployeeID", "SSN");
            ViewBag.ID = new SelectList(db.WorkContracts, "EmployeeID", "EmployeeID");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LastName,MyStatus,Insurance,WorkRole,RemaingDaysOfLeave,Salary,DepartmentID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Accounts, "EmployeeID", "Email", employee.ID);
            ViewBag.ID = new SelectList(db.ContactDetails, "EmployeeID", "MobilePhone", employee.ID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Address", employee.DepartmentID);
            ViewBag.ID = new SelectList(db.PersonalDetails, "EmployeeID", "SSN", employee.ID);
            ViewBag.ID = new SelectList(db.WorkContracts, "EmployeeID", "EmployeeID", employee.ID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Accounts, "EmployeeID", "Email", employee.ID);
            ViewBag.ID = new SelectList(db.ContactDetails, "EmployeeID", "MobilePhone", employee.ID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", employee.DepartmentID);
            ViewBag.ID = new SelectList(db.PersonalDetails, "EmployeeID", "SSN", employee.ID);
            ViewBag.ID = new SelectList(db.WorkContracts, "EmployeeID", "EmployeeID", employee.ID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LastName,MyStatus,Insurance,WorkRole,RemaingDaysOfLeave,Salary,DepartmentID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Accounts, "EmployeeID", "Email", employee.ID);
            ViewBag.ID = new SelectList(db.ContactDetails, "EmployeeID", "MobilePhone", employee.ID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Address", employee.DepartmentID);
            ViewBag.ID = new SelectList(db.PersonalDetails, "EmployeeID", "SSN", employee.ID);
            ViewBag.ID = new SelectList(db.WorkContracts, "EmployeeID", "EmployeeID", employee.ID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
