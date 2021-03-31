using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Documents.Dtos;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContatcs.Domain.Entities.Documents;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Documents.Services
{
    public class UpdateDocumentService : DomainService, IUpdateDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public UpdateDocumentService(
            INotifier notifier,
            IDocumentRepository documentRepository)
            : base(notifier)
        {
            _documentRepository = documentRepository;
        }

        public async Task Update(Guid id, DocumentDto dto)
        {
            Document document = await _documentRepository.GetById(id);

            document.UpdateNumber(dto.Number);

            if (!document.Validate())
                NotifyDomainValidations(document.ValidationResult);

            if (!_notifier.HasNotification())
                _documentRepository.Update(document);
        }
    }
}
