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
    
    public class CompanyJobSkillController : Controller
    {
        private CompanyJobSkillLogic companyJobSkillLogic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>());
        CompanyJobSkillPoco[] compJobSkillsPoco = new CompanyJobSkillPoco[1];
        List<CompanyJobSkillPoco> compSkills = new List<CompanyJobSkillPoco>();
        //private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobSkill
        public ActionResult Index()
        {
            //compSkills =  Session["CompanyData"];
            var companyJobSkills = companyJobSkillLogic.GetAll();// db.CompanyJobSkills.Include(c => c.CompanyJob);
            return View(companyJobSkills);
        }

        // GET: CompanyJobSkill/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobSkillPoco companyJobSkillPoco = companyJobSkillLogic.Get(id.Value);// db.CompanyJobSkills.Find(id);
            if (companyJobSkillPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobSkillPoco);
        }

        // GET: CompanyJobSkill/Create
        public ActionResult Create(Guid job)
        {
            //ViewBag.Job = JobId; //new SelectList(companyJobSkillLogic.GetAll(), "Job", "Job");
            return View();
        }

        // POST: CompanyJobSkill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,Skill,SkillLevel,Importance,TimeStamp")] CompanyJobSkillPoco companyJobSkillPoco)
        {
            
            if (ModelState.IsValid)
            {
               
                companyJobSkillPoco.Id = Guid.NewGuid();
                //Session["Data"] = compJobSkillsPoco;
                //Session["Skill"] = companyJobSkillPoco.Skill;
                //Session["SkillLevel"] = companyJobSkillPoco.SkillLevel;
                //Session["Importance"] = companyJobSkillPoco.Importance;
                //compSkills.Add(companyJobSkillPoco);

                compJobSkillsPoco[0] = companyJobSkillPoco;
                Guid id1 = Guid.Parse(Session["Company"].ToString());
                //companyJobSkillPoco.Job = id;

                // companyLogic.AddSkills(companyJobSkillPoco);

                //ViewBag.skills = compJobSkills;
                companyJobSkillLogic.Add(compJobSkillsPoco);

                
                return RedirectToAction("Details","CompanyJob", new { id = id1});
            }

            ViewBag.Job = new SelectList(companyJobSkillLogic.GetAll(), "Job", "Job");
            return View(companyJobSkillPoco);
        }

        // GET: CompanyJobSkill/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobSkillPoco companyJobSkillPoco = companyJobSkillLogic.Get(id.Value); //db.CompanyJobSkills.Find(id);
            if (companyJobSkillPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(companyJobSkillLogic.GetAll(), "Job", "Job");
            return View(companyJobSkillPoco);
        }

        // POST: CompanyJobSkill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,Skill,SkillLevel,Importance,TimeStamp")] CompanyJobSkillPoco companyJobSkillPoco)
        {
            if (ModelState.IsValid)
            {
                compJobSkillsPoco[0] = companyJobSkillPoco;
                companyJobSkillLogic.Update(compJobSkillsPoco);
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(companyJobSkillLogic.GetAll(), "Job", "Job");
            return View(companyJobSkillPoco);
        }

        // GET: CompanyJobSkill/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobSkillPoco companyJobSkillPoco = companyJobSkillLogic.Get(id.Value); //db.CompanyJobSkills.Find(id);
            if (companyJobSkillPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobSkillPoco);
        }

        // POST: CompanyJobSkill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobSkillPoco companyJobSkillPoco = companyJobSkillLogic.Get(id); //db.CompanyJobSkills.Find(id);
            compJobSkillsPoco[0] = companyJobSkillPoco;
            companyJobSkillLogic.Delete(compJobSkillsPoco);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    //if (disposing)
        //    //{
        //    //    db.Dispose();
        //    //}
        //    base.Dispose(disposing);
        //}
    }
}
