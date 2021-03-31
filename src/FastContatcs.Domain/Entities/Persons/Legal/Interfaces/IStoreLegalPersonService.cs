using FastContacts.Domain.Entities.Persons.Legal.Dtos;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Legal.Interfaces
{
    public interface IStoreLegalPersonService
    {
        Task Store(LegalPersonDto dto);
    }
}
