using NotesAppReactDotnet.DTOs.Auth;

namespace NotesAppReactDotnet.Service.Auth;

public interface IUserService
{
    Task<LoginResDto> LogIn(LoginReqDto dto);
    Task<RegisterResDto> Register(RegisterReqDto dto);
}