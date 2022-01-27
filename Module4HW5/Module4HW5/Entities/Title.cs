namespace Module4HW5.Entities;

public class Title
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Employee> Employees { get; set; } = new List<Employee>();
}