using System.ComponentModel.DataAnnotations.Schema;

public class Products
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required double Price { get; set; }

    public required int Stock { get; set; }

    public required int IdCategory { get; set; }

    [ForeignKey("IdCategory")]

    public Categories Category { get; set; }

}