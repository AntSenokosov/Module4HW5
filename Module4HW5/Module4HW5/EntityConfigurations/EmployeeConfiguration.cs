using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee").HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("EmployeeId").ValueGeneratedOnAdd();
        builder.Property(e => e.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
        builder.Property(e => e.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
        builder.Property(e => e.HiredDate).IsRequired().HasColumnName("HiredDate").HasMaxLength(7);
        builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("date");
        builder.HasOne(e => e.Title)
            .WithMany(t => t.Employees)
            .HasForeignKey(i => i.TitleId);
        builder.HasOne(e => e.Office)
            .WithMany(o => o.Employees)
            .HasForeignKey(i => i.OfficeId);
    }
}