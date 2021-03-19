using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories.Core;
using Data.Repositories.Interface;
using Domain.Entities;

namespace Data.Repositories.Derived
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public async Task<bool> CheckAllReadExits(string name)
        {
            var sql = $"Select Count(*) as TotalCount From Students where Name = '{name}'";
            var result = await base.ExectSqlQuery(sql, async _ => {
                int totalCount = 0;
                if(await _.ReadAsync())
                    totalCount = _.GetInt32(_.GetOrdinal("TotalCount"));

                return totalCount > 0 ;

            })?.FirstOrDefault();
            return result;
        }
    }
}
