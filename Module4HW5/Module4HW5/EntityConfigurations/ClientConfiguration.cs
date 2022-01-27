using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client").HasKey(c => c.Id);
        builder.Property(e => e.Id).HasColumnName("ClientId").ValueGeneratedOnAdd();
        builder.Property(e => e.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
        builder.Property(e => e.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
        builder.Property(e => e.Email).IsRequired().HasColumnName("Email");
        builder.Property(e => e.Phone).IsRequired().HasColumnName("Phone").HasMaxLength(15);

        builder.HasData(new List<Client>()
        {
            new Client()
            {
                Id = 1,
                FirstName = "Vlad",
                LastName = "Gricak",
                Email = "v.g@gmail.com",
                Phone = "+380663424343"
            },
            new Client()
            {
                Id = 2,
                FirstName = "Stas",
                LastName = "Nizik",
                Email = "s.n@gmail.com",
                Phone = "+380995323373"
            },
            new Client()
            {
                Id = 3,
                FirstName = "Danil",
                LastName = "Levinskiy",
                Email = "d.l@gmail.com",
                Phone = "+380673436442"
            },
            new Client()
            {
                Id = 4,
                FirstName = "Vova",
                LastName = "Tkachenko",
                Email = "v.t@gmail.com",
                Phone = "+380987543234"
            },
            new Client()
            {
                Id = 5,
                FirstName = "Dmitriy",
                LastName = "Pyatak",
                Email = "d.p@gmail.com",
                Phone = "+380992346342"
            },
        });
    }
}