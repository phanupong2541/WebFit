using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebFit.Controllers
{
    [Route("Default")]
    public class DefaultController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Gettest()
        {
            return null;
        }
    }
}
