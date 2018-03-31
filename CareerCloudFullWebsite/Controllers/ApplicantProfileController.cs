﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;

namespace CareerCloudFullWebsite.Controllers
{
    public class ApplicantProfileController : Controller
    {
        private ApplicantProfileLogic applicantProfileLogic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
        ApplicantProfilePoco[] appProfilePoco = new ApplicantProfilePoco[1];
        //private CareerCloudContext db = new CareerCloudContext();


        public ActionResult JobsApplied(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicantProfilePoco applicantProfilePoco = applicantProfileLogic.Get(id.Value, n => n.ApplicantJobApplications); //db.ApplicantProfilePocos.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }


        // GET: ApplicantProfile
        public ActionResult Index()
        {
            var applicantProfilePocos = applicantProfileLogic.GetAll(); //db.ApplicantProfilePocos.Include(a => a.SecurityLogin).Include(a => a.SystemCountryCode);
            return View(applicantProfilePocos.ToList());
        }

        // GET: ApplicantProfile/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = applicantProfileLogic.Get(id.Value); //db.ApplicantProfilePocos.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }


            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Create
        public ActionResult Create()
        {
            ViewBag.Login = new SelectList(applicantProfileLogic.GetAll(), "Login", "Login");
            ViewBag.Country = new SelectList(applicantProfileLogic.GetAll(), "Country", "Country");
            return View();
        }

        // POST: ApplicantProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode,TimeStamp")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                applicantProfilePoco.Id = Guid.NewGuid();
                appProfilePoco[0] = applicantProfilePoco;

                applicantProfileLogic.Add(appProfilePoco);
                
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(applicantProfileLogic.GetAll(), "Login", "Login");
            ViewBag.Country = new SelectList(applicantProfileLogic.GetAll(), "Country", "Country");
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = applicantProfileLogic.Get(id.Value); //db.ApplicantProfilePocos.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(applicantProfileLogic.GetAll(), "Login", "Login");
            ViewBag.Country = new SelectList(applicantProfileLogic.GetAll(), "Country", "Country");
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode,TimeStamp")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                appProfilePoco[0] = applicantProfilePoco;
                applicantProfileLogic.Update(appProfilePoco);
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(applicantProfileLogic.GetAll(), "Login", "Login");
            ViewBag.Country = new SelectList(applicantProfileLogic.GetAll(), "Country", "Country");
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = applicantProfileLogic.Get(id.Value); //db.ApplicantProfilePocos.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantProfilePoco applicantProfilePoco = applicantProfileLogic.Get(id); //db.ApplicantProfilePocos.Find(id);
            appProfilePoco[0] = applicantProfilePoco;
            applicantProfileLogic.Delete(appProfilePoco);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
