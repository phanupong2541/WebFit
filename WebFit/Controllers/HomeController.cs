using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFit.Models;

namespace WebFit.Controllers
{
    public class HomeController : Controller
    {
        private KruFitNesEntities db = new KruFitNesEntities();
   
        public ActionResult Index()
        {
           
            Session["priceCost"] = db.Table_Cost.ToList();

            return View(db.Table_Cost.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Am()
        {
            return View();
        }

        public ActionResult Trainner()
        {
            return View();
        }

        public ActionResult Programe()
        {
            return View(db.Table_ProGrame.ToList());
        }
    }
}