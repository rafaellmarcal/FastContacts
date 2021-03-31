using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Common.UnitOfWork;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContacts.Domain.Entities.Persons.Legal.Dtos;
using FastContacts.Domain.Entities.Persons.Legal.Interfaces;
using FastContatcs.Domain.Entities.Persons.Legal;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Legal.Services
{
    public class UpdateLegalPersonService : DomainService, IUpdateLegalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUpdateAddressService _updateAddressService;
        private readonly IUpdateDocumentService _updateDocumentService;
        private readonly ILegalPersonRepository _legalPersonRepository;

        public UpdateLegalPersonService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            IUpdateAddressService updateAddressService,
            IUpdateDocumentService updateDocumentService,
            ILegalPersonRepository legalPersonRepository)
            : base(notifier)
        {
            _unitOfWork = unitOfWork;
            _updateAddressService = updateAddressService;
            _updateDocumentService = updateDocumentService;
            _legalPersonRepository = legalPersonRepository;
        }

        public async Task Update(LegalPersonDto dto)
        {
            LegalPerson person = await _legalPersonRepository.GetById(dto.Id);

            UpdateLegalPerson(dto, person);

            await _updateAddressService.Update(person.AddressId, dto.Address);

            await _updateDocumentService.Update(person.DocumentId, dto.Document);

            if (!person.Validate())
                NotifyDomainValidations(person.ValidationResult);

            if (!_notifier.HasNotification())
            {
                _legalPersonRepository.Update(person);
                await _unitOfWork.Commit();
            }
        }

        private void UpdateLegalPerson(LegalPersonDto dto, LegalPerson person)
        {
            person.UpdateCompanyName(dto.CompanyName);
            person.UpdateTradeName(dto.TradeName);
        }
    }
}
