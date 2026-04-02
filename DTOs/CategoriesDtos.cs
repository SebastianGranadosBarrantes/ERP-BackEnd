public class CategoryDto
{
    public int Id {get; set;}

    public required string Name {get; set;}
}

public class CreateCategoryDto
{
    public required string Name {get; set;}
}
