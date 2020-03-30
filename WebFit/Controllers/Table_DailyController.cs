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
    public class Table_DailyController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_Daily
        public ActionResult Index()
        {
            var table_Daily = db.Table_Daily.Include(t => t.Table_Cost).Include(t => t.Table_User);
            return View(table_Daily.ToList());
        }

        // GET: Table_Daily/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Daily table_Daily = db.Table_Daily.Find(id);
            if (table_Daily == null)
            {
                return HttpNotFound();
            }
            return View(table_Daily);
        }

        // GET: Table_Daily/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cost = new SelectList(db.Table_Cost, "ID_Cost", "Cost_Name");
            ViewBag.ID_UserDaily = new SelectList(db.Table_User, "ID_User", "User_Name");
            return View();
        }

        // POST: Table_Daily/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table_Daily table_Daily)
        {
            if (ModelState.IsValid)
            {
                table_Daily.Date_Daily = DateTime.Now;
                db.Table_Daily.Add(table_Daily);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cost = new SelectList(db.Table_Cost, "ID_Cost", "Cost_Name", table_Daily.ID_Cost);
            ViewBag.ID_UserDaily = new SelectList(db.Table_User, "ID_User", "User_Name", table_Daily.ID_UserDaily);
            return View(table_Daily);
        }

        // GET: Table_Daily/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Daily table_Daily = db.Table_Daily.Find(id);
            if (table_Daily == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cost = new SelectList(db.Table_Cost, "ID_Cost", "Cost_Name", table_Daily.ID_Cost);
            ViewBag.ID_UserDaily = new SelectList(db.Table_User, "ID_User", "User_Name", table_Daily.ID_UserDaily);
            return View(table_Daily);
        }

        // POST: Table_Daily/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Daily,ID_UserDaily,ID_Cost,Date_Daily")] Table_Daily table_Daily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Daily).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cost = new SelectList(db.Table_Cost, "ID_Cost", "Cost_Name", table_Daily.ID_Cost);
            ViewBag.ID_UserDaily = new SelectList(db.Table_User, "ID_User", "User_Name", table_Daily.ID_UserDaily);
            return View(table_Daily);
        }

        // GET: Table_Daily/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Daily table_Daily = db.Table_Daily.Find(id);
            if (table_Daily == null)
            {
                return HttpNotFound();
            }
            return View(table_Daily);
        }

        // POST: Table_Daily/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Daily table_Daily = db.Table_Daily.Find(id);
            db.Table_Daily.Remove(table_Daily);
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
