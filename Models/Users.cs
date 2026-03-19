using System.ComponentModel.DataAnnotations.Schema;

public class Users
{
    public Users()
    {
    }

    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Username { get; set; }

    public int IdRol { get; set; }

    [ForeignKey("IdRol")]
    public Rols role { get; set; }
}