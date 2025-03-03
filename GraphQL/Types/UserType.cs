using NotesServer.Models;

namespace NotesServer.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(x => x.UserId).Type<NonNullType<IdType>>().Description("Id of the user");
            descriptor.Field(x => x.UserName).Type<NonNullType<StringType>>().Description("Name of the user");
            descriptor.Field(x => x.UserEmail).Type<NonNullType<IdType>>().Description("Email of the user");
        }
    }
}
