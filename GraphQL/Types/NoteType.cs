using GraphQL.Types;
using NotesServer.Models;

namespace NotesServer.GraphQL.Types
{
    public class NoteType : ObjectGraphType<Note>
    {
        public NoteType()
        {
            Field(x => x.NoteId, type: typeof(IdGraphType)).Description("Id of the note");
            Field(x => x.UserId, type: typeof(IdGraphType)).Description("Id of the user");
            Field(x => x.Title).Description("Title of the note");
            Field(x => x.Content).Description("Content of the note");
            Field(x => x.CreatedDate, type: typeof(DateTimeGraphType)).Description("Timestamp when note was created");
        }
    }
}
