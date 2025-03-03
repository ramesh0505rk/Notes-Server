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
        //public async Task<Note> AddNote(string UserId, string Title, string Content, [Service] DbContext context)
        //{
        //    //Guid NoteId = Guid.NewGuid();
        //    //var query = "insert into Notes (NoteId,UserId,Title,Content) values (@NoteId,@UserId,@Title,@Content)";
        //    //using var connection = context.CreateConnection();
        //    //var parameters = new {NoteId=NoteId,UserId=UserId,Title=Title,Content=Content};
        //    //await connection.ExecuteAsync(query, parameters);
        //    //var createdDateTime = connection.QueryAsync("select ")
        //    //return new Note { NoteId=NoteId,UserId=UserId,Title=Title,Content=Content,CreatedDate };
        //}
    }
}
