

public class ProductDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required double Price { get; set; }

    public required int Stock { get; set; }

    public required int IdCategory { get; set; }

    public  Categories Category { get; set; }

}


public class CreateProductDto
{
    public required string Name { get; set; }

    public required double Price { get; set; }

    public required int Stock { get; set; }

    public required int IdCategory { get; set; }

}

public class UpdateProductDto
{
    public required string Name { get; set; }

    public required double Price { get; set; }

    public required int Stock { get; set; }

    public required int IdCategory { get; set; }

}