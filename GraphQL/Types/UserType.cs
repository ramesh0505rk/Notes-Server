using GraphQL.Types;
using NotesServer.Models;

namespace NotesServer.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.UserId, type: typeof(IdGraphType)).Description("Id of the user");
            Field(x => x.UserName).Description("Name of the user");
            Field(x => x.UserEmail).Description("Email of the user");
        }
    }
}
