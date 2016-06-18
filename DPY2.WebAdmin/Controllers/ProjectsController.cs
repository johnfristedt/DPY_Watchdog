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
using System.Web.Http.Cors;

namespace DPY2.WebAdmin.Controllers
{
    /* -----------------------------------------
                     PUBLIC STUFF
       ----------------------------------------- */

    [RoutePrefix("api/v1/public/projects")]
    public class WebProjectsController : ApiController
    {
        IDpyRepository repository;

        public WebProjectsController()
        {
            this.repository = new DbDpyRepository();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetProjects()
        {
            return Ok(repository.GetProjectsVM());
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProject(int id)
        {
            var vm = repository.GetProjectVM(id);

            if (vm != null)
                return Ok(vm);

            return BadRequest();
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

    [RoutePrefix("api/v1/private/projects")]
    [Watchdog]
    public class AdminProjectsController : ApiController
    {
        IDpyRepository repository;

        public AdminProjectsController()
        {
            this.repository = new DbDpyRepository();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetProjects()
        {
            return Ok(repository.GetProjectsDTO());
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProject(int id)
        {
            var vm = repository.GetProjectDTO(id);

            if (vm != null)
                return Ok(vm);

            return BadRequest();
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateProject(NewProject model)
        {
            if (ModelState.IsValid)
                if (repository.CreateProject(model))
                    return Ok();

            return BadRequest();
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult UpdateProject(EditProject model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repository.UpdateProject(new Project
            {
                Id = model.Id,
                Name = model.Name,
                Text = model.Description,
                ImageFileName = model.ImageFileName
            });

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProject(int id)
        {
            if (id > 0)
            {
                repository.DeleteProject(id);
                return Ok();
            }

            return BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
