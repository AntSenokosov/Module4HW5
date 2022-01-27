using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Project").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("ProjectId").ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
        builder.Property(p => p.Budget).IsRequired().HasColumnName("Budget").HasColumnType("money");
        builder.Property(p => p.StartedDate).IsRequired().HasColumnName("StartedDate").HasMaxLength(7);

        builder.HasOne(p => p.Client)
            .WithMany(c => c.Projects)
            .HasForeignKey(h => h.ClientId);

        builder.HasData(new List<Project>()
        {
            new Project()
            {
                Id = 1,
                Name = "Project for study",
                Budget = 500000,
                StartedDate = new DateTime(2021, 12, 12),
                ClientId = 1
            },
            new Project()
            {
                Id = 2,
                Name = "Game",
                Budget = 1200000,
                StartedDate = new DateTime(2022, 5, 3),
                ClientId = 2
            },
            new Project()
            {
                Id = 3,
                Name = "Web application",
                Budget = 78000,
                StartedDate = new DateTime(2021, 6, 29),
                ClientId = 1
            },
            new Project()
            {
                Id = 4,
                Name = "Desktop application",
                Budget = 230000,
                StartedDate = new DateTime(2022, 1, 23),
                ClientId = 4
            },
            new Project()
            {
                Id = 5,
                Name = "Database development",
                Budget = 10000,
                StartedDate = new DateTime(2022, 2, 4),
                ClientId = 3
            }
        });
    }
}