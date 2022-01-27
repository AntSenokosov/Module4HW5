using Module4HW5.Entities;

namespace Module4HW5.Entities;

public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public List<Project> Projects { get; set; } = new List<Project>();
}