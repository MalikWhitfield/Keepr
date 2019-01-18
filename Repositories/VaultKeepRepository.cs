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
        public IEnumerable<VaultKeep> GetAll()
        {
            return _db.Query<VaultKeep>("SELECT * FROM VaultKeeps");
        }
        public VaultKeep GetVaultKeepById(int id)
        {
            return _db.QueryFirstOrDefault<VaultKeep>($"SELECT * FROM VaultKeeps WHERE id = @id", new { id });
        }
        public VaultKeep AddVaultKeep(VaultKeep newVaultKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO VaultKeeps(title, description, isPrivate)
            VALUES(@Title, @Description, @isPrivate)
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
        public bool DeleteVaultKeep(int id)
        {
            int success = _db.Execute("DELETE FROM VaultKeeps WHERE id = @id", new { id });
            return success != 0;
        }
    }
}