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
    public class CompanyProfileController : Controller
    {
        private CompanyLogic companyLogic = new CompanyLogic();
        private CompanyProfileLogic companyProfileLogic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>());
        private EFGenericRepository<SystemLanguageCodePoco> systemLanguageCodeLogic = new EFGenericRepository<SystemLanguageCodePoco>();
        private CompanyDescriptionLogic companyDescriptionLogic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
        CompanyProfilePoco[] compProfilePoco = new CompanyProfilePoco[1];

        //private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyProfile
        public ActionResult Index()
        {
            return View(companyProfileLogic.GetAll().ToList());
        }

        // GET: CompanyProfile/Details/5
        public ActionResult Details(Guid id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyProfilePoco companyProfilePoco = companyLogic.GetJobDescription(id); //companyProfileLogic.Get(Guid.Parse(id));// db.CompanyProfiles.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(systemLanguageCodeLogic.GetAll(), "LanguageID", "Name");
            return View();
        }

        // POST: CompanyProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco, string LanguageId, string CompanyName, string CompanyDescription)
        {
            if (ModelState.IsValid)
            {
                companyProfilePoco.Id = Guid.NewGuid();
                compProfilePoco[0] = companyProfilePoco;
                companyProfileLogic.Add(compProfilePoco);

                
                CompanyDescriptionPoco companyDescriptionPoco = new CompanyDescriptionPoco();
                companyDescriptionPoco.Id = Guid.NewGuid();
                companyDescriptionPoco.Company = companyProfilePoco.Id;
                companyDescriptionPoco.LanguageId = LanguageId;
                companyDescriptionPoco.CompanyName = CompanyName;
                companyDescriptionPoco.CompanyDescription = CompanyDescription;
                CompanyDescriptionPoco[] companyDescriptionPocos = new CompanyDescriptionPoco[]{
                    companyDescriptionPoco
                };
                companyDescriptionLogic.Add(companyDescriptionPocos);


                ViewBag.LanguageId = new SelectList(systemLanguageCodeLogic.GetAll(), "LanguageId", "Name", companyDescriptionPoco.LanguageId);
                return RedirectToAction("Details", new { id = companyProfilePoco.Id });
            }

            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = companyLogic.GetJobDescription(id);// db.CompanyProfiles.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                compProfilePoco[0] = companyProfilePoco;
                companyProfileLogic.Update(compProfilePoco);
                return RedirectToAction("Index");
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = companyLogic.GetJobDescription(id); //db.CompanyProfiles.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //CompanyProfilePoco companyProfilePoco = companyLogic.GetJobDescription(id);
            //CompanyDescriptionPoco companyDescriptionPoco = new CompanyDescriptionPoco();

            //compProfilePoco[0] = companyProfilePoco;
            //companyProfileLogic.Delete(compProfilePoco);
            CompanyLogic companyLogic = new CompanyLogic();
            companyLogic.DeleteJobDescription(id);
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
