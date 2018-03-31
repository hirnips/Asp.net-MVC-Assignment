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
    public class CompanyJobDescriptionController : Controller
    {
        private CompanyJobDescriptionLogic companyJobDescriptionLogic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>());
        CompanyJobDescriptionPoco[] compJobDescriptionPoco = new CompanyJobDescriptionPoco[1];

        //private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobDescription
        public ActionResult Index()
        {
            var companyJobDescriptions = companyJobDescriptionLogic.GetAll();  //db.CompanyJobDescriptions.Include(c => c.CompanyJob);
            return View(companyJobDescriptions.ToList());
        }

        // GET: CompanyJobDescription/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = companyJobDescriptionLogic.Get(id.Value); //db.CompanyJobDescriptions.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Create
        public ActionResult Create()
        {
            ViewBag.Job = new SelectList(companyJobDescriptionLogic.GetAll(), "Job", "Job");
            return View();
        }

        // POST: CompanyJobDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,JobName,JobDescriptions,TimeStamp")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobDescriptionPoco.Id = Guid.NewGuid();
                compJobDescriptionPoco[0] = companyJobDescriptionPoco;
                companyJobDescriptionLogic.Add(compJobDescriptionPoco);
                
                return RedirectToAction("Index");
            }

            ViewBag.Job = new SelectList(companyJobDescriptionLogic.GetAll(), "Job", "Job");
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = companyJobDescriptionLogic.Get(id.Value); //db.CompanyJobDescriptions.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(companyJobDescriptionLogic.GetAll(), "Job", "Job");
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,JobName,JobDescriptions,TimeStamp")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                compJobDescriptionPoco[0] = companyJobDescriptionPoco;
                companyJobDescriptionLogic.Update(compJobDescriptionPoco);
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(companyJobDescriptionLogic.GetAll(), "Job", "Job");
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = companyJobDescriptionLogic.Get(id.Value);// db.CompanyJobDescriptions.Find(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobDescriptionPoco companyJobDescriptionPoco = companyJobDescriptionLogic.Get(id); //db.CompanyJobDescriptions.Find(id);
            compJobDescriptionPoco[0] = companyJobDescriptionPoco;
            companyJobDescriptionLogic.Delete(compJobDescriptionPoco);
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
