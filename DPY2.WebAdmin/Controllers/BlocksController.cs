using DPY2.WebAdmin.EntityFramework.Repositories;
using DPY2.WebAdmin.Models.AuthFilters;
using DPY2.WebAdmin.Models.EntityModels;
using System.Web.Http;
using System.Web.Http.Description;

namespace DPY2.WebAdmin.Controllers
{
    /* -----------------------------------------
                     PUBLIC STUFF
       ----------------------------------------- */

    [RoutePrefix("api/v1/public/blocks")]
    public class WebBlocksController : ApiController
    {
        IDpyRepository repository;

        public WebBlocksController()
        {
            repository = new DbDpyRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBlocks()
        {
            return Ok(repository.GetBlocks());
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

    [RoutePrefix("api/v1/private/blocks")]
    [Watchdog]
    public class AdminBlocksController : ApiController
    {
        IDpyRepository repository;

        public AdminBlocksController()
        {
            repository = new DbDpyRepository();
        }

        [HttpPost]
        [Route("{pageId}")]
        [ResponseType(typeof(Block))]
        public IHttpActionResult CreateBlock(int pageId)
        {
            if (pageId <= 0)
                return BadRequest();

            var block = repository.CreateBlock(pageId);

            if (block == null)
                return NotFound();

            return Ok(block);
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteBlock(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!repository.DeleteBlock(id))
                return NotFound();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
