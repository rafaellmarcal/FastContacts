using FastContatcs.Domain.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastContacts.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.AddressOne)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(c => c.AddressTwo)
                .HasColumnType("varchar(250)");

            builder.Property(c => c.City)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.State)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Country)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Ignore(c => c.CascadeMode);
            builder.Ignore(c => c.ValidationResult);

            builder.ToTable(nameof(Address));
        }
    }
}
