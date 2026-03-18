public class UpdateUserDto 
{

    public required string Email {get; set;}

     public required string Username {get; set;}

}


public class UserDto
{
    public int Id {get; set;}
    public required string Email {get; set;}

    public required string CreatedAt;

    public int IdRol {get; set;}

    public required Rols role {get; set;}

     public required string Username {get; set;}
}