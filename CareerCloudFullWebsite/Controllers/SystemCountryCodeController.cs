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
    public class SystemCountryCodeController : Controller
    {
        private EFGenericRepository<SystemCountryCodePoco> systemCountryCodeLogic = new EFGenericRepository<SystemCountryCodePoco>();

        //private CareerCloudContext db = new CareerCloudContext();

        // GET: SystemCountryCode
        public ActionResult Index()
        {
            return View(systemCountryCodeLogic.GetAll());//db.SystemCountryCodes.ToList());
        }

        // GET: SystemCountryCode/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCountryCodePoco systemCountryCodePoco = systemCountryCodeLogic.GetSingle(c => c.Code == id); //db.SystemCountryCodes.Find(id);
            if (systemCountryCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemCountryCodePoco);
        }

        // GET: SystemCountryCode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemCountryCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name")] SystemCountryCodePoco systemCountryCodePoco)
        {
            if (ModelState.IsValid)
            {
                SystemCountryCodePoco[] systemCountryCodes = new SystemCountryCodePoco[] { systemCountryCodePoco };
                systemCountryCodeLogic.Add(systemCountryCodes);
                return RedirectToAction("Index");
            }

            return View(systemCountryCodePoco);
        }

        // GET: SystemCountryCode/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCountryCodePoco systemCountryCodePoco = systemCountryCodeLogic.GetSingle(c => c.Code == id);
            if (systemCountryCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemCountryCodePoco);
        }

        // POST: SystemCountryCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name")] SystemCountryCodePoco systemCountryCodePoco)
        {
            if (ModelState.IsValid)
            {
                SystemCountryCodePoco[] systemCountryCodes = new SystemCountryCodePoco[] { systemCountryCodePoco };
                systemCountryCodeLogic.Update(systemCountryCodes);
                return RedirectToAction("Index");
            }
            return View(systemCountryCodePoco);
        }

        // GET: SystemCountryCode/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCountryCodePoco systemCountryCodePoco = systemCountryCodeLogic.GetSingle(c => c.Code == id);
            if (systemCountryCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemCountryCodePoco);
        }

        // POST: SystemCountryCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SystemCountryCodePoco systemCountryCodePoco = systemCountryCodeLogic.GetSingle(c => c.Code == id);
            SystemCountryCodePoco[] systemCountryCodes = new SystemCountryCodePoco[] { systemCountryCodePoco };
            systemCountryCodeLogic.Remove(systemCountryCodes);
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
