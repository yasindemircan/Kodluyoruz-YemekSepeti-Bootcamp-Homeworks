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
    public class RepositoryBase<T> : RepositoryCore<T>, IReadRepository<T>, IWriteRepository<T> 
                                                    where T : class, IEntity
    {
        public RepositoryBase():base(new SchoolContext())
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

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await base.SaveChanges();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
           _dbContext.Attach(entity);
           _dbContext.Entry(entity).State = EntityState.Modified;
           await base.SaveChanges();
           return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _dbSet.FirstOrDefaultAsync(c => c.Id == id);
            if(data != null)
            _dbSet.Remove(data);
        return (await base.SaveChanges()) > 0;
        }
    }
}
