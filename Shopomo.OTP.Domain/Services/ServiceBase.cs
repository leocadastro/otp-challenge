using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopomo.OTP.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }


        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return _repository.FindAll(match);
        }

        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _repository.FindAllAsync(match);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return _repository.Find(match);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _repository.FindAsync(match);
        }

        public void Commit()
        {
            _repository.Commit();
        }

        public async Task<int> CommitAsync()
        {
            return await _repository.CommitAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
