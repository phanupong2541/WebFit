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
    public class Table_CostController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_Cost
        public ActionResult Index()
        {
          
            return View(db.Table_Cost.ToList());
        }

        // GET: Table_Cost/Details/5
     

        // GET: Table_Cost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_Cost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cost,Cost_Name,Cost_Price")] Table_Cost table_Cost)
        {
            if (ModelState.IsValid)
            {
                db.Table_Cost.Add(table_Cost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Cost);
        }

        // GET: Table_Cost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Cost table_Cost = db.Table_Cost.Find(id);
            if (table_Cost == null)
            {
                return HttpNotFound();
            }
            return View(table_Cost);
        }

        // POST: Table_Cost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cost,Cost_Name,Cost_Price")] Table_Cost table_Cost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Cost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Cost);
        }

        // GET: Table_Cost/Delete/5
        
        public ActionResult Delete(int id)
        {
            Table_Cost table_Cost = db.Table_Cost.Find(id);
            db.Table_Cost.Remove(table_Cost);
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
