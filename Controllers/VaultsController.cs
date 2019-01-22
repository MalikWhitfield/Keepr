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
    public class VaultsController : ControllerBase
    {
        private readonly VaultRepository _repo;
        public VaultsController(VaultRepository repo)
        {
            _repo = repo;
        }
        
        //GET ALL USER VAULTS
        [HttpGet] 
        public ActionResult<IEnumerable<Vault>> GetAllVaultsByUserId()
        {
            var userId = HttpContext.User.Identity.Name;
            return Ok(_repo.GetAll(userId));
        }
        
         //GET A SINGLE VAULT
        [HttpGet("{id}")]
        public ActionResult<Vault> Get(int id)
        {
            Vault result = _repo.GetVaultById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //POST A VAULT
        [Authorize]
        [HttpPost]
        public ActionResult<Vault> Post([FromBody] Vault Vault)
        {
            Vault.UserId = HttpContext.User.Identity.Name;
            Vault result = _repo.AddVault(Vault);
            return Created("api/vaults/" + result.Id, result);
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
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            // string uid = HttpContext.User.Identity.Name;
            if (_repo.DeleteVault(id))
            {
                return Ok("Successfully Deleted!");
            }
            return BadRequest("Unable to Delete!");
        }
    }
}
