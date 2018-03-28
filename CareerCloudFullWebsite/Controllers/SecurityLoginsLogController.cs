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
    public class SecurityLoginsLogController : Controller
    {
        private SecurityLoginsLogLogic securityLoginsLogLogic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
        SecurityLoginsLogPoco[] secLoginLogPoco = new SecurityLoginsLogPoco[1];
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: SecurityLoginsLog
        public ActionResult Index()
        {
            var securityLoginsLogs = securityLoginsLogLogic.GetAll(); //db.SecurityLoginsLogs.Include(s => s.SecurityLogin);
            return View(securityLoginsLogs.ToList());
        }

        // GET: SecurityLoginsLog/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsLogPoco securityLoginsLogPoco = securityLoginsLogLogic.Get(id);// db.SecurityLoginsLogs.Find(id);
            if (securityLoginsLogPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsLogPoco);
        }

        // GET: SecurityLoginsLog/Create
        public ActionResult Create()
        {
            ViewBag.Login = new SelectList(securityLoginsLogLogic.GetAll(), "Login", "Login");
            return View();
        }

        // POST: SecurityLoginsLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,SourceIP,LogonDate,IsSuccesful")] SecurityLoginsLogPoco securityLoginsLogPoco)
        {
            if (ModelState.IsValid)
            {
                securityLoginsLogPoco.Id = Guid.NewGuid();
                secLoginLogPoco[0] = securityLoginsLogPoco;
                securityLoginsLogLogic.Add(secLoginLogPoco);
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(securityLoginsLogLogic.GetAll(), "Login", "Login");
            return View(securityLoginsLogPoco);
        }

        // GET: SecurityLoginsLog/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsLogPoco securityLoginsLogPoco = securityLoginsLogLogic.Get(id); //db.SecurityLoginsLogs.Find(id);
            if (securityLoginsLogPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(securityLoginsLogLogic.GetAll(), "Login", "Login");
            return View(securityLoginsLogPoco);
        }

        // POST: SecurityLoginsLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,SourceIP,LogonDate,IsSuccesful")] SecurityLoginsLogPoco securityLoginsLogPoco)
        {
            if (ModelState.IsValid)
            {
                secLoginLogPoco[0] = securityLoginsLogPoco;
                securityLoginsLogLogic.Update(secLoginLogPoco);
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(securityLoginsLogLogic.GetAll(), "Login", "Login");
            return View(securityLoginsLogPoco);
        }

        // GET: SecurityLoginsLog/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsLogPoco securityLoginsLogPoco = securityLoginsLogLogic.Get(id); //db.SecurityLoginsLogs.Find(id);
            if (securityLoginsLogPoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsLogPoco);
        }

        // POST: SecurityLoginsLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecurityLoginsLogPoco securityLoginsLogPoco = securityLoginsLogLogic.Get(id); //db.SecurityLoginsLogs.Find(id);
            secLoginLogPoco[0] = securityLoginsLogPoco;
            securityLoginsLogLogic.Delete(secLoginLogPoco);
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
