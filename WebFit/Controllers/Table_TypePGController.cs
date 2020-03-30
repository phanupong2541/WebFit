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
    public class Table_TypePGController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_TypePG
        public ActionResult Index()
        {
            return View(db.Table_TypePG.ToList());
        }

        // GET: Table_TypePG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_TypePG table_TypePG = db.Table_TypePG.Find(id);
            if (table_TypePG == null)
            {
                return HttpNotFound();
            }
            return View(table_TypePG);
        }

        // GET: Table_TypePG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_TypePG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TypePG,TypePG_Name")] Table_TypePG table_TypePG)
        {
            if (ModelState.IsValid)
            {
                db.Table_TypePG.Add(table_TypePG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_TypePG);
        }

        // GET: Table_TypePG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_TypePG table_TypePG = db.Table_TypePG.Find(id);
            if (table_TypePG == null)
            {
                return HttpNotFound();
            }
            return View(table_TypePG);
        }

        // POST: Table_TypePG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TypePG,TypePG_Name")] Table_TypePG table_TypePG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_TypePG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_TypePG);
        }

        // GET: Table_TypePG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_TypePG table_TypePG = db.Table_TypePG.Find(id);
            if (table_TypePG == null)
            {
                return HttpNotFound();
            }
            return View(table_TypePG);
        }

        // POST: Table_TypePG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_TypePG table_TypePG = db.Table_TypePG.Find(id);
            db.Table_TypePG.Remove(table_TypePG);
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
