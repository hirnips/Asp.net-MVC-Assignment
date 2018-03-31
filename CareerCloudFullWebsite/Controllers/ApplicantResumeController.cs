using System;
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
    public class ApplicantResumeController : Controller
    {
        ApplicantResumeLogic applicantResumeLogic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>());
        ApplicantResumePoco[] appResumePoco = new ApplicantResumePoco[1];
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantResume
        public ActionResult Index()
        {
            var applicantResumes = applicantResumeLogic.GetAll(); //db.ApplicantResumes.Include(a => a.ApplicantProfile);
            return View(applicantResumes.ToList());
        }

        // GET: ApplicantResume/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantResumePoco applicantResumePoco = applicantResumeLogic.Get(id.Value); //db.ApplicantResumes.Find(id);
            if (applicantResumePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantResumePoco);
        }

        // GET: ApplicantResume/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(applicantResumeLogic.GetAll(), "Applicant", "Applicant");
            return View();
        }

        // POST: ApplicantResume/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Resume,LastUpdated")] ApplicantResumePoco applicantResumePoco)
        {
            if (ModelState.IsValid)
            {
                applicantResumePoco.Id = Guid.NewGuid();
                appResumePoco[0] = applicantResumePoco;

                applicantResumeLogic.Add(appResumePoco);

                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(applicantResumeLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantResumePoco);
        }

        // GET: ApplicantResume/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantResumePoco applicantResumePoco = applicantResumeLogic.Get(id.Value); //db.ApplicantResumes.Find(id);
            if (applicantResumePoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(applicantResumeLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantResumePoco);
        }

        // POST: ApplicantResume/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Resume,LastUpdated")] ApplicantResumePoco applicantResumePoco)
        {
            if (ModelState.IsValid)
            {
                appResumePoco[0] = applicantResumePoco;
                applicantResumeLogic.Update(appResumePoco);
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(applicantResumeLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantResumePoco);
        }

        // GET: ApplicantResume/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicantResumePoco applicantResumePoco = applicantResumeLogic.Get(id.Value);

            if (applicantResumePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantResumePoco);
        }

        // POST: ApplicantResume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantResumePoco applicantResumePoco = applicantResumeLogic.Get(id);
            appResumePoco[0] = applicantResumePoco;
            applicantResumeLogic.Delete(appResumePoco);
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
            base.Dispose(disposing);
        }
    }
}
