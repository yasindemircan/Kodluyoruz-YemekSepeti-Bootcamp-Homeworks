using System;
using System.Threading.Tasks;
using Data.Repositories.Core;
using Domain.Entities;

namespace Data.Repositories.Interface
{
    public interface ITeacherRepository: IReadRepository<Teacher>, IWriteRepository<Teacher>
    {
        Task<bool> CheckAllReadExits(string name);
        
    }
}
