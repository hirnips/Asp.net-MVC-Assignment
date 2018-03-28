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
    public class SecurityLoginController : Controller
    {
        private SecurityLoginLogic securityLoginLogic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
        private SecurityLoginPoco[] secLoginPoco = new SecurityLoginPoco[1];

        //private CareerCloudContext db = new CareerCloudContext();

        // GET: SecurityLogin
        public ActionResult Index()
        {
            return View(securityLoginLogic.GetAll());//db.SecurityLogins.ToList());
        }

        // GET: SecurityLogin/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginPoco securityLoginPoco = securityLoginLogic.Get(id); //db.SecurityLogins.Find(id);
            if (securityLoginPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginPoco);
        }

        // GET: SecurityLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecurityLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Password,Created,PasswordUpdate,AgreementAccepted,IsLocked,IsInactive,EmailAddress,PhoneNumber,FullName,ForceChangePassword,PrefferredLanguage,TimeStamp")] SecurityLoginPoco securityLoginPoco)
        {
            if (ModelState.IsValid)
            {
                securityLoginPoco.Id = Guid.NewGuid();
                secLoginPoco[0] = securityLoginPoco;
                securityLoginLogic.Add(secLoginPoco);
                //db.SecurityLogins.Add(securityLoginPoco);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(securityLoginPoco);
        }

        // GET: SecurityLogin/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginPoco securityLoginPoco = securityLoginLogic.Get(id); //db.SecurityLogins.Find(id);
            if (securityLoginPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginPoco);
        }

        // POST: SecurityLogin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Password,Created,PasswordUpdate,AgreementAccepted,IsLocked,IsInactive,EmailAddress,PhoneNumber,FullName,ForceChangePassword,PrefferredLanguage,TimeStamp")] SecurityLoginPoco securityLoginPoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(securityLoginPoco).State = EntityState.Modified;
                //db.SaveChanges();
                secLoginPoco[0] = securityLoginPoco;
                securityLoginLogic.Update(secLoginPoco);
                return RedirectToAction("Index");
            }
            return View(securityLoginPoco);
        }

        // GET: SecurityLogin/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginPoco securityLoginPoco = securityLoginLogic.Get(id); //db.SecurityLogins.Find(id);
            if (securityLoginPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginPoco);
        }

        // POST: SecurityLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecurityLoginPoco securityLoginPoco = securityLoginLogic.Get(id); //db.SecurityLogins.Find(id);
            secLoginPoco[0] = securityLoginPoco;
            securityLoginLogic.Delete(secLoginPoco);
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
