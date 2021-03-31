using FastContatcs.Domain.Entities.Persons.Legal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastContacts.Data.Mappings
{
    public class LegalPersonMapping : IEntityTypeConfiguration<LegalPerson>
    {
        public void Configure(EntityTypeBuilder<LegalPerson> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.CompanyName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.TradeName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasOne(c => c.Address);

            builder.HasOne(c => c.Document);

            builder.Ignore(c => c.CascadeMode);
            builder.Ignore(c => c.ValidationResult);

            builder.ToTable(nameof(LegalPerson));
        }
    }
}
