using System.ComponentModel.DataAnnotations;

namespace NotesAppReactDotnet.DTOs.Auth;

public class LoginResDto
{
    public string Token { get; set; }
    
    public string Email { get; set; }
    
    public string Username { get; set; }
}