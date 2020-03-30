using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFit.Models;

namespace WebFit.Controllers
{
    public class Table_UserController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        // GET: Table_User
        public ActionResult Index(string search)
        {
            var table_User = db.Table_User;
            return View(table_User.ToList());
        }

      
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_User table_User = db.Table_User.Find(id);
            if (table_User == null)
            {
                return HttpNotFound();
            }
            return View(table_User);
        }

     
        public ActionResult Create()
        {

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table_User data, HttpPostedFileBase UploadFileBase, string code)
        {
            try
            {
                if (data.User_Pass != data.User_CHKPASS)
                {
                    ModelState.AddModelError("User_Pass", "********พาสเวิดไม่ตรงกัน************");
                    ModelState.AddModelError("User_CHKPASS", "********พาสเวิดไม่ตรงกัน************");
                    return View(data);
                }
                if (code == "ADMIN2541")
                    data.User_Type = true;
                else data.User_Type = false;

                db.Table_User.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {



                return View(data);
            }

        }

        public ActionResult CreateAD()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAD(Table_User data, HttpPostedFileBase UploadFileBase, string code)
        {
            try
            {
                if (data.User_Pass != data.User_CHKPASS)
                {
                    ModelState.AddModelError("User_Pass", "********พาสเวิดไม่ตรงกัน************");
                    ModelState.AddModelError("User_CHKPASS", "********พาสเวิดไม่ตรงกัน************");
                    return View(data);
                }
                if (code == "ADMIN2541")
                    data.User_Type = true;
                else data.User_Type = false;

                db.Table_User.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {



                return View(data);
            }

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Logind(string Username, string Password)
        {
            if (Username != null && Password != null)
            {
                var Log = db.Table_User.Where(a => a.ID_User == Username && a.User_Pass == Password).FirstOrDefault();
                if (Log != null)
                {
                    Session["pass"] = "pass";
                    Session["name"] = Log.ID_User;
                    Session["Id_User"] = Log.ID_User;
                    if (Log.User_Type == true)
                    {

                        Session["pay"] = "set";
                        return RedirectToAction("Index", "Table_User");

                    }
                    else
                    {
                        return RedirectToAction("Create", "Table_Buy");

                    }

                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}
