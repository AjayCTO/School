using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolERP.Models;

namespace SchoolERP.Controllers
{
    public class ClassStandardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ClassStandard/
        public ActionResult Index()
        {
            var classstandards = db.ClassStandards.Include(c => c.Employee);
            return View("ClassStandard", classstandards.ToList());
        }

        // GET: /ClassStandard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStandard classstandard = db.ClassStandards.Find(id);
            if (classstandard == null)
            {
                return HttpNotFound();
            }
            return View(classstandard);
        }

        // GET: /ClassStandard/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employee, "Id", "EmpCode");
            return View();
        }

        // POST: /ClassStandard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Roomno,FloorNo,Section,EmployeeID,MaxStudents,CreatedDate,UpdatedDate")] ClassStandard classstandard)
        {
            classstandard.CreatedDate = DateTime.Now;
            classstandard.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ClassStandards.Add(classstandard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employee, "Id", "EmpCode", classstandard.EmployeeID);
            return View(classstandard);
        }

        // GET: /ClassStandard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStandard classstandard = db.ClassStandards.Find(id);
            if (classstandard == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "Id", "EmpCode", classstandard.EmployeeID);
            return View(classstandard);
        }

        // POST: /ClassStandard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Roomno,FloorNo,Section,EmployeeID,MaxStudents,CreatedDate,UpdatedDate")] ClassStandard classstandard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classstandard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "Id", "EmpCode", classstandard.EmployeeID);
            return View(classstandard);
        }

        // GET: /ClassStandard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStandard classstandard = db.ClassStandards.Find(id);
            if (classstandard == null)
            {
                return HttpNotFound();
            }
            return View(classstandard);
        }

        // POST: /ClassStandard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassStandard classstandard = db.ClassStandards.Find(id);
            db.ClassStandards.Remove(classstandard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
