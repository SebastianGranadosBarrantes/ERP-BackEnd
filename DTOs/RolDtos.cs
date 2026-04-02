public class RolDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Privileges {get; set;}

}

public class CreateRolDto
{
    

    public required string Name { get; set; }

    public required string Privileges {get; set;}

}