using System.ComponentModel.DataAnnotations.Schema;

public class Workers
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string HiredAt { get; set; }

    public required int IdDepartment { get; set; }

    public required string Phone { get; set; }

    [ForeignKey("IdDepartment")]

    public required Departments Department { get; set; }
}