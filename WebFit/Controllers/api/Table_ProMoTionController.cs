using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebFit.Models;

namespace WebFit.Controllers.api
{
    public class Table_ProMoTionController : ApiController
    {
        private KruFitNesEntities db = new KruFitNesEntities();

        [HttpGet]
        [Route("api/Table_ProMoTion")]
        public IQueryable Get()
        {
            var data = db.Table_ProMoTion.AsEnumerable().Select(x => new
            {
                x.ID_ProMo,
                x.Pro_Name,
                x.Pro_Detail,

                Pro_Pic = "http://35b60dd4.ngrok.io/" + x.Pro_Pic
               


            }).AsQueryable();
            return data;
        }
    }
}