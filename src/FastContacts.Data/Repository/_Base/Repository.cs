using FastContacts.Data.Context;
using FastContacts.Domain.Common.Repository;
using FastContatcs.Domain.Entities._Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FastContacts.Data.Repository._Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly FastContactsDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(FastContactsDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
