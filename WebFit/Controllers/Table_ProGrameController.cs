using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFit.Models;

namespace WebFit.Controllers
{
    public class Table_ProGrameController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_ProGrame
        public ActionResult Index()
        {
            var table_ProGrame = db.Table_ProGrame.Include(t => t.Table_TypePG);
            return View(table_ProGrame.ToList());
        }

        

        // GET: Table_ProGrame/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_ProGrame table_ProGrame = db.Table_ProGrame.Find(id);
            if (table_ProGrame == null)
            {
                return HttpNotFound();
            }
            return View(table_ProGrame);
        }

        // GET: Table_ProGrame/Create
        public ActionResult Create()
        {
            ViewBag.PG_Type = new SelectList(db.Table_TypePG, "ID_TypePG", "TypePG_Name");
            return View();
        }

        // POST: Table_ProGrame/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     
        [ValidateInput (false)]
        public ActionResult Create(Table_ProGrame data, HttpPostedFileBase UploadFileBase )
        {

            if (UploadFileBase != null && UploadFileBase.ContentLength > 0)
            {
                var myUniqueFileName = DateTime.Now.Ticks + ".jpg";
                string physicalPath = Server.MapPath("~/img/" + myUniqueFileName);
                UploadFileBase.SaveAs(physicalPath);
                data.PG_Pic = "img/" + myUniqueFileName;
                
            }

            if (ModelState.IsValid)
            {


                db.Table_ProGrame.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            ViewBag.PG_Type = new SelectList(db.Table_TypePG, "ID_TypePG", "TypePG_Name", data.PG_Type);
            return View(data);
        }

       
        // GET: Table_ProGrame/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Table_ProGrame table_ProGrame = db.Table_ProGrame.Find(id);
        //    if (table_ProGrame == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(table_ProGrame);
        //}

        // POST: Table_ProGrame/Delete/5
       
        public ActionResult Delete(int id)
        {
            Table_ProGrame table_ProGrame = db.Table_ProGrame.Find(id);
            db.Table_ProGrame.Remove(table_ProGrame);
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
