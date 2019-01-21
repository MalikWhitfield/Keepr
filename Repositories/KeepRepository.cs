using System;
using System.Collections.Generic;
using keepr.Models;
using Dapper;
using System.Data;

namespace keepr.Repositories
{
    public class KeepRepository
    {
        private readonly IDbConnection _db;
        public KeepRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM Keeps");
        }
        public Keep GetKeepById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
        }
        public Keep AddKeep(Keep newKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO Keeps(name, description, isPrivate)
            VALUES(@Name, @Description, @isPrivate)
            ", newKeep);
            newKeep.Id = id;
            return newKeep;
        }


        public Keep EditKeep(int id, Keep newKeep)
        {
            try
            {
                return _db.QueryFirstOrDefault<Keep>(@"
                UPDATE Keeps SET
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
        public bool DeleteKeep(int id)
        {
            int success = _db.Execute("DELETE FROM Keeps WHERE id = @id", new { id });
            return success != 0;
        }
    }
}