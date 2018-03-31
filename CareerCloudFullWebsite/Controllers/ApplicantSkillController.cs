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
    public class ApplicantSkillController : Controller
    {
        private ApplicantSkillLogic applicantSkillLogic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>());
        ApplicantSkillPoco[] appSkillPoco = new ApplicantSkillPoco[1];
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantSkill
        public ActionResult Index()
        {
            var applicantSkills = applicantSkillLogic.GetAll(); //db.ApplicantSkills.Include(a => a.ApplicantProfile);
            return View(applicantSkills.ToList());
        }

        // GET: ApplicantSkill/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantSkillPoco applicantSkillPoco = applicantSkillLogic.Get(id.Value); //db.ApplicantSkills.Find(id);
            if (applicantSkillPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantSkillPoco);
        }

        // GET: ApplicantSkill/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(applicantSkillLogic.GetAll(), "Applicant", "Applicant");
            return View();
        }

        // POST: ApplicantSkill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Skill,SkillLevel,StartMonth,StartYear,EndMonth,EndYear,TimeStamp")] ApplicantSkillPoco applicantSkillPoco)
        {
            if (ModelState.IsValid)
            {
                applicantSkillPoco.Id = Guid.NewGuid();
                appSkillPoco[0] = applicantSkillPoco;
                applicantSkillLogic.Add(appSkillPoco);
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(applicantSkillLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantSkillPoco);
        }

        // GET: ApplicantSkill/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantSkillPoco applicantSkillPoco = applicantSkillLogic.Get(id.Value);//db.ApplicantSkills.Find(id);
            if (applicantSkillPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(applicantSkillLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantSkillPoco);
        }

        // POST: ApplicantSkill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Skill,SkillLevel,StartMonth,StartYear,EndMonth,EndYear,TimeStamp")] ApplicantSkillPoco applicantSkillPoco)
        {
            if (ModelState.IsValid)
            {
                appSkillPoco[0] = applicantSkillPoco;
                applicantSkillLogic.Update(appSkillPoco);
               
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(applicantSkillLogic.GetAll(), "Applicant", "Applicant");
            return View(applicantSkillPoco);
        }

        // GET: ApplicantSkill/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantSkillPoco applicantSkillPoco = applicantSkillLogic.Get(id.Value); //db.ApplicantSkills.Find(id);
            if (applicantSkillPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantSkillPoco);
        }

        // POST: ApplicantSkill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantSkillPoco applicantSkillPoco = applicantSkillLogic.Get(id);//db.ApplicantSkills.Find(id);
            appSkillPoco[0] = applicantSkillPoco;
            applicantSkillLogic.Delete(appSkillPoco);
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
