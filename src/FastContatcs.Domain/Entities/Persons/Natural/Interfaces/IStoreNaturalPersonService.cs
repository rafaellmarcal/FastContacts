using FastContacts.Domain.Entities.Persons.Natural.Dtos;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Natural.Interfaces
{
    public interface IStoreNaturalPersonService
    {
        Task Store(NaturalPersonDto dto);
    }
}
