using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Common.UnitOfWork;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContacts.Domain.Entities.Persons.Legal.Dtos;
using FastContacts.Domain.Entities.Persons.Legal.Interfaces;
using FastContatcs.Domain.Entities.Addresses;
using FastContatcs.Domain.Entities.Documents;
using FastContatcs.Domain.Entities.Persons.Legal;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Legal.Services
{
    public class StoreLegalPersonService : DomainService, IStoreLegalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoreAddressService _storeAddressService;
        private readonly IStoreDocumentService _storeDocumentService;
        private readonly ILegalPersonRepository _legalPersonRepository;

        public StoreLegalPersonService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            IStoreAddressService storeAddressService,
            IStoreDocumentService storeDocumentService,
            ILegalPersonRepository legalPersonRepository)
            : base(notifier)
        {
            _unitOfWork = unitOfWork;
            _storeAddressService = storeAddressService;
            _storeDocumentService = storeDocumentService;
            _legalPersonRepository = legalPersonRepository;
        }

        public async Task Store(LegalPersonDto dto)
        {
            LegalPerson person = new LegalPerson(dto.CompanyName, dto.TradeName);

            StoreAddress(dto, person);
            StoreDocument(dto, person);

            if (!person.Validate())
                NotifyDomainValidations(person.ValidationResult);

            if (!_notifier.HasNotification())
            {
                _legalPersonRepository.Add(person);
                await _unitOfWork.Commit();
            }
        }

        private void StoreAddress(LegalPersonDto dto, LegalPerson person)
        {
            Address address = _storeAddressService.Store(dto.Address);
            person.AssignAddress(address);
        }

        private void StoreDocument(LegalPersonDto dto, LegalPerson person)
        {
            Document document = _storeDocumentService.Store(dto.Document);
            person.AssignDocument(document);
        }
    }
}
