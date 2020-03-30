using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFit.Models;

namespace WebFit.Controllers
{
    public class Table_DisposeController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_Dispose
        public ActionResult Index()
        {
            
            return View(db.Table_Dispose.ToList());
        }

        public ActionResult DisposeAgree(int? id)
        {
            var findid = db.Table_Dispose.FirstOrDefault(x => x.DIS_Status == 1 && x.CE_ATNO == id);
            findid.DIS_Status = 2;
            db.Entry(findid).State = EntityState.Modified;
            var findCE = db.Table_EQ.FirstOrDefault(x => x.CE_ATNO == id);
            findCE.CE_Status = 2;
            
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DisposeCancle(int? id)
        {
            var findid = db.Table_Dispose.FirstOrDefault(x => x.DIS_Status == 1 && x.CE_ATNO == id);
            findid.DIS_Status = 3;
            db.Entry(findid).State = EntityState.Modified;
            var findCE = db.Table_EQ.FirstOrDefault(x => x.CE_ATNO == id);
            findCE.CE_Status = 1;
            
           
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Table_Dispose/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Dispose table_Dispose = db.Table_Dispose.Find(id);
            if (table_Dispose == null)
            {
                return HttpNotFound();
            }
            return View(table_Dispose);
        }

        // GET: Table_Dispose/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Table_Dispose/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table_Dispose table_Dispose)
        {
            if (ModelState.IsValid)
            {
                db.Table_Dispose.Add(table_Dispose);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(table_Dispose);
        }

        // GET: Table_Dispose/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Dispose table_Dispose = db.Table_Dispose.Find(id);
            if (table_Dispose == null)
            {
                return HttpNotFound();
            }
           
            return View(table_Dispose);
        }

        // POST: Table_Dispose/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dis_ATNO,CE_ATNO,DIS_DateOUT,DIS_DateAPP,Dis_Status")] Table_Dispose table_Dispose)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Dispose).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(table_Dispose);
        }

        // GET: Table_Dispose/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Dispose table_Dispose = db.Table_Dispose.Find(id);
            if (table_Dispose == null)
            {
                return HttpNotFound();
            }
            return View(table_Dispose);
        }

        // POST: Table_Dispose/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Dispose table_Dispose = db.Table_Dispose.Find(id);
            db.Table_Dispose.Remove(table_Dispose);
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
