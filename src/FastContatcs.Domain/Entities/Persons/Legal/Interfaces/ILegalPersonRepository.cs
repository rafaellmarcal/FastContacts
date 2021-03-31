using FastContacts.Domain.Common.Repository;
using FastContatcs.Domain.Entities.Persons.Legal;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Legal.Interfaces
{
    public interface ILegalPersonRepository : IRepository<LegalPerson>
    {
        Task<LegalPerson> GetLegalPersonWithAddressAndDocument(Guid id);
    }
}
