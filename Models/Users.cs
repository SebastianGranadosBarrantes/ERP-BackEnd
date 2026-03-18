
public class Users
{
    public int Id {get; set;}
    public required string Email {get; set;}

    public required string Password {get; set;}

    public required string CreatedAt {get; set;}

    public int IdRol {get; set;}

    public required string Username {get; set;}

    public required Rols role {get; set;}
}