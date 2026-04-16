using System.ComponentModel.DataAnnotations;

namespace NotesAppReactDotnet.DTOs.Auth;

public class RegisterResDto
{
    public string Email { get; set; }
    
    public string Username { get; set; }
}