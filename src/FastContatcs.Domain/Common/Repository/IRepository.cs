using FastContatcs.Domain.Entities._Base;
using System;
using System.Threading.Tasks;

namespace FastContacts.Domain.Common.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<TEntity> GetById(Guid id);
    }
}
