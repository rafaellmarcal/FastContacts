using AutoMapper;
using FastContacts.Domain.Entities.Addresses.Dtos;
using FastContacts.Domain.Entities.Documents.Dtos;
using FastContacts.Domain.Entities.Persons.Legal.Dtos;
using FastContacts.Domain.Entities.Persons.Natural;
using FastContacts.Domain.Entities.Persons.Natural.Dtos;
using FastContatcs.Domain.Entities.Addresses;
using FastContatcs.Domain.Entities.Documents;
using FastContatcs.Domain.Entities.Persons.Legal;

namespace FastContacts.Api.Configuration
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Document, DocumentDto>();
            CreateMap<Address, AddressDto>();

            CreateMap<LegalPerson, LegalPersonDto>();
            CreateMap<NaturalPerson, NaturalPersonDto>();
        }
    }
}
