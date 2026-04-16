using Microsoft.EntityFrameworkCore;
using NotesAppReactDotnet.Data;
using NotesAppReactDotnet.DTOs;
using NotesAppReactDotnet.Entities;

namespace NotesAppReactDotnet.Service.Note;

public class NoteService: INoteService
{
    private readonly AppDbContext _dbContext;

    public NoteService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<NoteResponseDto> CreateNote(NoteRequestDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
        {
            throw new ArgumentException("Title can not be empty");
        }
        
        var newNote = new NoteItem
        {
            Title = dto.Title,
            Content = dto.Content,
        };

        _dbContext.Add(newNote);
        await _dbContext.SaveChangesAsync();

        return new NoteResponseDto
        {
            Title = newNote.Title,
            Content = newNote.Content,
        };
    }

    public async Task<List<NoteResponseDto>> GetNotes()
    {
        return await _dbContext.Notes.Select(n => new NoteResponseDto
        {
            Title = n.Title,
            Content = n.Content,
        }).ToListAsync();
    }

    public async Task<List<NoteResponseDto>> GetNotesFromCurrentUser(int userId)
    {
        //Add user AUTH before this
        
        throw new NotImplementedException();
    }

    public async Task<NoteResponseDto> GetNoteById(int noteId)
    {
        //Add later CONSIDER LOOKUP OVER TITLE
        
        throw new NotImplementedException();
    }

    public async Task<NoteResponseDto> UpdateNote(UpdateRequestDto dto, int noteId)
    {
        var note = await _dbContext.Notes.FindAsync(noteId);

        if (note == null)
        {
            throw new NullReferenceException("Note not found");
        }

        note.Title = dto.Title;
        note.Content = dto.Content ?? note.Content;

        await _dbContext.SaveChangesAsync();

        return new NoteResponseDto
        {
            Title = note.Title,
            Content = note.Content,
        };
    }

    public async Task<NoteResponseDto> DeleteNote(int noteId)
    {
        throw new NotImplementedException();
    }
}