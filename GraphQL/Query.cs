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

        public async Task<IEnumerable<Note>> GetNotesByUserId(string UserId, [Service] DbContext dbContext)
        {
            var query = "select * from Notes where UserId=@UserId";
            using var connection = dbContext.CreateConnection();
            var parameters = new { UserId = UserId };
            return await connection.QueryAsync<Note>(query, parameters);
        }

        public async Task<Note> GetNotesByNoteId(Guid NoteId, [Service] DbContext dbContext)
        {
            var query = "select * from Notes where NoteId=@NoteId";
            using var connection = dbContext.CreateConnection();
            var parameters = new { NoteId = NoteId };
            return await connection.QueryFirstAsync<Note>(query, parameters);
        }

        public async Task<IEnumerable<User>> GetUsers([Service] DbContext dbContext)
        {
            var query = "select * from Users";
            using var connection = dbContext.CreateConnection();
            return await connection.QueryAsync<User>(query);
        }

        public async Task<IEnumerable<NoteTitle>> GetNoteTitles(string userId, [Service] DbContext dbContext)
        {
            var query = "select Title from Notes where UserId=@UserId";
            using var connection = dbContext.CreateConnection();
            var parameters = new { UserId = userId };
            return await connection.QueryAsync<NoteTitle>(query, parameters);
        }
    }
}
