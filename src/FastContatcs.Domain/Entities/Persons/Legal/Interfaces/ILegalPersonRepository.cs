using FastContacts.Domain.Common.Repository;
using FastContatcs.Domain.Entities.Persons.Legal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Legal.Interfaces
{
    public interface ILegalPersonRepository : IRepository<LegalPerson>
    {
        Task<List<LegalPerson>> GetAll();
    }
}
