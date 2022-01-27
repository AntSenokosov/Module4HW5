namespace Module4HW5.Entities;

public class EmployeeProject
{
    public int Id { get; set; }
    public decimal Rate { get; set; }
    public DateTime StartedDate { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}