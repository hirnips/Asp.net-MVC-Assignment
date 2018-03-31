﻿using System;
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
    public class SecurityRoleController : Controller
    {
        private SecurityRoleLogic securityRoleLogic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>());
        SecurityRolePoco[] secRolePoco = new SecurityRolePoco[1];

        //private CareerCloudContext db = new CareerCloudContext();

        // GET: SecurityRole
        public ActionResult Index()
        {
            return View(securityRoleLogic.GetAll());
        }

        // GET: SecurityRole/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityRolePoco securityRolePoco = securityRoleLogic.Get(id.Value); //db.SecurityRoles.Find(id);
            if (securityRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityRolePoco);
        }

        // GET: SecurityRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecurityRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Role,IsInactive")] SecurityRolePoco securityRolePoco)
        {
            if (ModelState.IsValid)
            {
                securityRolePoco.Id = Guid.NewGuid();
                secRolePoco[0] = securityRolePoco;
                securityRoleLogic.Add(secRolePoco);
                return RedirectToAction("Index");
            }

            return View(securityRolePoco);
        }

        // GET: SecurityRole/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityRolePoco securityRolePoco = securityRoleLogic.Get(id.Value); //db.SecurityRoles.Find(id);
            if (securityRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityRolePoco);
        }

        // POST: SecurityRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Role,IsInactive")] SecurityRolePoco securityRolePoco)
        {
            if (ModelState.IsValid)
            {
                secRolePoco[0] = securityRolePoco;
                securityRoleLogic.Update(secRolePoco);
                return RedirectToAction("Index");
            }
            return View(securityRolePoco);
        }

        // GET: SecurityRole/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityRolePoco securityRolePoco = securityRoleLogic.Get(id.Value); //db.SecurityRoles.Find(id);
            if (securityRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityRolePoco);
        }

        // POST: SecurityRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecurityRolePoco securityRolePoco = securityRoleLogic.Get(id); //db.SecurityRoles.Find(id);
            secRolePoco[0] = securityRolePoco;
            securityRoleLogic.Delete(secRolePoco);
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
