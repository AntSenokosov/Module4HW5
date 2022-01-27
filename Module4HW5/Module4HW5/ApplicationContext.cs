using Microsoft.EntityFrameworkCore;
using Module4HW5.Entities;
using Module4HW5.EntityConfigurations;

namespace Module4HW5;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TitleConfiguration());
        modelBuilder.ApplyConfiguration(new OfficeConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
    }
}