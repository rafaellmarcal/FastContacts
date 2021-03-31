using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Common.UnitOfWork;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContacts.Domain.Entities.Persons.Legal.Interfaces;
using FastContatcs.Domain.Entities.Persons.Legal;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Legal.Services
{
    public class DeleteLegalPersonService : DomainService, IDeleteLegalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressRepository _addressRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly ILegalPersonRepository _legalPersonRepository;

        public DeleteLegalPersonService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            IAddressRepository addressRepository,
            IDocumentRepository documentRepository,
            ILegalPersonRepository legalPersonRepository)
            : base(notifier)
        {
            _unitOfWork = unitOfWork;
            _addressRepository = addressRepository;
            _documentRepository = documentRepository;
            _legalPersonRepository = legalPersonRepository;
        }

        public async Task Delete(Guid id)
        {
            LegalPerson person = await _legalPersonRepository.GetLegalPersonWithAddressAndDocument(id);

            _legalPersonRepository.Delete(person);
            _addressRepository.Delete(person.Address);
            _documentRepository.Delete(person.Document);

            await _unitOfWork.Commit();
        }
    }
}
