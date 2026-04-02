using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;


[Route("api/[controller]")]
[ApiController]

public class RolsController : ControllerBase
{
    private readonly MyDbContext _context;

    public RolsController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RolDto>> createRol(CreateRolDto rol)
    {
        if (string.IsNullOrWhiteSpace(rol.Name) ||
            string.IsNullOrWhiteSpace(rol.Privileges))
        {
            return BadRequest("Name and privileges are required");
        }

        var existingName = await _context.Rols
            .FirstOrDefaultAsync(r => r.Name == rol.Name);

        if (existingName != null)
            return Conflict("Role name already in use");

        Rols rolToSave = new Rols
        {
            Name = rol.Name,
            Privileges = rol.Privileges
        };

        try
        {
            _context.Rols.Add(rolToSave);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "An error occurred while saving the role");
        }

        RolDto response = new RolDto
        {
            Id = rolToSave.Id,
            Name = rolToSave.Name,
            Privileges = rolToSave.Privileges
        };

        return Ok(response);
    }
}
