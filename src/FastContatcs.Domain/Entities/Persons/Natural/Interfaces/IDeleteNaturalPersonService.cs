using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Natural.Interfaces
{
    public interface IDeleteNaturalPersonService
    {
        Task Delete(Guid id);
    }
}
