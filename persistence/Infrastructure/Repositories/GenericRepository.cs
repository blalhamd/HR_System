

using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;
using System.Linq.Expressions;

namespace persistence.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll(string[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query= query.Include(item);
                }
            }
            return await query.ToListAsync();
            //return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await Save();

            return entity;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task<IEnumerable<T>> Filtering(Expression<Func<T, bool>> mapping, Expression<Func<T, object>> orderBy)
        {
            var query= await _context.Set<T>().Where(mapping).OrderBy(orderBy).ToListAsync();

            return query;
        }


        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> mapping)
        {
            var query= await _context.Set<T>().Where(mapping).ToListAsync();

            return query;
        }

        public async Task<IEnumerable<T>> Paging(Expression<Func<T, bool>> mapping, int skip, int take)
        {
            var query = await _context.Set<T>().Where(mapping).Skip(skip).Take(take).ToListAsync();

            return query;

        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Save();
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }

      
    }
}
