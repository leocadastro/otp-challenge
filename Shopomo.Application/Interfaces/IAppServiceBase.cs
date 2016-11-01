using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task<int> AddAsync(TEntity obj);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<ICollection<TEntity>> GetAllAsync();
        ICollection<TEntity> GetAll();


        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
        TEntity Find(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        void Update(TEntity obj);
        Task<int> UpdateAsync(TEntity obj);
        void Remove(TEntity obj);
        Task<int> RemoveAsync(TEntity obj);

        void Dispose();
    }
}
