using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using EmployeeProject.Models.DAL;
using EmployeeProject.Models.EvaluationFolder;
using EmployeeProject.ViewModel;

namespace EmployeeProject.Controllers
{
    public class PerformancesController : Controller
    {
        private EmployeeProjectDbContext db = new EmployeeProjectDbContext();

        // GET: Performances
        public ActionResult Index()
        {
            var performances = db.Performances.Include(p => p.Employee).Include(p => p.Evaluation);
            return View(performances.ToList());
        }

        // GET: Performances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            return View(performance);
        }

        // GET: Performances/Create
        public ActionResult Create(int? formId)
        {
            

            var viewModel = new PerformanceData()
            {
                Employees = db.Employees.ToList(),
                Evaluations = db.Evaluations.ToList(),
                Forms = db.Forms.ToList(),
                DateTime = DateTime.Now,
                

            };

            if (formId != null)
            {
                viewModel.FormId = (int)formId;
                viewModel.Questions = viewModel.GetFormQuestions((int)formId);
            }




            return View(viewModel);
        }

        // POST: Performances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PerformanceData performanceData)
        {

            

            var performance = new Performance()
            {
                FormID = performanceData.FormId,
                EmployeeID = performanceData.Employee.ID,
                EvaluationID = performanceData.Evaluation.ID,
                DateEvaluated = DateTime.Now,
                OveralRating = OverallRatingCalculate(performanceData.Answers)
                
            };

            if (db.Performances.Any(p => p.EmployeeID == performance.EmployeeID && p.EvaluationID == performance.EvaluationID))
            {
                performanceData.ExistingPerformance = true;
                performanceData.Forms = db.Forms;
                performanceData.Employees = db.Employees;
                performanceData.Evaluations = db.Evaluations.ToList();
                performanceData.Questions = performanceData.GetFormQuestions(performanceData.FormId);
                return View("Create", performanceData);
            }

            db.Performances.Add(performance);
            db.SaveChanges();



            for (int i = 0; i < performanceData.Questions.Count; i++)
            {
                performanceData.Answers[i].QuestionID = performanceData.Questions[i].ID;
            }

            foreach ( var answer in performanceData.Answers)
            {
                answer.PerformanceID = performance.ID;
                db.Answers.Add(answer);
            }
            db.SaveChanges();



            return RedirectToAction("Index", "Home");
        }

        public int OverallRatingCalculate(List<Answer> answers)
        {
            int allValuesOfAnswers = 0;
            foreach ( var answer in answers)
            {
                allValuesOfAnswers += (int)answer.QuestionAnswer;
            }

            var finalRating = allValuesOfAnswers / answers.Count();
            return finalRating;
        }

        // GET: Performances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", performance.EmployeeID);
            ViewBag.EvaluationID = new SelectList(db.Evaluations, "EvaluationID", "EvaluationID", performance.EvaluationID);
            return View(performance);
        }

        // POST: Performances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,EvaluationID,OveralRating,DateEvaluated")] Performance performance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(performance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", performance.EmployeeID);
            ViewBag.EvaluationID = new SelectList(db.Evaluations, "EvaluationID", "EvaluationID", performance.EvaluationID);
            return View(performance);
        }

        // GET: Performances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return HttpNotFound();
            }
            return View(performance);
        }

        // POST: Performances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Performance performance = db.Performances.Find(id);
            db.Performances.Remove(performance);
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
