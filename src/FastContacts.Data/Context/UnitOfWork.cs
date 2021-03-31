using System;
using System.Threading.Tasks;
using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Common.UnitOfWork;

namespace FastContacts.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly INotifier _notifier;
        private FastContactsDbContext _context;

        public UnitOfWork(
            INotifier notifier,
            FastContactsDbContext context)
        {
            _context = context;
            _notifier = notifier;
        }

        public async Task<bool> Commit()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _notifier.Handle(new Notification(string.Format("Sorry, we couldn't perform the action. {0}", ex.Message)));
                return false;
            }
        }
    }
}
