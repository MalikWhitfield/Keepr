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
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepRepository _repo;
        public VaultKeepsController(VaultKeepRepository repo)
        {
            _repo = repo;
        }

        //GET VAULTKEEPS
        [HttpGet("{vaultId}")]
        public IEnumerable<Keep> Get(int vaultId)
        {
            return _repo.GetKeepsFromVault(vaultId);
        }

        //POST A VAULTKEEP
        [Authorize]
        [HttpPost]
        public ActionResult<List<VaultKeep>> Post([FromBody] VaultKeep VaultKeep)
        {
            VaultKeep.UserId = HttpContext.User.Identity.Name;
            if (VaultKeep.UserId != null)
            {
                VaultKeep result = _repo.AddVaultKeep(VaultKeep);
                return Created("api/VaultKeeps/" + result.Id, result);
            }
            return BadRequest("Unable to create vaultkeep");
        }

        //EDIT VAULT KEEPS
        #region
        // [HttpPut("{id}")]
        // public ActionResult<VaultKeep> Put(int id, [FromBody] VaultKeep VaultKeep)
        // {
        //     try
        //     {
        //         VaultKeep updatedVaultKeep = _repo.EditVaultKeep(id, VaultKeep);
        //         return updatedVaultKeep;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex);
        //         return NotFound("NO SUCH VaultKeep");
        //     }
        // }
        #endregion


        //DELETE KEEPS FROM VAULTS
        [HttpPut]
        public ActionResult<string> Delete([FromBody]VaultKeep vaultKeep)
        {
            var result = _repo.DeleteVaultKeep(vaultKeep);
            if (result != false)
            {
                return Ok("Successfully Deleted!");
            }
            return BadRequest("Unable to Delete!");
        }
    }
}
