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
    public class ApplicantWorkHistoryController : Controller
    {
        private ApplicantWorkHistoryLogic applicantWorkHistoryLogic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>());
        ApplicantWorkHistoryPoco[] appWorkHistoryPoco = new ApplicantWorkHistoryPoco[1];
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantWorkHistory
        public ActionResult Index()
        {
            var applicantWorkHistorys = applicantWorkHistoryLogic.GetAll(); //db.ApplicantWorkHistorys.Include(a => a.ApplicantProfile).Include(a => a.SystemCountryCode);
            return View(applicantWorkHistorys.ToList());
        }

        // GET: ApplicantWorkHistory/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = applicantWorkHistoryLogic.Get(id.Value); //db.ApplicantWorkHistorys.Find(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(applicantWorkHistoryLogic.GetAll(), "Applicant", "Applicant");
            ViewBag.CountryCode = new SelectList(applicantWorkHistoryLogic.GetAll(), "CountryCode", "CountryCode");
            return View();
        }

        // POST: ApplicantWorkHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,CompanyName,CountryCode,Location,JobTitle,JobDescription,StartMonth,StartYear,EndMonth,EndYear,TimeStamp")] ApplicantWorkHistoryPoco applicantWorkHistoryPoco)
        {
            if (ModelState.IsValid)
            {
                applicantWorkHistoryPoco.Id = Guid.NewGuid();
                appWorkHistoryPoco[0] = applicantWorkHistoryPoco;
                applicantWorkHistoryLogic.Add(appWorkHistoryPoco);
               
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(applicantWorkHistoryLogic.GetAll(), "Applicant", "Applicant");
            ViewBag.CountryCode = new SelectList(applicantWorkHistoryLogic.GetAll(), "CountryCode", "CountryCode");
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = applicantWorkHistoryLogic.Get(id.Value);//db.ApplicantWorkHistorys.Find(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(applicantWorkHistoryLogic.GetAll(), "Applicant", "Applicant");
            ViewBag.CountryCode = new SelectList(applicantWorkHistoryLogic.GetAll(), "CountryCode", "CountryCode");
            return View(applicantWorkHistoryPoco);
        }

        // POST: ApplicantWorkHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,CompanyName,CountryCode,Location,JobTitle,JobDescription,StartMonth,StartYear,EndMonth,EndYear,TimeStamp")] ApplicantWorkHistoryPoco applicantWorkHistoryPoco)
        {
            if (ModelState.IsValid)
            {
                appWorkHistoryPoco[0] = applicantWorkHistoryPoco;
                applicantWorkHistoryLogic.Update(appWorkHistoryPoco);
                
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(applicantWorkHistoryLogic.GetAll(), "Applicant", "Applicant");
            ViewBag.CountryCode = new SelectList(applicantWorkHistoryLogic.GetAll(), "CountryCode", "CountryCode");
            return View(applicantWorkHistoryPoco);
        }

        // GET: ApplicantWorkHistory/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = applicantWorkHistoryLogic.Get(id.Value); //db.ApplicantWorkHistorys.Find(id);
            if (applicantWorkHistoryPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantWorkHistoryPoco);
        }

        // POST: ApplicantWorkHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = applicantWorkHistoryLogic.Get(id);
            appWorkHistoryPoco[0] = applicantWorkHistoryPoco;
            applicantWorkHistoryLogic.Delete(appWorkHistoryPoco);
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
