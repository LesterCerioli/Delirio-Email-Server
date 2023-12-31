using Delirio.Modules.Email.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delirio.Module.Infrastructure.Mappings.EFCore
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id); // Set the primary key

            // Map properties to columns
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(c => c.CustomerFirstName)
                .HasColumnName("CustomerFirstName")
                .HasMaxLength(100);

            builder.Property(c => c.CustomerMiddleName)
                .HasColumnName("CustomerMiddleName")
                .HasMaxLength(100);

            builder.Property(c => c.CustomerLastName)
                .HasColumnName("CustomerLastName")
                .HasMaxLength(100);

            builder.OwnsOne(p => p.Cpf)
                .Property(p => p.CPFNumber);

            builder.OwnsOne(p => p.DataLog)
                .Property(p => p.DataCriacao);

            builder.OwnsOne(p => p.DataLog)
                .Property(p => p.DataAtualizacao);

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            // Configure relationships
            builder.HasMany(c => c.Orders)
                .WithOne()
                .HasForeignKey("CustomerId") // Replace "CustomerId" with the actual foreign key property name in the Order class
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}