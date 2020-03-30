using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebFit.Models;

namespace WebFit.Controllers
{
    public class Table_BuyController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_Buy
        public ActionResult Index()
        {
            var table_Buy = db.Table_Buy.Include(t => t.Table_Cost).Include(t => t.Table_ProMoTion).Include(t => t.Table_User);
            foreach (var item in table_Buy)
            {

                DateTime dt1 = Convert.ToDateTime(DateTime.Now);

                DateTime dt2 = Convert.ToDateTime(item.Buy_Stop);

                TimeSpan ts = dt2 - dt1;


                if (ts.Hours < 0)
                {
                    item.status = "หมด";
                }
                else
                {
                    item.status = "ใช้งาน";
                }
            }

            return View(table_Buy.ToList());
        }

        public ActionResult IndexUser()
        {
            var id = (Session["Id_User"]);

            var table_Buy = db.Table_Buy
                .Include(t => t.Table_Cost)
                .Include(t => t.Table_ProMoTion)
                .Include(t => t.Table_User).Where(x => x.Buy_User == id);
            foreach (var item in table_Buy)
            {
                if (item.Buy_Stop == null)
                {
                    item.status = "รอยืนยัน";

                }
                else
                {

                    DateTime dt1 = Convert.ToDateTime(DateTime.Now);

                    DateTime dt2 = Convert.ToDateTime(item.Buy_Stop);

                    TimeSpan ts = dt2 - dt1;
                    if (ts.Hours < 0)
                    {
                        item.status = "หมด";

                    }
                    else
                    {
                        item.status = "ใช้งาน";
                    }
                }

                
            }

            return View(table_Buy.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Buy table_Buy = db.Table_Buy.Find(id);
            if (table_Buy == null)
            {
                return HttpNotFound();
            }
            return View(table_Buy);
        }
        [HttpPost]
        public JsonResult whereCat(int id)
        {
            var a = db.Table_ProMoTion.SingleOrDefault(t => t.ID_ProMo == id);
            return Json(a.Pro_Price, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult WhereCost(int id)
        {
            var b = db.Table_Cost.FirstOrDefault(a => a.ID_Cost == id);
            return Json(b.Cost_Price, JsonRequestBehavior.AllowGet);
        }
        // GET: Table_Buy/Create
        public ActionResult Create()
        {
            ViewBag.Buy_Cost = new SelectList(db.Table_Cost, "ID_Cost", "Cost_Name");
            ViewBag.Buy_Pro = new SelectList(db.Table_ProMoTion, "ID_ProMo", "Pro_Name");

            return View();
        }
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Day - endDate.Day;
            return Math.Abs(monthsApart);
        }

        // POST: Table_Buy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table_Buy table_Buy, HttpPostedFileBase UploadFileBase)
        {
            if (UploadFileBase != null && UploadFileBase.ContentLength > 0)
            {
                var myUniqueFileName = DateTime.Now.Ticks + ".jpg";
                string physicalPath = Server.MapPath("~/img/" + myUniqueFileName);
                UploadFileBase.SaveAs(physicalPath);
                table_Buy.Buy_Pic = "img/" + myUniqueFileName;
            }

            table_Buy.Buy_Status = false;
            table_Buy.Buy_Start = null;
            table_Buy.Buy_Stop = null;
            if (ModelState.IsValid)
            {
                table_Buy.Buy_User = (Session["name"].ToString());
                db.Table_Buy.Add(table_Buy);
                db.SaveChanges();
                return RedirectToAction("IndexUser");
            }

            ViewBag.Buy_Cost = new SelectList(db.Table_Cost, "ID_Cost", "Cost_Name", table_Buy.Buy_Cost);
            ViewBag.Buy_Pro = new SelectList(db.Table_ProMoTion, "ID_ProMo", "Pro_Name", table_Buy.Buy_Pro);

            return View(table_Buy);
        }

        // GET: Table_Buy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Buy table_Buy = db.Table_Buy.Find(id);
            if (table_Buy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Buy_Cost = new SelectList(db.Table_Cost, "ID_Cost", "Cost_Name", table_Buy.Buy_Cost);
            ViewBag.Buy_Pro = new SelectList(db.Table_ProMoTion, "ID_ProMo", "Pro_Name", table_Buy.Buy_Pro);
            ViewBag.Buy_User = new SelectList(db.Table_User, "ID_User", "ID_Card", table_Buy.Buy_User);
            return View(table_Buy);
        }

        // POST: Table_Buy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Buy,Buy_User,Buy_Cost,Buy_Pro,Price,TotlePrice,Buy_Start,Buy_Stop")] Table_Buy table_Buy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Buy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Buy_Cost = new SelectList(db.Table_Cost, "ID_Cost", "Cost_Name", table_Buy.Buy_Cost);
            ViewBag.Buy_Pro = new SelectList(db.Table_ProMoTion, "ID_ProMo", "Pro_Name", table_Buy.Buy_Pro);
            ViewBag.Buy_User = new SelectList(db.Table_User, "ID_User", "ID_Card", table_Buy.Buy_User);
            return View(table_Buy);
        }

        // GET: Table_Buy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Buy table_Buy = db.Table_Buy.Find(id);
            if (table_Buy == null)
            {
                return HttpNotFound();
            }
            return View(table_Buy);
        }

        // POST: Table_Buy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Buy table_Buy = db.Table_Buy.Find(id);
            db.Table_Buy.Remove(table_Buy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Confirmed(int id)
        {


            Table_Buy table_Buy = db.Table_Buy.Find(id);


            DateTime t = DateTime.Today;

            var date = t.Date;
            table_Buy.Buy_Start = date;
            if (table_Buy.Buy_Cost == 1)
            {
                table_Buy.Buy_Stop = date.AddDays(1);

            }
            else if (table_Buy.Buy_Cost == 2)
            {
                table_Buy.Buy_Stop = date.AddDays(30);

            }
            else table_Buy.Buy_Stop = date.AddDays(365);


            table_Buy.Buy_Status = true;
            db.Entry(table_Buy).State = EntityState.Modified;
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
