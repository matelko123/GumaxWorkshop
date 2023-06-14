using GumaxWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GumaxWorkshop.Infrastructure.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);
        
        builder.Property(c => c.FirstName)
            .IsRequired(false)
            .HasMaxLength(50);

        builder.Property(c => c.LastName)
            .IsRequired(false)
            .HasMaxLength(50);

        builder.Property(c => c.Address)
            .IsRequired(false)
            .HasMaxLength(100);
        
        builder.Property(c => c.CompanyName)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(c => c.NIP)
            .IsRequired(false)
            .HasMaxLength(15);
    }
}