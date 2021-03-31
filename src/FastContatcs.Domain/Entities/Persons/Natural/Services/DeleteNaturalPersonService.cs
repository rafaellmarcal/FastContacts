using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Common.UnitOfWork;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContacts.Domain.Entities.Persons.Natural.Interfaces;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Persons.Natural.Services
{
    public class DeleteNaturalPersonService : DomainService, IDeleteNaturalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressRepository _addressRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly INaturalPersonRepository _naturalPersonRepository;

        public DeleteNaturalPersonService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            IAddressRepository addressRepository,
            IDocumentRepository documentRepository,
            INaturalPersonRepository naturalPersonRepository)
            : base(notifier)
        {
            _unitOfWork = unitOfWork;
            _addressRepository = addressRepository;
            _documentRepository = documentRepository;
            _naturalPersonRepository = naturalPersonRepository;
        }

        public async Task Delete(Guid id)
        {
            NaturalPerson person = await _naturalPersonRepository.GetNaturalPersonWithAddressAndDocument(id);

            _naturalPersonRepository.Delete(person);
            _addressRepository.Delete(person.Address);
            _documentRepository.Delete(person.Document);

            await _unitOfWork.Commit();
        }
    }
}
