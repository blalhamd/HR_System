

using System;
using System.Linq.Expressions;

namespace ApplicationLayer.GenericInterface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string[] includes=null!);
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> mapping);
        Task<IEnumerable<T>> Paging(Expression<Func<T, bool>> mapping, int skip, int take);
        Task<IEnumerable<T>> Filtering(Expression<Func<T, bool>> mapping, Expression<Func<T, object>> orderBy);
        Task<T> GetById(object id);
        Task<T> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Update(T entity);
        Task Delete(T entity);
        Task Save();


    }
}
