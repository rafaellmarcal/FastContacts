using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Documents.Dtos;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContatcs.Domain.Entities.Documents;

namespace FastContacts.Domain.Entities.Documents.Services
{
    public class StoreDocumentService : DomainService, IStoreDocumentService
    {
        public StoreDocumentService(INotifier notifier)
            : base(notifier) { }

        public Document Store(DocumentDto dto)
        {
            Document document = new Document(dto.Type, dto.Number);

            if (!document.Validate())
                NotifyDomainValidations(document.ValidationResult);

            return document;
        }
    }
}
