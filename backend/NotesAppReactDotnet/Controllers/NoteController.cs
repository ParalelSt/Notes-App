using Microsoft.AspNetCore.Mvc;
using NotesAppReactDotnet.DTOs;
using NotesAppReactDotnet.Service.Note;

namespace NotesAppReactDotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpPost("create-note")]
    public async Task<ActionResult<NoteResponseDto>> CreateNote(NoteRequestDto dto)
        => await _noteService.CreateNote(dto);

    [HttpGet("get-notes")]
    public async Task<ActionResult<List<NoteResponseDto>>> GetNotes()
        => await _noteService.GetNotes();

    [HttpGet("get-notes-user/${userId}")]
    public async Task<ActionResult<List<NoteResponseDto>>> GetNotesFromCurrentUser(int userId)
        => await _noteService.GetNotesFromCurrentUser(userId);

    [HttpGet("get-note-by-id/${noteId}")]
    public async Task<ActionResult<NoteResponseDto>> GetNoteById(int noteId)
        => await _noteService.GetNoteById(noteId);

    [HttpPatch("update-note/${noteId}")]
    public async Task<ActionResult<NoteResponseDto>> UpdateNote(UpdateRequestDto dto, int noteId)
        => await _noteService.UpdateNote(dto, noteId);

    [HttpDelete("delete-note/${noteId}")]
    public async Task<ActionResult<NoteResponseDto>> DeleteNote(int noteId)
        => await _noteService.DeleteNote(noteId);
}