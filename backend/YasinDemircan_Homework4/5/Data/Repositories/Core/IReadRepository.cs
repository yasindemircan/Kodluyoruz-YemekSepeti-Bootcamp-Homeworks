using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interface;

namespace Data.Repositories.Core
{
    public interface IReadRepository<T> where T : IEntity 
    {
        Task<T> GetById(int id);
       // Task<T> Get(Expression<Func<T,bool>> expression);
        Task<IQueryable<T>> GetAll();
    }
}
