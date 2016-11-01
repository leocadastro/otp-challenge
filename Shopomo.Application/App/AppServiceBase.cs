using Shopomo.Application.Interfaces;
using Shopomo.OTP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.Application.App
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
            _serviceBase.Commit();
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _serviceBase.GetByIdAsync(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
            _serviceBase.Commit();
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
            _serviceBase.Commit();
        }

        public async Task<int> AddAsync(TEntity obj)
        {
            _serviceBase.Add(obj);
            return await _serviceBase.CommitAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _serviceBase.GetAllAsync();
        }

        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return _serviceBase.FindAll(match);
        }

        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _serviceBase.FindAllAsync(match);
        }

        public async Task<int> UpdateAsync(TEntity obj)
        {
            _serviceBase.Update(obj);
            return await _serviceBase.CommitAsync();
        }

        public async Task<int> RemoveAsync(TEntity obj)
        {
            _serviceBase.Remove(obj);
            return await _serviceBase.CommitAsync();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return _serviceBase.Find(match);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _serviceBase.FindAsync(match);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
