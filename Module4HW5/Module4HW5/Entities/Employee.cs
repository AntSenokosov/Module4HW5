namespace Module4HW5.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime HiredDate { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int OfficeId { get; set; }
    public Office Office { get; set; } = null!;
    public int TitleId { get; set; }
    public Title Title { get; set; } = null!;
    public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}