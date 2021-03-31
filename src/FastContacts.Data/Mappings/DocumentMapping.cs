using FastContatcs.Domain.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastContacts.Data.Mappings
{
    public class DocumentMapping : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Type)
                .IsRequired();

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Ignore(c => c.CascadeMode);
            builder.Ignore(c => c.ValidationResult);

            builder.ToTable(nameof(Document));
        }
    }
}
