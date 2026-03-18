public class Orders
{
    public required int Id { get; set; }

    public required string Status { get; set; }

    public required string CreatedAt { get; set; }

    public required string UpdatedAt { get; set; }

    public required int IdOwner { get; set; }

    public required int IdWorker { get; set; }

    public required Clients Client {get; set;}

    public required Workers Worker {get; set;}

}