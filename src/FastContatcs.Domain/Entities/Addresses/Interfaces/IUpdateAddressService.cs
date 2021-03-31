using FastContacts.Domain.Entities.Addresses.Dtos;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Entities.Addresses.Interfaces
{
    public interface IUpdateAddressService
    {
        Task Update(Guid id, AddressDto dto);
    }
}
