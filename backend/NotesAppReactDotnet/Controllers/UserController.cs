using Microsoft.AspNetCore.Mvc;
using NotesAppReactDotnet.DTOs.Auth;
using NotesAppReactDotnet.Service.Auth;

namespace NotesAppReactDotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResDto>> Register(RegisterReqDto dto)
        => await _userService.Register(dto);

    [HttpPost("log-in")]
    public async Task<ActionResult<LoginResDto>> LogIn(LoginReqDto dto)
        => await _userService.LogIn(dto);
}
