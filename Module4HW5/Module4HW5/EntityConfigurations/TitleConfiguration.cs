using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations;

public class TitleConfiguration : IEntityTypeConfiguration<Title>
{
    public void Configure(EntityTypeBuilder<Title> builder)
    {
        builder.ToTable("Title").HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("TitleId").ValueGeneratedOnAdd();
        builder.Property(t => t.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
    }
}