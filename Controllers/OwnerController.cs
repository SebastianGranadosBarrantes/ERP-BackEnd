using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;


[Route("api/[controller]")]
[ApiController]

public class UsersController : ControllerBase
{
    private readonly MyDbContext _context;

    public UsersController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Users>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDto dto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFound();

        user.Email = dto.Email;
        user.Username = dto.Username;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }



    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Remove(user);

        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}