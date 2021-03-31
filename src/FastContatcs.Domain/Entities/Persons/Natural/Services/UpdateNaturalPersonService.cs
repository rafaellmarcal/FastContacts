using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Common.UnitOfWork;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContacts.Domain.Entities.Persons.Natural.Dtos;
using FastContacts.Domain.Entities.Persons.Natural.Interfaces;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Natural.Services
{
    public class UpdateNaturalPersonService : DomainService, IUpdateNaturalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUpdateAddressService _updateAddressService;
        private readonly IUpdateDocumentService _updateDocumentService;
        private readonly INaturalPersonRepository _naturalPersonRepository;

        public UpdateNaturalPersonService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            IUpdateAddressService updateAddressService,
            IUpdateDocumentService updateDocumentService,
            INaturalPersonRepository naturalPersonRepository)
            : base(notifier)
        {
            _unitOfWork = unitOfWork;
            _updateAddressService = updateAddressService;
            _updateDocumentService = updateDocumentService;
            _naturalPersonRepository = naturalPersonRepository;
        }

        public async Task Update(NaturalPersonDto dto)
        {
            NaturalPerson person = new NaturalPerson(dto.Name, dto.Birthday, dto.Gender);

            UpdateNaturalPerson(dto, person);

            await _updateAddressService.Update(person.AddressId, dto.Address);

            await _updateDocumentService.Update(person.DocumentId, dto.Document);

            if (!person.Validate())
                NotifyDomainValidations(person.ValidationResult);

            if (!_notifier.HasNotification())
            {
                _naturalPersonRepository.Update(person);
                await _unitOfWork.Commit();
            }
        }

        private void UpdateNaturalPerson(NaturalPersonDto dto, NaturalPerson person)
        {
            person.UpdateName(dto.Name);
            person.UpdateGender(dto.Gender);
            person.UpdateBirthday(dto.Birthday);
        }
    }
}
