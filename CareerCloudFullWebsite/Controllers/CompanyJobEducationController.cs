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
    public class CompanyJobEducationController : Controller
    {
        private CompanyJobEducationLogic companyJobEducationLogic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>());
        CompanyJobEducationPoco[] compJobEducationPoco = new CompanyJobEducationPoco[1];
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobEducation
        public ActionResult Index()
        {
            var companyJobEducations = companyJobEducationLogic.GetAll(); //db.CompanyJobEducations.Include(c => c.CompanyJob);
            return View(companyJobEducations.ToList());
        }

        // GET: CompanyJobEducation/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = companyJobEducationLogic.Get(id.Value);// db.CompanyJobEducations.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Create
        public ActionResult Create()
        {
            ViewBag.Job = new SelectList(companyJobEducationLogic.GetAll(), "Job", "Job");
            return View();
        }

        // POST: CompanyJobEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,Major,Importance,TimeStamp")] CompanyJobEducationPoco companyJobEducationPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobEducationPoco.Id = Guid.NewGuid();
                compJobEducationPoco[0] = companyJobEducationPoco;
                companyJobEducationLogic.Add(compJobEducationPoco);
                
                return RedirectToAction("Index");
            }

            ViewBag.Job = new SelectList(companyJobEducationLogic.GetAll(), "Job", "Job");
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = companyJobEducationLogic.Get(id.Value); //db.CompanyJobEducations.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(companyJobEducationLogic.GetAll(), "Job", "Job");
            return View(companyJobEducationPoco);
        }

        // POST: CompanyJobEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,Major,Importance,TimeStamp")] CompanyJobEducationPoco companyJobEducationPoco)
        {
            if (ModelState.IsValid)
            {
                compJobEducationPoco[0] = companyJobEducationPoco;
                companyJobEducationLogic.Add(compJobEducationPoco);
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(companyJobEducationLogic.GetAll(), "Job", "Job");
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = companyJobEducationLogic.Get(id.Value); //db.CompanyJobEducations.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobEducationPoco);
        }

        // POST: CompanyJobEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobEducationPoco companyJobEducationPoco = companyJobEducationLogic.Get(id); //db.CompanyJobEducations.Find(id);
            compJobEducationPoco[0] = companyJobEducationPoco;
            companyJobEducationLogic.Add(compJobEducationPoco);
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
