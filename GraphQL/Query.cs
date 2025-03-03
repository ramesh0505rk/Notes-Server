using Dapper;
using NotesServer.Context;
using NotesServer.GraphQL.Types;
using NotesServer.Models;

namespace NotesServer.GraphQL
{
    public class Query
    {
        public async Task<IEnumerable<Note>> GetNotes([Service] DbContext dbContext)
        {
            var query = "select * from Notes";
            using var connection = dbContext.CreateConnection();
            return await connection.QueryAsync<Note>(query);
        }
        public async Task<IEnumerable<User>> GetUsers([Service] DbContext dbContext)
        {
            var query = "select * from Users";
            using var connection = dbContext.CreateConnection();
            return await connection.QueryAsync<User>(query);
        }
    }
}
