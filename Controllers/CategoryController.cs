using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;


[Route("api/[controller]")]
[ApiController]

public class CategoriesController : ControllerBase
{
    private readonly MyDbContext _context;

    public CategoriesController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<CategoryDto>> createCategory(CreateCategoryDto category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            return BadRequest("Name is required");
        }

        var existingName = await _context.Categories
            .FirstOrDefaultAsync(c => c.Name == category.Name);

        if (existingName != null)
            return Conflict("Category name already in use");

        Categories categoryToSave = new Categories
        {
            Name = category.Name
        };

        try
        {
            _context.Categories.Add(categoryToSave);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "An error occurred while saving the category");
        }

        CategoryDto response = new CategoryDto
        {
            Id = categoryToSave.Id,
            Name = categoryToSave.Name
        };

        return Ok(response);
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Categories>> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return category;
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> updateCategory(int id, CategoryDto dto)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
            return NotFound();

        category.Name = dto.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }



    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        _context.Remove(category);

        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}
