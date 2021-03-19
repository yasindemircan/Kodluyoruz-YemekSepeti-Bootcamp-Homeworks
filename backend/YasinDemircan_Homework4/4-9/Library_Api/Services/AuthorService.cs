using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Api.Contexts;
using Library_Api.Entities;
using Library_Api.Extensions;
using Library_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryDbContext _dbContext;

        public AuthorService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthorModel> AddAuthor(Author entity)
        {
            var data = await _dbContext.Authors.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return data.Entity.AuthorExtensions();
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _dbContext.Authors.FirstOrDefaultAsync(b => b.Id == id);
            if(data != null)
                _dbContext.Remove(data);
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public async Task<List<AuthorModel>> GetAuthorAsync(string name)
        {
            List<AuthorModel> result =new List<AuthorModel>();
            result =await _dbContext.Authors.Where(b =>b.Name == name).Select(x => x.AuthorExtensions()).ToListAsync();
            if(result == null)
                return null;
            return result;
        }

       

        public async Task<List<AuthorModel>> GetAuthorsAsync()
        {
            var data = await _dbContext.Authors.ToListAsync();
            
            return data.Select(b => b.AuthorExtensions()).ToList();

            
        }

    }
}
