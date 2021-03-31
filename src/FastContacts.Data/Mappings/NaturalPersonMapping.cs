using FastContacts.Domain.Entities.Persons.Natural;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastContacts.Data.Mappings
{
    public class NaturalPersonMapping : IEntityTypeConfiguration<NaturalPerson>
    {
        public void Configure(EntityTypeBuilder<NaturalPerson> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Gender)
                .IsRequired();

            builder.Property(c => c.Birthday)
                .IsRequired();

            builder.HasOne(c => c.Address);

            builder.HasOne(c => c.Document);

            builder.Ignore(c => c.CascadeMode);
            builder.Ignore(c => c.ValidationResult);

            builder.ToTable(nameof(NaturalPerson));
        }
    }
}
