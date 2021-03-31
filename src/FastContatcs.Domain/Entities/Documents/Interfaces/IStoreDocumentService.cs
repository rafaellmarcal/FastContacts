using FastContacts.Domain.Entities.Documents.Dtos;
using FastContatcs.Domain.Entities.Documents;

namespace FastContacts.Domain.Entities.Documents.Interfaces
{
    public interface IStoreDocumentService
    {
        Document Store(DocumentDto dto);
    }
}
