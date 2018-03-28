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
    public class SystemLanguageCodeController : Controller
    {
        private EFGenericRepository<SystemLanguageCodePoco> systemLanguageLogic = new EFGenericRepository<SystemLanguageCodePoco>(); 
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: SystemLanguageCode
        public ActionResult Index()
        {
            return View(systemLanguageLogic.GetAll());//db.SystemLanguageCodes.ToList());
        }

        // GET: SystemLanguageCode/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = systemLanguageLogic.GetSingle(l => l.LanguageID == id); //db.SystemLanguageCodes.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemLanguageCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageID,Name,NativeName")] SystemLanguageCodePoco systemLanguageCodePoco)
        {
            if (ModelState.IsValid)
            {
                SystemLanguageCodePoco[] systemLangPoco = new SystemLanguageCodePoco[] { systemLanguageCodePoco };
                systemLanguageLogic.Add(systemLangPoco);
                
                return RedirectToAction("Index");
            }

            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCode/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = systemLanguageLogic.GetSingle(l => l.LanguageID == id); //db.SystemLanguageCodes.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // POST: SystemLanguageCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageID,Name,NativeName")] SystemLanguageCodePoco systemLanguageCodePoco)
        {
            if (ModelState.IsValid)
            {
                SystemLanguageCodePoco[] systemLangPoco = new SystemLanguageCodePoco[] { systemLanguageCodePoco };
                systemLanguageLogic.Update(systemLangPoco);
                return RedirectToAction("Index");
            }
            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCode/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = systemLanguageLogic.GetSingle(l => l.LanguageID == id); //db.SystemLanguageCodes.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // POST: SystemLanguageCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SystemLanguageCodePoco systemLanguageCodePoco = systemLanguageLogic.GetSingle(l => l.LanguageID == id); //db.SystemLanguageCodes.Find(id);
            SystemLanguageCodePoco[] systemLangPoco = new SystemLanguageCodePoco[] { systemLanguageCodePoco };
            systemLanguageLogic.Remove(systemLangPoco);
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
