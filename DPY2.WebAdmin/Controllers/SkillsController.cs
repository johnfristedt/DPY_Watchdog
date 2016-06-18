using DPY2.WebAdmin.EntityFramework.Repositories;
using DPY2.WebAdmin.Models.AuthFilters;
using DPY2.WebAdmin.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DPY2.WebAdmin.Controllers
{
    /* -----------------------------------------
                     PUBLIC STUFF
       ----------------------------------------- */

    [RoutePrefix("api/v1/public/skills")]
    public class WebSkillsController : ApiController
    {
        IDpyRepository repository;

        public WebSkillsController()
        {
            this.repository = new DbDpyRepository();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetSkills()
        {
            return Ok(repository.GetSkills());
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

    [RoutePrefix("api/v1/private/skills")]
    [Watchdog]
    public class AdminSkillsController : ApiController
    {
        IDpyRepository repository;

        public AdminSkillsController()
        {
            this.repository = new DbDpyRepository();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetSkills()
        {
            return Ok(repository.GetSkills());
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetSkill(int id)
        {
            if (id > 0)
            {
                var em = repository.GetSkill(id);

                if (em != null)
                    return Ok(em);
            }

            return BadRequest();
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateSkill(Skill skill)
        {
            repository.CreateSkill(skill);
            return Ok();
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult UpdateSkill(Skill model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repository.UpdateSkill(model);

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSkill(int id)
        {
            if (id > 0)
            {
                repository.DeleteSkill(id);
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
