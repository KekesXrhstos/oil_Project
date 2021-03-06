﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeProject.Models;
using EmployeeProject.Models.DAL;
using EmployeeProject.ViewModel;

namespace EmployeeProject.Controllers
{
    public class EvaluationsController : Controller
    {
        private EmployeeProjectDbContext db = new EmployeeProjectDbContext();

        // GET: Evaluations
        public ActionResult Index(int? id, int? performanceID)
        {
            //var viewModel = new EvaluationsData();

            //// eager Loading
            //viewModel.Evaluations = db.Evaluations
            //    .Include(i => i.Performances)
            //    //.Include(i => i.Performances)
            //    .OrderByDescending(i => i.EvaluationID);

            //if (id != null)
            //{

            //    ViewBag.EvaluationID = id.Value;
            //    viewModel.Performances = viewModel.Evaluations
            //        .Where(i => i.EvaluationID == id.Value).Single().Performances;
            //}

            //if (performanceID != null)
            //{
            //    ViewBag.PerformanceID = performanceID.Value;
            //    // Lazy Loading
            //    viewModel.Questions = viewModel.Performances
            //        .Where(c => c.ID == performanceID).Single().Questions;
                
            //}

            return View();
        }
        
            

        // GET: Evaluations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluations.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // GET: Evaluations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StartEvaluationDate,EndEvaluationDate")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                db.Evaluations.Add(evaluation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evaluation);
        }

        // GET: Evaluations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluations.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // POST: Evaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluationID,StartEvaluationDate,EndEvaluationDate")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluations.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluation evaluation = db.Evaluations.Find(id);
            db.Evaluations.Remove(evaluation);
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
