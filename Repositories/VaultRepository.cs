using System;
using System.Collections.Generic;
using keepr.Models;
using Dapper;
using System.Data;

namespace keepr.Repositories
{
    public class VaultRepository
    {
        private readonly IDbConnection _db;
        public VaultRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Vault> GetAll()
        {
            return _db.Query<Vault>("SELECT * FROM Vaults");
        }
        public Vault GetVaultById(int id)
        {
            return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vaults WHERE id = @id", new { id });
        }
        public Vault AddVault(Vault newVault)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO Vaults(title, description, isPrivate, UserId)
            VALUES(@Title, @Description, @isPrivate, @UserId)
            ", newVault);
            newVault.Id = id;
            return newVault;
        }
        public Vault EditVault(int id, Vault newVault)
        {
            try
            {
                return _db.QueryFirstOrDefault<Vault>(@"
                UPDATE Vaults SET
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
        public bool DeleteVault(int id)
        {
            int success = _db.Execute("DELETE FROM Vaults WHERE id = @id", new { id });
            return success != 0;
        }
    }
}