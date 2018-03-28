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
    public class SecurityLoginsRoleController : Controller
    {
        private SecurityLoginsRoleLogic securityLoginsRoleLogic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>());
        SecurityLoginsRolePoco[] secLoginsRolePoco = new SecurityLoginsRolePoco[1];
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: SecurityLoginsRole
        public ActionResult Index()
        {
            var securityLoginsRoles = securityLoginsRoleLogic.GetAll(); //db.SecurityLoginsRoles.Include(s => s.SecurityLogin).Include(s => s.SecurityRole);
            return View(securityLoginsRoles.ToList());
        }

        // GET: SecurityLoginsRole/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = securityLoginsRoleLogic.Get(id); //db.SecurityLoginsRoles.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRole/Create
        public ActionResult Create()
        {
            ViewBag.Login = new SelectList(securityLoginsRoleLogic.GetAll(), "Login", "Login");
            ViewBag.Role = new SelectList(securityLoginsRoleLogic.GetAll(), "Role", "Role");
            return View();
        }

        // POST: SecurityLoginsRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Role,TimeStamp")] SecurityLoginsRolePoco securityLoginsRolePoco)
        {
            if (ModelState.IsValid)
            {
                securityLoginsRolePoco.Id = Guid.NewGuid();
                secLoginsRolePoco[0] = securityLoginsRolePoco;
                securityLoginsRoleLogic.Add(secLoginsRolePoco);
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(securityLoginsRoleLogic.GetAll(), "Login", "Login");
            ViewBag.Role = new SelectList(securityLoginsRoleLogic.GetAll(), "Role", "Role");
            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRole/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = securityLoginsRoleLogic.Get(id); //db.SecurityLoginsRoles.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(securityLoginsRoleLogic.GetAll(), "Login", "Login");
            ViewBag.Role = new SelectList(securityLoginsRoleLogic.GetAll(), "Role", "Role");
            return View(securityLoginsRolePoco);
        }

        // POST: SecurityLoginsRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Role,TimeStamp")] SecurityLoginsRolePoco securityLoginsRolePoco)
        {
            if (ModelState.IsValid)
            {
                secLoginsRolePoco[0] = securityLoginsRolePoco;
                securityLoginsRoleLogic.Update(secLoginsRolePoco);
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(securityLoginsRoleLogic.GetAll(), "Login", "Login");
            ViewBag.Role = new SelectList(securityLoginsRoleLogic.GetAll(), "Role", "Role");
            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRole/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = securityLoginsRoleLogic.Get(id); //db.SecurityLoginsRoles.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsRolePoco);
        }

        // POST: SecurityLoginsRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecurityLoginsRolePoco securityLoginsRolePoco = securityLoginsRoleLogic.Get(id); //db.SecurityLoginsRoles.Find(id);
            secLoginsRolePoco[0] = securityLoginsRolePoco;
            securityLoginsRoleLogic.Delete(secLoginsRolePoco);
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
