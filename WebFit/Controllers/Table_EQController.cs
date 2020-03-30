using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFit.Models;

namespace WebFit.Controllers
{
    public class Table_EQController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_EQ
        public ActionResult Index()
        {
            return View(db.Table_EQ.ToList());
        }

        // GET: Table_EQ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_EQ table_EQ = db.Table_EQ.Find(id);
            if (table_EQ == null)
            {
                return HttpNotFound();
            }
            return View(table_EQ);
        }
        public ActionResult Dispose(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var chk = db.Table_Dispose.Where(x => x.CE_ATNO == id).ToList();

                if (chk.Count == 0)
                {
                    Models.Table_Dispose dispose = new Table_Dispose()
                    {
                        DIS_DateOUT = DateTime.Now,
                        DIS_Status = 1,
                        CE_ATNO = id
                    };
                    db.Table_Dispose.Add(dispose);
                    var findCE = db.Table_EQ.FirstOrDefault(x => x.CE_ATNO == id);
                    findCE.CE_Status = 3;
                    
                  
                    db.SaveChanges();
                }
                else if (chk.Count > 0)
                {
                    int i = 0;
                    foreach (var collection in chk)
                    {
                        if (collection.DIS_Status == 1 || collection.DIS_Status == 2)
                        {
                            i++;
                        }
                    }

                    if (i == 0)
                    {
                        Models.Table_Dispose dispose = new Table_Dispose()
                        {
                            DIS_DateOUT = DateTime.Now,
                            DIS_Status = 1,
                            CE_ATNO = id
                        };
                        db.Table_Dispose.Add(dispose);
                        var findCE = db.Table_EQ.FirstOrDefault(x => x.CE_ATNO == id);
                        findCE.CE_Status = 3;
                        
                        
                        db.SaveChanges();
                    }
                    else
                    {
                        //แสดงข้อความว่ากดจำหน่ายไปแล้ว
                    }
                }
            }
            return RedirectToAction(nameof(Index), "Table_Dispose");
        }

        // GET: Table_EQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_EQ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table_EQ table_EQ, string datein)
        {
            try
            {
                table_EQ.CE_DateIn = DateTime.Now;
                table_EQ.CE_Status = 1;
                db.Table_EQ.Add(table_EQ);
                db.SaveChanges();

                var getno = db.Table_EQ.OrderByDescending(x => x.CE_ATNO).FirstOrDefault();


                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
                return View(table_EQ);
            }
        }

        // GET: Table_EQ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_EQ table_EQ = db.Table_EQ.Find(id);
            if (table_EQ == null)
            {
                return HttpNotFound();
            }
            return View(table_EQ);
        }

        // POST: Table_EQ/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CE_ATNO,CE_NO,CE_DateIN,CE_Name,CE_Noce,CE_Piece,CE_Price,CE_PriceTotal,CE_Status")] Table_EQ table_EQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_EQ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_EQ);
        }

        // GET: Table_EQ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_EQ table_EQ = db.Table_EQ.Find(id);
            if (table_EQ == null)
            {
                return HttpNotFound();
            }
            return View(table_EQ);
        }

        // POST: Table_EQ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_EQ table_EQ = db.Table_EQ.Find(id);
            db.Table_EQ.Remove(table_EQ);
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
