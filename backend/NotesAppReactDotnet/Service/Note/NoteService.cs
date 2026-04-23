using Microsoft.EntityFrameworkCore;
using NotesAppReactDotnet.Data;
using NotesAppReactDotnet.DTOs;
using NotesAppReactDotnet.Entities;
using NotesAppReactDotnet.Exceptions;

namespace NotesAppReactDotnet.Service.Note;

public class NoteService: INoteService
{
    private readonly AppDbContext _dbContext;

    public NoteService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<NoteResponseDto> CreateNote(NoteRequestDto dto, int userId)
    {
        if (string.IsNullOrEmpty(dto.Title))
        {
            throw new CustomInvalidOperationException("Title can not be empty");
        }
        
        var newNote = new NoteItem
        {
            Title = dto.Title,
            Content = dto.Content,
            UserId = userId
        };

        _dbContext.Add(newNote);
        await _dbContext.SaveChangesAsync();

        return new NoteResponseDto
        {
            Title = newNote.Title,
            Content = newNote.Content,
        };
    }

    public async Task<List<NoteResponseDto>> GetNotes(int userId)
    {
        var notes = _dbContext.Notes.Where(n => n.UserId == userId);

        if (notes == null)
            throw new NotFoundException("No notes found");
        
        return await notes.Select(n => new NoteResponseDto
        {
            Title = n.Title,
            Content = n.Content,
        }).ToListAsync();
    }

    public async Task<List<NoteResponseDto>> GetNotesFromCurrentUser(int userId)
    {
        if (userId <= 0)
        {
            throw new UnauthorizedException("You must be logged in to check your current notes");
        }

        var notes = await _dbContext.Notes
            .Where(n => n.UserId == userId)
            .ToListAsync();

        return notes.Select(n => new NoteResponseDto
        {
            Title = n.Title,
            Content = n.Content
        }).ToList();
    }

    public async Task<NoteResponseDto> GetNoteByTitle(string title, int userId)
    {
        if (string.IsNullOrEmpty(title))
            throw new CustomInvalidOperationException("You must provide a note identifier");
        
        var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Title == title);
    
        if (note == null)
            throw new NotFoundException("Note not found");
        
        if (note.UserId != userId)
            throw new UnauthorizedException("You can not read a note that isn't yours");

        return new NoteResponseDto
        {
            Title = note.Title,
            Content = note.Content
        };
    }

    public async Task<NoteResponseDto> UpdateNote(UpdateRequestDto dto, int noteId)
    {
        if (string.IsNullOrEmpty(dto.Title))
            throw new CustomInvalidOperationException("You must enter a title");
        
        if (string.IsNullOrEmpty(dto.Content))
            throw new CustomInvalidOperationException("You must enter some content");
        
        var note = await _dbContext.Notes.FindAsync(noteId);

        if (note == null)
        {
            throw new NotFoundException("Note not found");
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

    public async Task<bool> DeleteNote(int noteId, int userId)
    {
        if (noteId <= 0)
            throw new CustomInvalidOperationException("You must provide a note identifier");
        
        var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == noteId);
    
        if (note == null)
            throw new NotFoundException("Note not found");
        
        if (note.UserId != userId)
            throw new UnauthorizedException("You can not delete a note that isn't yours");

        _dbContext.Remove(note);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}