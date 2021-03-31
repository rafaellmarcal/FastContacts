using System.Threading.Tasks;

namespace FastContacts.Domain.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
