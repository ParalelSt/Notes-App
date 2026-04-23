using NotesAppReactDotnet.DTOs;

namespace NotesAppReactDotnet.Service.Note;

public interface INoteService
{
    Task<NoteResponseDto> CreateNote(NoteRequestDto dto, int userId);
    Task<List<NoteResponseDto>> GetNotes(int userId);
    Task<List<NoteResponseDto>> GetNotesFromCurrentUser(int userId);
    Task<NoteResponseDto> GetNoteByTitle(string title, int userId);
    Task<NoteResponseDto> UpdateNote(UpdateRequestDto dto, int noteId);
    Task<bool> DeleteNote(int noteId, int userId);
}