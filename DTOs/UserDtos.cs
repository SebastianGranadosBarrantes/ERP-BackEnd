using System.ComponentModel.DataAnnotations;

public class UpdateUserDto
{

    public required string Email { get; set; }

    public required string Username { get; set; }

}


public class UserDto
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public  string Email { get; set; }

    [Required]
    public  DateTime CreatedAt;

    public int IdRol { get; set; }

    [Required]
    public  string Username { get; set; }

    public string? Token { get; set; }
}

public class CreateUserDto
{
    public required string Email { get; set; }

    public int IdRol { get; set; }

    public required string Username { get; set; }

    public required string Password {get; set;}

}