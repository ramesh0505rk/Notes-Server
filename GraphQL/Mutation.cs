using Dapper;
using NotesServer.Context;
using NotesServer.Models;

namespace NotesServer.GraphQL
{
    public class Mutation
    {
        public async Task<User> AddUser(string UserId, string UserName, string UserEmail, [Service] DbContext context)
        {
            var query = "insert into Users values (@UserId,@UserName,@UserEmail)";
            using var connection = context.CreateConnection();
            var parameters = new { UserId = UserId, UserName = UserName, UserEmail = UserEmail };
            await connection.ExecuteAsync(query, parameters);
            return new User { UserId = UserId, UserName = UserName, UserEmail = UserEmail, };
        }
    }
}
