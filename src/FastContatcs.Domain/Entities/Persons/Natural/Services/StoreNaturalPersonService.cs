using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Common.UnitOfWork;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContacts.Domain.Entities.Persons.Natural.Dtos;
using FastContacts.Domain.Entities.Persons.Natural.Interfaces;
using FastContatcs.Domain.Entities.Addresses;
using FastContatcs.Domain.Entities.Documents;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Natural.Services
{
    public class StoreNaturalPersonService : DomainService, IStoreNaturalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoreAddressService _storeAddressService;
        private readonly IStoreDocumentService _storeDocumentService;
        private readonly INaturalPersonRepository _naturalPersonRepository;

        public StoreNaturalPersonService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            IStoreAddressService storeAddressService,
            IStoreDocumentService storeDocumentService,
            INaturalPersonRepository naturalPersonRepository)
            : base(notifier)
        {
            _unitOfWork = unitOfWork;
            _storeAddressService = storeAddressService;
            _storeDocumentService = storeDocumentService;
            _naturalPersonRepository = naturalPersonRepository;
        }

        public async Task Store(NaturalPersonDto dto)
        {
            NaturalPerson person = new NaturalPerson(dto.Name, dto.Birthday, dto.Gender);

            StoreAddress(dto, person);
            StoreDocument(dto, person);

            if (!person.Validate())
                NotifyDomainValidations(person.ValidationResult);

            if (!_notifier.HasNotification())
            {
                _naturalPersonRepository.Add(person);
                await _unitOfWork.Commit();
            }
        }

        private void StoreAddress(NaturalPersonDto dto, NaturalPerson person)
        {
            Address address = _storeAddressService.Store(dto.Address);
            person.AssignAddress(address);
        }

        private void StoreDocument(NaturalPersonDto dto, NaturalPerson person)
        {
            Document document = _storeDocumentService.Store(dto.Document);
            person.AssignDocument(document);
        }
    }
}
