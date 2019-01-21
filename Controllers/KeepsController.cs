using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeepsController : ControllerBase
    {
        private readonly KeepRepository _repo;
        public KeepsController(KeepRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<Keep> Get(int id)
        {
            Keep result = _repo.GetKeepById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<List<Keep>> Post([FromBody] Keep keep)
        {
            keep.UserId = HttpContext.User.Identity.Name;
            Keep result = _repo.AddKeep(keep);
            return Created("api/keeps/" + result.Id, result);
        }

        [HttpPut("{id}")]
        public ActionResult<Keep> Put(int id, [FromBody] Keep keep)
        {
            try
            {
                Keep updatedKeep = _repo.EditKeep(id, keep);
                return updatedKeep;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound("NO SUCH KEEP");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            if (_repo.DeleteKeep(id))
            {
                return Ok("Successfully Deleted!");
            }
            return BadRequest("Unable to Delete!");
        }
    }
}
