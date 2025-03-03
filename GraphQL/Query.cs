using Dapper;
using GraphQL.Resolvers;
using GraphQL.Types;
using NotesServer.Context;
using NotesServer.GraphQL.Types;
using NotesServer.Models;

namespace NotesServer.GraphQL
{
    public class Query : ObjectGraphType
    {
        public Query(DbContext dbContext)
        {
            AddField(new FieldType
            {
                Name = "notes",
                Type = typeof(ListGraphType<NoteType>),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var query = "SELECT * FROM Notes";
                    using var connection = dbContext.CreateConnection();
                    return connection.Query<Note>(query).ToList();
                })
            });
        }
    }
}
