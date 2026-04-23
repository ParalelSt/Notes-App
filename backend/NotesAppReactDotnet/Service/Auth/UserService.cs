using Microsoft.EntityFrameworkCore;
using NotesAppReactDotnet.Data;
using NotesAppReactDotnet.DTOs.Auth;
using NotesAppReactDotnet.Entities;
using NotesAppReactDotnet.Exceptions;

namespace NotesAppReactDotnet.Service.Auth;

public class UserService: IUserService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtTokenService _jwtTokenService;
    public UserService(AppDbContext dbContext, JwtTokenService jwtTokenService)
    {
        _dbContext = dbContext;
        _jwtTokenService = jwtTokenService;
    }
    
    public async Task<LoginResDto> LogIn(LoginReqDto dto)
    {
        if (string.IsNullOrEmpty(dto.Identifier)) 
            throw new CustomInvalidOperationException("You must enter an email or a username");
        
        if (string.IsNullOrEmpty(dto.Password)) 
            throw new CustomInvalidOperationException("You must enter a password");
        
        var user = await _dbContext.Users.FirstOrDefaultAsync(u =>
            u.Email == dto.Identifier.ToLower()
            || u.Username == dto.Identifier.ToLower());
        
        if (user == null)
            throw new UnauthorizedException("Invalid Credentials");

        var isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

        if (!isValid)
            throw new UnauthorizedException("Invalid Credentials");

        var token = _jwtTokenService.GenerateToken(user);

        return new LoginResDto
        {
            Email = user.Email,
            Username = user.Username,
            Token = token
        };
    }

    public async Task<RegisterResDto> Register(RegisterReqDto dto)
    {
        if (string.IsNullOrEmpty(dto.Email)) 
            throw new CustomInvalidOperationException("You must enter an email");
        
        if (string.IsNullOrEmpty(dto.Username)) 
            throw new CustomInvalidOperationException("You must enter a username");
        
        if (string.IsNullOrEmpty(dto.Password)) 
            throw new CustomInvalidOperationException("You must enter a password");
        
        if (dto.Password != dto.ConfirmPassword)
            throw new CustomInvalidOperationException("Passwords must match");
        
        var email = dto.Email.ToLower().Trim(); 
        //Performance loss
        var username = dto.Username.ToLower().Trim();
        
        var password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var existingUserName = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
        
        var existingEmail = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (existingUserName != null)
            throw new CustomInvalidOperationException("A user with that username already exists");
        
        if (existingEmail != null)
            throw new CustomInvalidOperationException("A user with that email already exists");

        var newUser = new User
        {
            Email = email,
            Username = username,
            PasswordHash = password,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        _dbContext.Add(newUser);
        await _dbContext.SaveChangesAsync();

        return new RegisterResDto
        {
            Email = newUser.Email,
            Username = newUser.Username,
        };
    }
}