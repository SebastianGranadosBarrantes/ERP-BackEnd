using System.ComponentModel.DataAnnotations.Schema;

public class Orders
{
    public required int Id { get; set; }

    public required string Status { get; set; }

    public required string CreatedAt { get; set; }

    public required string UpdatedAt { get; set; }

    public required int IdClient { get; set; }

    public required int IdWorker { get; set; }

    [ForeignKey("IdClient")]

    public required Clients Client { get; set; }

    [ForeignKey("IdWorker")]

    public required Workers Worker { get; set; }

}