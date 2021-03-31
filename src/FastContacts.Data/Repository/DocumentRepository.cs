using FastContacts.Data.Context;
using FastContacts.Data.Repository._Base;
using FastContacts.Domain.Entities.Documents.Interfaces;
using FastContatcs.Domain.Entities.Documents;

namespace FastContacts.Data.Repository
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(FastContactsDbContext context)
            : base(context) { }
    }
}
