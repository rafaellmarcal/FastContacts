using FastContacts.Data.Context;
using FastContacts.Data.Repository._Base;
using FastContacts.Domain.Entities.Persons.Natural;
using FastContacts.Domain.Entities.Persons.Natural.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FastContacts.Data.Repository
{
    public class NaturalPersonRepository : Repository<NaturalPerson>, INaturalPersonRepository
    {
        public NaturalPersonRepository(FastContactsDbContext context)
            : base(context) { }

        public async Task<NaturalPerson> GetNaturalPersonWithAddressAndDocument(Guid id)
        {
            return await DbSet
                .Include(p => p.Address)
                .Include(p => p.Document)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
