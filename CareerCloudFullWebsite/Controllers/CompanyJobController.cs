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
    public class CompanyJobController : Controller
    {
        private CompanyJobLogic companyJobLogic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
        private CompanyJobSkillLogic companyJobSkillLogic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>());
        private CompanyJobEducationLogic companyJobEducationLogic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>());
        private CompanyDescriptionLogic companyDescriptionLogic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
        private CompanyJobDescriptionLogic companyJobDescriptionLogic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>());
        
        CompanyJobPoco[] compJobPoco = new CompanyJobPoco[1];
        CompanyJobPoco cPoco = new CompanyJobPoco();        

        //private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJob
        public ActionResult Index()
        {
            var companyJobs = companyJobLogic.GetAll(); //db.CompanyJobs.Include(c => c.CompanyProfile);
            return View(companyJobs.ToList());
        }

        // GET: CompanyJob/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = companyJobLogic.Get(id.Value); //db.CompanyJobs.Find(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobPoco);
        }

        // GET: CompanyJob/Create
        public ActionResult Create(Guid Company)
        {
            //cPoco.Company = Company;
            //ViewBag.Company = new SelectList(companyDescriptionLogic.GetAll(), "Company", "CompanyName");
            //ViewBag.JobId = cPoco.Id;
            //ViewBag.Skills = companyJobSkillLogic.GetAll();
            //ViewBag.Education = companyJobEducationLogic.GetAll();
            return View();
        }

        // POST: CompanyJob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company,ProfileCreated,IsInactive,IsCompanyHidden,TimeStamp")] CompanyJobPoco companyJobPoco, string JobName, string JobDescriptions, string Major, int  Importance, string Skill, string SkillLevel, short EImportance)
        {
            if (ModelState.IsValid)
            {

                companyJobPoco.Id = Guid.NewGuid();
                companyJobPoco.ProfileCreated = DateTime.Now;
                compJobPoco[0] = companyJobPoco;

                CompanyJobSkillPoco companySkillsPoco = new CompanyJobSkillPoco();
                companySkillsPoco.Id = Guid.NewGuid();
                companySkillsPoco.Job = companyJobPoco.Id;
                companySkillsPoco.Skill = Skill;
                companySkillsPoco.SkillLevel = SkillLevel;
                companySkillsPoco.Importance = Importance;
                CompanyJobSkillPoco[] compJobSkillPoco = new CompanyJobSkillPoco[]
                {
                     companySkillsPoco
                };

                CompanyJobEducationPoco companyJobEducationPoco = new CompanyJobEducationPoco();
                companyJobEducationPoco.Id = Guid.NewGuid();
                companyJobEducationPoco.Job = companyJobPoco.Id;
                companyJobEducationPoco.Major = Major;
                companyJobEducationPoco.Importance = EImportance;
                CompanyJobEducationPoco[] compEducationPoco = new CompanyJobEducationPoco[]
                {
                    companyJobEducationPoco
                };

                CompanyJobDescriptionPoco companyJobDescriptionPoco = new CompanyJobDescriptionPoco();
                companyJobDescriptionPoco.Id = Guid.NewGuid();
                companyJobDescriptionPoco.Job = companyJobPoco.Id;
                companyJobDescriptionPoco.JobName = JobName;
                companyJobDescriptionPoco.JobDescriptions = JobDescriptions;
                CompanyJobDescriptionPoco[] compJobDescriptionPoco = new CompanyJobDescriptionPoco[]
                {
                    companyJobDescriptionPoco
                };


                companyJobLogic.Add(compJobPoco);
                companyJobSkillLogic.Add(compJobSkillPoco);
                companyJobEducationLogic.Add(compEducationPoco);
                companyJobDescriptionLogic.Add(compJobDescriptionPoco);

                return RedirectToAction("Details", "CompanyProfile", new { id = companyJobPoco.Company });
            }

            ViewBag.Company = new SelectList(companyJobLogic.GetAll(), "Company", "Company");
           
            return View(companyJobPoco);
        }

        // GET: CompanyJob/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = companyJobLogic.Get(id.Value); //db.CompanyJobs.Find(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(companyJobLogic.GetAll(), "Company", "Company");
            return View(companyJobPoco);
        }

        // POST: CompanyJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,ProfileCreated,IsInactive,IsCompanyHidden,TimeStamp")] CompanyJobPoco companyJobPoco)
        {
            if (ModelState.IsValid)
            {
                compJobPoco[0] = companyJobPoco;
                companyJobLogic.Update(compJobPoco);
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(companyJobLogic.GetAll(), "Company", "Company");
            return View(companyJobPoco);
        }

        // GET: CompanyJob/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = companyJobLogic.Get(id.Value); //db.CompanyJobs.Find(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobPoco);
        }

        // POST: CompanyJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobPoco companyJobPoco = companyJobLogic.Get(id); //db.CompanyJobs.Find(id);
            compJobPoco[0] = companyJobPoco;
            companyJobLogic.Delete(compJobPoco);
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
