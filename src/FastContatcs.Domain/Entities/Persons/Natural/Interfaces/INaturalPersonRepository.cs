using FastContacts.Domain.Common.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Natural.Interfaces
{
    public interface INaturalPersonRepository : IRepository<NaturalPerson>
    {
        Task<List<NaturalPerson>> GetAll();
    }
}
