using Watchdog.Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace Watchdog.Controllers
{
    [RoutePrefix("token")]
    public class TokenController : ApiController
    {
        [Authorize]
        [Route("authenticate")]
        [HttpGet]
        public IHttpActionResult Authenticate()
        {
            return Ok();
        }
    }
}
