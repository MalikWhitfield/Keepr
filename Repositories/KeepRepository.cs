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
            INSERT INTO keeps(name, description, img, isPrivate, userId, shares, views, keeps)
            VALUES(@Name, @Description, @Img, @isPrivate, @UserId, @Shares, @Views, @Keeps)
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

            _db.QueryFirstOrDefault<Keep>(@"
                UPDATE Keeps SET
                isPrivate = @isPrivate,
                shares = @Shares,
                views = @Views,
                keeps = @Keeps
                SELECT * FROM keeps WHERE id= @Id AND userId = @UserId", newKeep);
            return newKeep;

        }


        //DELETE KEEP
        public bool DeleteKeep(int id)
        {
            int success = _db.Execute("DELETE FROM Keeps WHERE id = @id", new { id });
            return success != 0;
        }

    }
}