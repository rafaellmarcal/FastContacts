using FastContacts.Data.Context;
using FastContacts.Data.Repository;
using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Common.UnitOfWork;
using FastContacts.Domain.Entities.Addresses.Interfaces;
using FastContacts.Domain.Entities.Addresses.Services;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContacts.Domain.Entities.Documents.Services;
using FastContacts.Domain.Entities.Persons.Legal.Interfaces;
using FastContacts.Domain.Entities.Persons.Legal.Services;
using FastContacts.Domain.Entities.Persons.Natural.Interfaces;
using FastContacts.Domain.Entities.Persons.Natural.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FastContacts.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<FastContactsDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotifier, Notifier>();

            services.AddScoped<IStoreAddressService, StoreAddressService>();
            services.AddScoped<IUpdateAddressService, UpdateAddressService>();

            services.AddScoped<IStoreDocumentService, StoreDocumentService>();
            services.AddScoped<IUpdateDocumentService, UpdateDocumentService>();

            services.AddScoped<IStoreLegalPersonService, StoreLegalPersonService>();
            services.AddScoped<IUpdateLegalPersonService, UpdateLegalPersonService>();
            services.AddScoped<IDeleteLegalPersonService, DeleteLegalPersonService>();

            services.AddScoped<IStoreNaturalPersonService, StoreNaturalPersonService>();
            services.AddScoped<IUpdateNaturalPersonService, UpdateNaturalPersonService>();
            services.AddScoped<IDeleteNaturalPersonService, DeleteNaturalPersonService>();

            services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();
            services.AddScoped<INaturalPersonRepository, NaturalPersonRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();

            return services;
        }
    }
}
