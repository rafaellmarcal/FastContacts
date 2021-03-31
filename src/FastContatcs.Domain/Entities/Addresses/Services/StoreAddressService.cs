using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Entities._Base;
using FastContacts.Domain.Entities.Addresses.Dtos;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContatcs.Domain.Entities.Addresses;

namespace FastContacts.Domain.Entities.Addresses.Services
{
    public class StoreAddressService : DomainService, IStoreAddressService
    {
        public StoreAddressService(INotifier notifier)
            : base(notifier) { }

        public Address Store(AddressDto dto)
        {
            Address address = new Address(dto.ZipCode, dto.Country, dto.State, dto.City, dto.AddressOne, dto.AddressTwo);

            if (!address.Validate())
                NotifyDomainValidations(address.ValidationResult);

            return address;
        }
    }
}
