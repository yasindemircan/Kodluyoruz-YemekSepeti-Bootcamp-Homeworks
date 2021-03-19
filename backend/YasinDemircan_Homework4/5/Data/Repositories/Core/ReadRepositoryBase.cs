using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Core
{
    public class ReadRepositoryBase<T> : RepositoryCore<T>, IReadRepository<T> where T : class, IEntity
    {
        public ReadRepositoryBase():base(new SchoolContext())
        {
            
        }
        public async Task<IQueryable<T>> GetAll()
        {
            IEnumerable<T> result = await _dbSet.ToListAsync();
            return result.AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
           return await _dbSet.FindAsync(expression);
        }
    }
}
