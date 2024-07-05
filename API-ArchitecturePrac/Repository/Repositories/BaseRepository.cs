using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entites;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _entites = context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _entites.AddAsync(entity);    
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _entites.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entites.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entites.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(T entity)
        {
            _entites.Update(entity);
            await _context.SaveChangesAsync();
        }


        public IQueryable<T> FindBy(Expression<Func<T,bool>> predicate,params Expression<Func<T, object>>[] includes)
        {
            var query = _entites.Where(predicate);
            return includes.Aggregate(query,(current,includeProperty) => current.Include(includeProperty));
        }


        public IQueryable<T> FindAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            var query = _entites.AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
