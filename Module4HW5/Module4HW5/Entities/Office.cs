namespace Module4HW5.Entities;

public class Office
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Location { get; set; } = null!;
    public List<Employee> Employees { get; set; } = new List<Employee>();
}