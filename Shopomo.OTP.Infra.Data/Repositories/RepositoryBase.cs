using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopomo.OTP.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ShopomoContext _dbContext;

        public RepositoryBase(ShopomoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity obj)
        {
            _dbContext.Set<TEntity>().Add(obj);
        }

        private static readonly object CacheLockObject = new object();

        public ICollection<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return _dbContext.Set<TEntity>().Where(match).ToList();
        }

        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().Where(match).ToListAsync();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return _dbContext.Set<TEntity>().Where(match).FirstOrDefault();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().Where(match).FirstOrDefaultAsync();
        }

        public void Remove(TEntity obj)
        {
            if (_dbContext.Entry(obj).State == EntityState.Detached)
                _dbContext.Set<TEntity>().Attach(obj);

            _dbContext.Set<TEntity>().Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _dbContext.Set<TEntity>().AddOrUpdate(obj);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
