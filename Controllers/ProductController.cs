using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;


[Route("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly MyDbContext _context;

    public ProductController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
    {

        return await _context.Products.Include(p => p.Category).ToListAsync();
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Products>> GetProduct(int id)
    {
        var product = await _context.Products.Include(p => p.Category)
        .FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }


    [HttpPost("register")]
    public async Task<ActionResult<ProductDto>> createRol(CreateProductDto product)
    {
        if (string.IsNullOrWhiteSpace(product.Name) ||
            string.IsNullOrWhiteSpace(product.Price.ToString()) ||
            string.IsNullOrWhiteSpace(product.Stock.ToString()) ||
            string.IsNullOrWhiteSpace(product.IdCategory.ToString()))
        {
            return BadRequest("All fields are required");
        }

        var existingName = await _context.Products
            .FirstOrDefaultAsync(p => p.Name == product.Name);

        if (existingName != null)
            return Conflict("Product name already in use");

        Products productToSave = new Products
        {
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            IdCategory = product.IdCategory
        };

        try
        {
            _context.Products.Add(productToSave);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "An error occurred while saving the product");
        }

        ProductDto response = new ProductDto
        {
            Id = productToSave.Id,
            Name = productToSave.Name,
            Price = productToSave.Price,
            Stock = productToSave.Stock,
            IdCategory = productToSave.IdCategory
        };

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.IdCategory = dto.IdCategory;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }



    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Remove(product);

        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}