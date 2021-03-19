using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Core
{
    public abstract class RepositoryCore<T> where T : class, IEntity
    {
        protected readonly DbContext _dbContext = null;
        protected readonly DbSet<T> _dbSet = null;

        public RepositoryCore(SchoolContext dbContex)
        {
            _dbContext = dbContex;
            _dbSet = dbContex.Set<T>();
        }
        protected virtual List<T> ExectSqlQuery<T> (string query, Func<DbDataReader,T> map){
            using var command = _dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText=query;
            command.CommandType = System.Data.CommandType.Text;

            if(command.Connection.State != System.Data.ConnectionState.Open)
                command.Connection.Open();
            
            var entities = new List<T>();
            using var result = command.ExecuteReader();
            while(result.Read()){
                entities.Add(map(result));
            }
            return entities;
        }
        public async virtual Task<int> SaveChanges(){
          int SaveChangeResult = 0;
          try
          {
              //
              SaveChangeResult = await _dbContext.SaveChangesAsync();
          }
          catch (Exception ex)
          {
              throw ex;
          } 
          return SaveChangeResult; 
        }
    }
}
