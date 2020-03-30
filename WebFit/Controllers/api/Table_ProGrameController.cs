using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebFit.Models;

namespace WebFit.Controllers.api
{
    public class Table_ProgrameController : ApiController
    {
        private KruFitNesEntities db = new KruFitNesEntities();
        [HttpGet]
        [Route("api/Table_Programe")]
        public IQueryable Get()
        {          
            var data = db.Table_ProGrame.AsEnumerable().Select(x => new
            {
                x.ID_Programe,
                x.PG_Name,
                x.Table_TypePG.TypePG_Name,
               
                x.PG_Detail,

                PG_Pic = "http://35b60dd4.ngrok.io/" + x.PG_Pic,
              /*  PG_Video = "http://ffde2629.ngrok.io/video/" +*/ x.PG_Video


            }).AsQueryable();
            return data;
        }

        [Route("api/Table_Programe/SearchPrograme/{keyword}")]
        [HttpGet]
        public IQueryable SearchPrograme(string keyword)
        {

            var data = db.Table_ProGrame.AsEnumerable().Where(p => p.PG_Name.Contains(keyword)).Select(x => new
            {
                x.PG_Name,
                x.Table_TypePG.TypePG_Name,
                x.PG_Detail,
                x.PG_Video,
                PG_Pic = "http://0eb73cbb.ngrok.io/" + x.PG_Pic,
                x.ID_Programe



            }).AsQueryable();
            return data;
        }


    }
}