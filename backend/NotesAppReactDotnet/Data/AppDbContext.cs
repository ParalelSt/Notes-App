using Microsoft.EntityFrameworkCore;
using NotesAppReactDotnet.Entities;

namespace NotesAppReactDotnet.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<NoteItem> Notes { get; set; }
    
}