using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolERP.Models;
using System.Linq.Dynamic;


namespace SchoolERP.Controllers
{
    public class FeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fees
        public ActionResult Index()
        {
            return View(db.Fees.ToList());
        }

        public ActionResult LoadData()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var searchitem = Request["search[value]"];
            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var v = (from a in db.Fees select a);
            if (!string.IsNullOrEmpty(searchitem))
            {

                v = v.Where(b => b.Type.Contains(searchitem));
            }
            //SORT
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
               v = v.OrderBy(sortColumn + " " + sortColumnDir);
            }

            recordsTotal = v.Count();
            var data = v.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data.Select(x => new { x.Id, x.Type, x.Amount }) }, JsonRequestBehavior.AllowGet);
        }

        // GET: Fees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fees fees = db.Fees.Find(id);
            if (fees == null)
            {
                return HttpNotFound();
            }
            return View(fees);
        }

        // GET: Fees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Amount,CreatedDate,UpdatedDate")] Fees fees)
        {
            fees.CreatedDate = DateTime.Now;
            fees.UpdatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Fees.Add(fees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fees);
        }

        // GET: Fees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fees fees = db.Fees.Find(id);
            if (fees == null)
            {
                return HttpNotFound();
            }
            return View(fees);
        }

        // POST: Fees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Amount,CreatedDate,UpdatedDate")] Fees fees)
        {
            fees.CreatedDate = DateTime.Now;
            fees.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(fees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fees);
        }

        // GET: Fees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fees fees = db.Fees.Find(id);
            if (fees == null)
            {
                return HttpNotFound();
            }
            return View(fees);
        }

        // POST: Fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fees fees = db.Fees.Find(id);
            db.Fees.Remove(fees);
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
