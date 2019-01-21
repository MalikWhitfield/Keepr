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
    public class VaultKeepController : ControllerBase
    {
        private readonly VaultKeepRepository _repo;
        public VaultKeepController(VaultKeepRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<VaultKeep> Get(int id)
        {
            VaultKeep result = _repo.GetVaultKeepById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult<List<VaultKeep>> Post([FromBody] VaultKeep VaultKeep)
        {
            VaultKeep result = _repo.AddVaultKeep(VaultKeep);
            return Created("api/VaultKeeps/" + result.Id, result);
        }

        [HttpPut("{id}")]
        public ActionResult<VaultKeep> Put(int id, [FromBody] VaultKeep VaultKeep)
        {
            try
            {
                VaultKeep updatedVaultKeep = _repo.EditVaultKeep(id, VaultKeep);
                return updatedVaultKeep;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound("NO SUCH VaultKeep");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            if (_repo.DeleteVaultKeep(id))
            {
                return Ok("Successfully Deleted!");
            }
            return BadRequest("Unable to Delete!");
        }
    }
}
