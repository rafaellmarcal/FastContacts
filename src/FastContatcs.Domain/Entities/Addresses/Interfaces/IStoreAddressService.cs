using FastContacts.Domain.Entities.Addresses.Dtos;
using FastContatcs.Domain.Entities.Addresses;

namespace FastContacts.Domain.Entities.Addresses.Interfaces
{
    public interface IStoreAddressService
    {
        Address Store(AddressDto dto);
    }
}
