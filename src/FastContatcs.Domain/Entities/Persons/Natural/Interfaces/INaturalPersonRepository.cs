using FastContacts.Domain.Common.Repository;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Natural.Interfaces
{
    public interface INaturalPersonRepository : IRepository<NaturalPerson>
    {
        Task<NaturalPerson> GetNaturalPersonWithAddressAndDocument(Guid id);
    }
}
