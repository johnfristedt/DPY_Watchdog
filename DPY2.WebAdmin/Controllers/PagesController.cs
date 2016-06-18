using DPY2.WebAdmin.EntityFramework.Repositories;
using DPY2.WebAdmin.Models.AuthFilters;
using DPY2.WebAdmin.Models.DTOModels;
using DPY2.WebAdmin.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DPY2.WebAdmin.Controllers
{
    /* -----------------------------------------
                     PUBLIC STUFF
       ----------------------------------------- */

    [RoutePrefix("api/v1/public/pages")]
    public class WebPagesController : ApiController
    {
        IDpyRepository repository;

        public WebPagesController()
        {
            repository = new DbDpyRepository();
        }

        [HttpGet]
        [Route("names")]
        public IHttpActionResult GetPageNames()
        {
            return Ok(repository.GetPageNames());
        }

        [HttpGet]
        [Route("meta")]
        public IHttpActionResult GetPagesMeta()
        {
            return Ok(repository.GetPagesMeta());
        }

        [HttpGet]
        [Route("{pageName}")]
        public IHttpActionResult GetPage(string pageName)
        {
            return Ok(repository.GetPage(pageName));
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }


    /* -----------------------------------------
                      ADMIN STUFF
       ----------------------------------------- */

    [RoutePrefix("api/v1/private/pages")]
    [Watchdog]
    public class AdminPagesController : ApiController
    {
        IDpyRepository repository;

        public AdminPagesController()
        {
            repository = new DbDpyRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetPages()
        {
            return Ok(repository.GetPages());
        }

        [HttpGet]
        [Route("{pageName}")]
        [ResponseType(typeof(Page))]
        public IHttpActionResult GetPage(string pageName)
        {
            var page = repository.GetPage(pageName);

            if (page == null)
                return NotFound();

            return Ok(page);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Page))]
        public IHttpActionResult CreatePage(NewPage model)
        {
            if (String.IsNullOrWhiteSpace(model.Name))
                return BadRequest();

            repository.CreatePage(model);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdatePage(int id, Page page)
        {
            if (id != page.Id)
                return BadRequest();

            repository.UpdatePage(page);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeletePage(int id)
        {
            if (id <= 0 || !repository.DeletePage(id))
                return BadRequest();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
