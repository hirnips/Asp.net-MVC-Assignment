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
    public class CompanyLocationController : Controller
    {
        private CompanyLocationLogic companyLocationLogic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>());
        CompanyLocationPoco[] compLocationPoco = new CompanyLocationPoco[1];

        //private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyLocation
        public ActionResult Index()
        {
            var companyLocations = companyLocationLogic.GetAll();// db.CompanyLocations.Include(c => c.CompanyProfile);
            return View(companyLocations.ToList());
        }

        // GET: CompanyLocation/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyLocationPoco companyLocationPoco = companyLocationLogic.Get(id.Value);// db.CompanyLocations.Find(id);
            if (companyLocationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyLocationPoco);
        }

        // GET: CompanyLocation/Create
        public ActionResult Create()
        {
            ViewBag.Company = new SelectList(companyLocationLogic.GetAll(), "Company", "Company");
            return View();
        }

        // POST: CompanyLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company,CountryCode,Province,Street,City,PostalCode,TimeStamp")] CompanyLocationPoco companyLocationPoco)
        {
            if (ModelState.IsValid)
            {
                companyLocationPoco.Id = Guid.NewGuid();
                compLocationPoco[0] = companyLocationPoco;
                companyLocationLogic.Add(compLocationPoco);

                return RedirectToAction("Index");
            }

            ViewBag.Company = new SelectList(companyLocationLogic.GetAll(), "Company", "Company");
            return View(companyLocationPoco);
        }

        // GET: CompanyLocation/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyLocationPoco companyLocationPoco = companyLocationLogic.Get(id.Value);// db.CompanyLocations.Find(id);
            if (companyLocationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(companyLocationLogic.GetAll(), "Company", "Company");
            return View(companyLocationPoco);
        }

        // POST: CompanyLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,CountryCode,Province,Street,City,PostalCode,TimeStamp")] CompanyLocationPoco companyLocationPoco)
        {
            if (ModelState.IsValid)
            {
                compLocationPoco[0] = companyLocationPoco;
                companyLocationLogic.Update(compLocationPoco);
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(companyLocationLogic.GetAll(), "Company", "Company");
            return View(companyLocationPoco);
        }

        // GET: CompanyLocation/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyLocationPoco companyLocationPoco = companyLocationLogic.Get(id.Value);// db.CompanyLocations.Find(id);
            if (companyLocationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyLocationPoco);
        }

        // POST: CompanyLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyLocationPoco companyLocationPoco = companyLocationLogic.Get(id); //db.CompanyLocations.Find(id);
            compLocationPoco[0] = companyLocationPoco;
            companyLocationLogic.Delete(compLocationPoco);
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
