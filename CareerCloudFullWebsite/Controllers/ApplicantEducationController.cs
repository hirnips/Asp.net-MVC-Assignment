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
using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;



namespace CareerCloudFullWebsite.Controllers
{
    public class ApplicantEducationController : Controller
    {
        private ApplicantEducationLogic applicantEducationLogic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>());
        private ApplicantEducationPoco[] appEduPoco = new ApplicantEducationPoco[1];
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantEducation
        public ActionResult Index()
        {
            //var applicantEducations = db.ApplicantEducations.Include(a => a.ApplicantProfile);
            //return View(applicantEducations.ToList());
            var applicantEducations = applicantEducationLogic.GetAll();
            return View(applicantEducations);
        }

        // GET: ApplicantEducation/Details/5
        public ActionResult Details(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicantEducationPoco applicantEducationPoco = db.ApplicantEducations.Find(id);
            //if (applicantEducationPoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(applicantEducationPoco);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantEducationPoco applicantEducationPoco = applicantEducationLogic.Get(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);

        }

        // GET: ApplicantEducation/Create
        public ActionResult Create()
        {
            //ViewBag.Applicant = new SelectList(db.ApplicantProfilePocos, "Id", "Currency");
            //return View();            
            ViewBag.Applicant = new SelectList(applicantEducationLogic.GetAll(), "Applicant", "Applicant");
            return View();           
        }

        // POST: ApplicantEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Major,CertificateDiploma,StartDate,CompletionDate,CompletionPercent,TimeStamp")] ApplicantEducationPoco applicantEducationPoco)
        {
            //if (ModelState.IsValid)
            //{
            //    applicantEducationPoco.Id = Guid.NewGuid();
            //    db.ApplicantEducations.Add(applicantEducationPoco);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.Applicant = new SelectList(db.ApplicantProfilePocos, "Id", "Currency", applicantEducationPoco.Applicant);
            //return View(applicantEducationPoco);
            if (ModelState.IsValid)
            {   
                applicantEducationPoco.Id = Guid.NewGuid();
                appEduPoco[0] = applicantEducationPoco;
                applicantEducationLogic.Add(appEduPoco); 
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(applicantEducationLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Edit/5
        public ActionResult Edit(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicantEducationPoco applicantEducationPoco = db.ApplicantEducations.Find(id);
            //if (applicantEducationPoco == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.Applicant = new SelectList(db.ApplicantProfilePocos, "Id", "Currency", applicantEducationPoco.Applicant);
            //return View(applicantEducationPoco);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantEducationPoco applicantEducationPoco = applicantEducationLogic.Get(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Applicant = new SelectList(db.ApplicantProfilePocos, "Id", "Currency", applicantEducationPoco.Applicant);
            ViewBag.Applicant = new SelectList(applicantEducationLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantEducationPoco);

            //return View();
        }

        // POST: ApplicantEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Major,CertificateDiploma,StartDate,CompletionDate,CompletionPercent,TimeStamp")] ApplicantEducationPoco applicantEducationPoco)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(applicantEducationPoco).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.Applicant = new SelectList(db.ApplicantProfilePocos, "Id", "Currency", applicantEducationPoco.Applicant);
            //return View(applicantEducationPoco);

            if (ModelState.IsValid)
            {
                appEduPoco[0] = applicantEducationPoco;

                applicantEducationLogic.Update(appEduPoco);
                
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(applicantEducationLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Delete/5
        public ActionResult Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicantEducationPoco applicantEducationPoco = db.ApplicantEducations.Find(id);
            //if (applicantEducationPoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(applicantEducationPoco);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantEducationPoco applicantEducationPoco = applicantEducationLogic.Get(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // POST: ApplicantEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //ApplicantEducationPoco applicantEducationPoco = db.ApplicantEducations.Find(id);
            //db.ApplicantEducations.Remove(applicantEducationPoco);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            ApplicantEducationPoco applicantEducationPoco = applicantEducationLogic.Get(id);
            appEduPoco[0] = applicantEducationPoco;
            applicantEducationLogic.Delete(appEduPoco);
            return RedirectToAction("Index");
            
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    applicantEducationLogic.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
