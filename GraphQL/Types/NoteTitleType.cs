using NotesServer.Models;

namespace NotesServer.GraphQL.Types
{
    public class NoteTitleType:ObjectType<NoteTitle>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteTitle> descriptor)
        {
            descriptor.Field(x => x.Title).Type<NonNullType<StringType>>().Description("Title of the note");
        }
    }
}
