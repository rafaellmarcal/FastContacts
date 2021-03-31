using FastContacts.Data.Context;
using FastContacts.Data.Repository._Base;
using FastContacts.Domain.Entities.Persons.Legal.Interfaces;
using FastContatcs.Domain.Entities.Persons.Legal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FastContacts.Data.Repository
{
    public class LegalPersonRepository : Repository<LegalPerson>, ILegalPersonRepository
    {
        public LegalPersonRepository(FastContactsDbContext context)
            : base(context) { }

        public async Task<LegalPerson> GetLegalPersonWithAddressAndDocument(Guid id)
        {
            return await DbSet
                .Include(p => p.Address)
                .Include(p => p.Document)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
