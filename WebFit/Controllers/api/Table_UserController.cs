using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;
using WebFit.Models;

namespace WebFit.Controllers.api
{
    public class Table_UserController : ApiController
    {
        private KruFitNesEntities db = new KruFitNesEntities();
        [HttpGet]
        [Route("api/Table_User")]
        public IQueryable Get()
        { 
            var data = db.Table_User.AsEnumerable().Select(x => new
            {
                x.ID_User,
                x.User_Height,
                x.User_Weight,
                x.User_Tell,

                buys = x.Table_Buy.ToList().Select(a => new {a.Buy_Start,
                a.Buy_Stop,
                a.Buy_Cost,
                a.TotlePrice,
                a.Table_Cost.Cost_Name,
                a.Table_ProMoTion.Pro_Name,
                }),
               

            }).AsQueryable();
            return data;
        }

        [HttpPost]
        [Route("api/Table_User")]
        public HttpResponseMessage Post()
        {
            Table_User table_user = new Table_User();
            var httpRequest = HttpContext.Current.Request;


            table_user.User_Pass = HttpContext.Current.Request["User_Pass"];
            table_user.User_Name = HttpContext.Current.Request["User_Name"];
            table_user.ID_User = HttpContext.Current.Request["ID_User"];
            table_user.User_Height = Convert.ToDouble(HttpContext.Current.Request["User_Height"]);
            table_user.User_Weight = Convert.ToDouble(HttpContext.Current.Request["User_Weight"]);
            table_user.User_Tell = HttpContext.Current.Request["User_Tell"];
            table_user.User_Type = false;




            db.Table_User.Add(table_user);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("api/Table_User/Login")]
        public HttpResponseMessage Login()
        {
            var Email = HttpContext.Current.Request["ID_User"];
            var Pass = HttpContext.Current.Request["User_Pass"];

            var Log = db.Table_User.Where(a => a.ID_User == Email && a.User_Pass == Pass).FirstOrDefault();
            if (Log != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}