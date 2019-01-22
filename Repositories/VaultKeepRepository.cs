using System;
using System.Collections.Generic;
using keepr.Models;
using Dapper;
using System.Data;

namespace keepr.Repositories
{
    public class VaultKeepRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Keep> GetAllVaultKeeps(int vaultId)
        {
            return _db.Query<Keep>(@"
            SELECT * FROM VaultKeeps vk
            INNER JOIN keeps k ON k.Id = vk.KeepId
            WHERE(vk.VaultId= @VaultId);",
            new { vaultId });
        }
        // public VaultKeep GetVaultsKeepById(int id)
        // {
        //     return _db.QueryFirstOrDefault<VaultKeep>($"SELECT * FROM VaultKeeps WHERE id = @id", new { id });
        // }
        public VaultKeep AddVaultKeep(VaultKeep newVaultKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO VaultKeeps(vaultId, keepId, userId)
            VALUES(@VaultId, @KeepId, @UserId)
            ", newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }
        public VaultKeep EditVaultKeep(int id, VaultKeep newVaultKeep)
        {
            try
            {
                return _db.QueryFirstOrDefault<VaultKeep>(@"
                UPDATE VaultKeeps SET
                Title = @Title,
                Description = @Description,
                isPrivate = @isPrivate,

                ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        public bool DeleteVaultKeep(VaultKeep vaultKeep)
        {
            int success = _db.Execute(@"DELETE FROM VaultKeeps WHERE keepId = @KeepId AND vaultId = @VaultId", vaultKeep);
            return success != 0;
        }
    }
}