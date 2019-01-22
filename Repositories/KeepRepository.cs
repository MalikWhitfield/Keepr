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
            return _db.Query<Keep>("SELECT * FROM Keeps WHERE isPrivate=false");
        }
        public Keep GetKeepById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
        }
        public Keep AddKeep(Keep newKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO keeps(name, description, img, isPrivate, userId)
            VALUES(@Name, @Description, @Img, @isPrivate, @UserId)
            ", newKeep);
            newKeep.Id = id;
            return newKeep;
        }

        public IEnumerable<Keep> GetKeepsByUserId(string id)
        {
            return _db.Query<Keep>("SELECT * FROM Keeps WHERE userId = @id", new { id });
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

        //DELETE KEEP
        public bool DeleteKeep(int id)
        {
            int success = _db.Execute("DELETE FROM Keeps WHERE id = @id", new { id });
            return success != 0;
        }
    }
}