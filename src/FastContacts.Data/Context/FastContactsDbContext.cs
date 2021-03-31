using FastContacts.Domain.Entities.Persons.Natural;
using FastContatcs.Domain.Entities.Addresses;
using FastContatcs.Domain.Entities.Documents;
using FastContatcs.Domain.Entities.Persons.Legal;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FastContacts.Data.Context
{
    public class FastContactsDbContext : DbContext
    {
        public FastContactsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastContactsDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
