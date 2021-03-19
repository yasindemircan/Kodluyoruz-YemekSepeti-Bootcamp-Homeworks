using System;
using System.Threading.Tasks;
using Data.Repositories.Core;
using Domain.Entities;

namespace Data.Repositories.Interface
{
    public interface IStudentRepository: IReadRepository<Student>, IWriteRepository<Student>
    {
        Task<bool> CheckAllReadExits(string name);
        
    }
}
