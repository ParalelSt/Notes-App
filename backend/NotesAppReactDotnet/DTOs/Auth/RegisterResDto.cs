using System.ComponentModel.DataAnnotations;

namespace NotesAppReactDotnet.DTOs.Auth;

public class RegisterReqDto
{
    public string Email { get; set; }
    
    public string Username { get; set; }

    public string Password {get; set;}
    
    public string ConfirmPassword { get; set; }
}