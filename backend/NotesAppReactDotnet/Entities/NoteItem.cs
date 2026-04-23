using System.Runtime.InteropServices.JavaScript;

namespace NotesAppReactDotnet.Entities;

public class NoteItem
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
     
    public int UserId { get; set; }
}