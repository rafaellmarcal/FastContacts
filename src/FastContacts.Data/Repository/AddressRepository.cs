using FastContacts.Data.Context;
using FastContacts.Data.Repository._Base;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContatcs.Domain.Entities.Addresses;

namespace FastContacts.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(FastContactsDbContext context)
            : base(context) { }
    }
}
