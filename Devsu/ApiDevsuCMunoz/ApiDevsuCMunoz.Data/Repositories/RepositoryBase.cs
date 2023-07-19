using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Domain;
using ApiDevsuCMunoz.Domain.Common;
using ApiDevsuCMunoz.Infrestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace ApiDevsuCMunoz.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly ApiDevsuCMunozDbContext _context;

        public RepositoryBase(ApiDevsuCMunozDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, 
                                                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
                                                List<Expression<Func<T, object>>>? includes = null, 
                                                bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if(disableTracking) query = query.AsNoTracking();
            if(includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if(predicate != null) query = query.Where(predicate);
            if(orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {   
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual IQueryable<T> GetAsyncQueryable
        {
            get { return _context.Set<T>().AsQueryable(); }
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public List<T> Get(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null)
                query = query.Where(predicate);

            return query.ToList();
        }

        public List<T> GetOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeString = null, bool disableTracking = true, int? takeRecords = null)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
            if (predicate != null)
                query = query.Where(predicate);

            if (takeRecords != null)
                query = query.Take((int)takeRecords);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();


            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsyncObjectInclude(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
        #pragma warning disable CS8603 // Possible null reference return.
            return await _context.Set<T>().FindAsync(id);
        #pragma warning restore CS8603 // Possible null reference return.
        }

        

    }
}
