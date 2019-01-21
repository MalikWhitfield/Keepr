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
    public class VaultController : ControllerBase
    {
        private readonly VaultRepository _repo;
        public VaultController(VaultRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<Vault> Get(int id)
        {
            Vault result = _repo.GetVaultById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult<List<Vault>> Post([FromBody] Vault Vault)
        {
            Vault result = _repo.AddVault(Vault);
            return Created("api/Vaults/" + result.Id, result);
        }

        [HttpPut("{id}")]
        public ActionResult<Vault> Put(int id, [FromBody] Vault Vault)
        {
            try
            {
                Vault updatedVault = _repo.EditVault(id, Vault);
                return updatedVault;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound("NO SUCH Vault");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            if (_repo.DeleteVault(id))
            {
                return Ok("Successfully Deleted!");
            }
            return BadRequest("Unable to Delete!");
        }
    }
}
