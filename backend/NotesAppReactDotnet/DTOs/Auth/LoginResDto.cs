using System.ComponentModel.DataAnnotations;

namespace NotesAppReactDotnet.DTOs.Auth;

public class LoginReqDto
{
    public string Email { get; set; }
    
    public string Username { get; set; }

    public string Password {get; set;}
}