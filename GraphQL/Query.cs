using GraphQL.Types;
using NotesServer.Context;
using NotesServer.GraphQL.Types;
using NotesServer.Models;

namespace NotesServer.GraphQL
{
    public class Query:ObjectGraphType
    {
        public Query(DbContext dbContext) {
            //Field<ListGraphType<NoteType>>(
            //    "notes",
            //    resolve: context =>
            //    {
            //        var query = "select * from Notes";
            //        using var connection = dbContext.CreateConnection();
            //        return connection.Query<Note>(query).ToList();
            //    }
            //    );
        }
    }
}
