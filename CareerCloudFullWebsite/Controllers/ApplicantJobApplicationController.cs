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
    public class ApplicantJobApplicationController : Controller
    {
        private ApplicantJobApplicationLogic applicantJobApplicationLogic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>());
        ApplicantJobApplicationPoco[] appJobAppPoco = new ApplicantJobApplicationPoco[1];
        ApplicantLogic applicantLogic = new ApplicantLogic();

        //private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantJobApplication
        public ActionResult Index()
        {
            var applicantJobApplications = applicantJobApplicationLogic.GetAll(); //db.ApplicantJobApplications.Include(a => a.ApplicantProfile).Include(a => a.CompanyJob);
            return View(applicantJobApplications.ToList());
        }

        // GET: ApplicantJobApplication/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = applicantJobApplicationLogic.Get(id); //db.ApplicantJobApplications.Find(id);
            //ApplicantJobApplicationPoco applicantJobApplicationPoco = applicantLogic.GetApplicantJobApplication(id);
            //ViewBag.ApplicantName = applicantLogic.GetApplicantName(id).FullName;
            //ViewBag.Job = applicantLogic.GetApplicantJob(id).FirstOrDefault().JobName;

            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(applicantJobApplicationLogic.GetAll(), "Applicant", "Applicant");
            ViewBag.Job = new SelectList(applicantJobApplicationLogic.GetAll(), "Job", "Job");
            return View();
        }

        // POST: ApplicantJobApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Job,ApplicationDate,TimeStamp")] ApplicantJobApplicationPoco applicantJobApplicationPoco)
        {
            if (ModelState.IsValid)
            {
                applicantJobApplicationPoco.Id = Guid.NewGuid();
                appJobAppPoco[0] = applicantJobApplicationPoco;
                applicantJobApplicationLogic.Add(appJobAppPoco);
               
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(applicantJobApplicationLogic.GetAll(), "Applicant", "Applicant");
            ViewBag.Job = new SelectList(applicantJobApplicationLogic.GetAll(), "Job", "Job");
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = applicantJobApplicationLogic.Get(id.Value); //db.ApplicantJobApplications.Find(id);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(applicantJobApplicationLogic.GetAll(), "Applicant", "Applicant");
            ViewBag.Job = new SelectList(applicantJobApplicationLogic.GetAll(), "Job", "Job");
            return View(applicantJobApplicationPoco);
        }

        // POST: ApplicantJobApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Job,ApplicationDate,TimeStamp")] ApplicantJobApplicationPoco applicantJobApplicationPoco)
        {
            if (ModelState.IsValid)
            {
                appJobAppPoco[0] = applicantJobApplicationPoco;
                applicantJobApplicationLogic.Update(appJobAppPoco);
               
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(applicantJobApplicationLogic.GetAll(), "Applicant", "Applicant");
            ViewBag.Job = new SelectList(applicantJobApplicationLogic.GetAll(), "Job", "Job");
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = applicantJobApplicationLogic.Get(id.Value); //db.ApplicantJobApplications.Find(id);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // POST: ApplicantJobApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantJobApplicationPoco applicantJobApplicationPoco = applicantJobApplicationLogic.Get(id); //db.ApplicantJobApplications.Find(id);
            appJobAppPoco[0] = applicantJobApplicationPoco;
            applicantJobApplicationLogic.Delete(appJobAppPoco);
           
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
