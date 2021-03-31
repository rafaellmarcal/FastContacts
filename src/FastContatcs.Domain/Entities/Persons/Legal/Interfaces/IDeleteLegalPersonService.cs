using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Legal.Interfaces
{
    public interface IDeleteLegalPersonService
    {
        Task Delete(Guid id);
    }
}
