namespace NotesServer.Models
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
