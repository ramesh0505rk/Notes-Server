using NotesServer.Models;

namespace NotesServer.GraphQL.Types
{
    public class NoteType : ObjectType<Note>
    {
        protected override void Configure(IObjectTypeDescriptor<Note> descriptor)
        {
            descriptor.Field(x => x.NoteId).Type<NonNullType<IdType>>().Description("Id of the note");
            descriptor.Field(x => x.UserId).Type<NonNullType<IdType>>().Description("Id of the user");
            descriptor.Field(x => x.Title).Type<NonNullType<StringType>>().Description("Title of the note");
            descriptor.Field(x => x.Content).Type<NonNullType<StringType>>().Description("Content of the note");
            descriptor.Field(x => x.CreatedDate).Type<NonNullType>().Description("Timestamp when the note was created");
        }
    }
}
