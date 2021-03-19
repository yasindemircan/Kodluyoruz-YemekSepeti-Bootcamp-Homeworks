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
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookModel> AddBook(Book entity)
        {
            var data = await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return data.Entity.BookExtensions();
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(data != null)
                _dbContext.Remove(data);
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public async Task<List<BookModel>> GetBookAsync(string name)
        {
            List<BookModel> result =new List<BookModel>();
            result =await _dbContext.Books.Where(b =>b.Name == name).Select(x => x.BookExtensions()).ToListAsync();
            if(result == null)
                return null;
            return result;
        }

       

        public async Task<List<BookModel>> GetBooksAsync()
        {
            var data = await _dbContext.Books.ToListAsync();
            
            return data.Select(b => b.BookExtensions()).ToList();

            
        }

    }
}
