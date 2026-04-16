using System.ComponentModel.DataAnnotations;

namespace NotesAppReactDotnet.DTOs.Auth;

public class LoginReqDto
{
    [Required]
    public string Identifier { get; set; }
    
    [Required]
    public string Password {get; set;}
}