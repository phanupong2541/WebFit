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
    public class Table_ProMoTionController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_ProMoTion
        public ActionResult Index()
        {
            return View(db.Table_ProMoTion.ToList());
        }

        // GET: Table_ProMoTion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_ProMoTion table_ProMoTion = db.Table_ProMoTion.Find(id);
            if (table_ProMoTion == null)
            {
                return HttpNotFound();
            }
            return View(table_ProMoTion);
        }

        // GET: Table_ProMoTion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_ProMoTion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table_ProMoTion data, HttpPostedFileBase UploadFileBase)
        {
            if (UploadFileBase != null && UploadFileBase.ContentLength > 0)
            {
                var myUniqueFileName = DateTime.Now.Ticks + ".jpg";
                string physicalPath = Server.MapPath("~/img/" + myUniqueFileName);
                UploadFileBase.SaveAs(physicalPath);
                data.Pro_Pic = "img/" + myUniqueFileName;

            }

            if (ModelState.IsValid)
            {
                db.Table_ProMoTion.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        // GET: Table_ProMoTion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_ProMoTion table_ProMoTion = db.Table_ProMoTion.Find(id);
            if (table_ProMoTion == null)
            {
                return HttpNotFound();
            }
            return View(table_ProMoTion);
        }

        // POST: Table_ProMoTion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ProMo,Pro_Name,Pro_Detail,Pro_Price")] Table_ProMoTion table_ProMoTion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_ProMoTion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_ProMoTion);
        }

      

        // POST: Table_ProMoTion/Delete/5
        public ActionResult Delete(int id)
        {
            Table_ProMoTion table_ProMoTion = db.Table_ProMoTion.Find(id);
            db.Table_ProMoTion.Remove(table_ProMoTion);
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
