using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;

[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    private readonly MyDbContext _context;

    public AuthController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto user)
    {
        if (string.IsNullOrWhiteSpace(user.Email) ||
            string.IsNullOrWhiteSpace(user.Username) ||
            string.IsNullOrWhiteSpace(user.Password))
        {
            return BadRequest("Email, username and password are required");
        }

        var existingEmail = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == user.Email);

        if (existingEmail != null)
            return Conflict("Email already in use");

        var existingUsername = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == user.Username);

        if (existingUsername != null)
            return Conflict("Username already in use");

        var roleExists = await _context.Rols.AnyAsync(r => r.Id == user.IdRol);
        Console.WriteLine($"The role found is {roleExists}");
        if (!roleExists)
            return BadRequest("The specified role does not exist");

        Users userToSave = new Users
        {
            Email = user.Email,
            Username = user.Username,
            IdRol = user.IdRol,
            Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
            CreatedAt = DateTime.UtcNow
        };

        try
        {
            _context.Users.Add(userToSave);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "An error occurred while saving the user");
        }

        UserDto response = new UserDto
        {
            Id = userToSave.Id,
            Email = userToSave.Email,
            Username = userToSave.Username,
            IdRol = userToSave.IdRol,
            CreatedAt = userToSave.CreatedAt,
            Token = "token"
        };

        return Ok(response);
    }
}