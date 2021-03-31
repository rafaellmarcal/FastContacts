using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Addresses.Dtos;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContatcs.Domain.Entities.Addresses;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Addresses.Services
{
    public class UpdateAddressService : DomainService, IUpdateAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressService(
            INotifier notifier,
            IAddressRepository addressRepository)
            : base(notifier)
        {
            _addressRepository = addressRepository;
        }

        public async Task Update(Guid id, AddressDto dto)
        {
            Address address = await _addressRepository.GetById(id);

            UpdateAddress(dto, address);

            if (!address.Validate())
                NotifyDomainValidations(address.ValidationResult);

            if (!_notifier.HasNotification())
                _addressRepository.Update(address);
        }

        private void UpdateAddress(AddressDto dto, Address address)
        {
            address.UpdateZipCode(dto.ZipCode);
            address.UpdateAddressOne(dto.AddressOne);
            address.UpdateAddressTwo(dto.AddressTwo);
            address.UpdateCity(dto.City);
            address.UpdateState(dto.State);
            address.UpdateCountry(dto.Country);
        }
    }
}
