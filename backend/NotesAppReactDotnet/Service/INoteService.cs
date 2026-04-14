using NotesAppReactDotnet.DTOs;

namespace NotesAppReactDotnet.Service;

public interface INoteService
{
    Task<NoteResponseDto> CreateNote(NoteRequestDto dto);
    Task<List<NoteResponseDto>> GetNotes();
    Task<List<NoteResponseDto>> GetNotesFromCurrentUser(int userId);
    Task<NoteResponseDto> GetNoteById(int noteId);
    Task<NoteResponseDto> UpdateNote(UpdateRequestDto dto, int noteId);
    Task<NoteResponseDto> DeleteNote(int noteId);
}