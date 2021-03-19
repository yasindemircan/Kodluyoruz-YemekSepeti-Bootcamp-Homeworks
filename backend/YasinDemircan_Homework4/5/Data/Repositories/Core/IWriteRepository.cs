using System;
using System.Threading.Tasks;
using Domain.Interface;

namespace Data.Repositories.Core
{
    public interface IWriteRepository<T> where T : IEntity
    {
        Task<T> Add(T entity);

        Task<T> Update(T entity);
        Task<bool> Delete (int id);
    }
}
