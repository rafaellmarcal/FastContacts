using FastContacts.Domain.Entities.Documents.Dtos;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Documents.Interfaces
{
    public interface IUpdateDocumentService
    {
        Task Update(Guid id, DocumentDto dto);
    }
}
