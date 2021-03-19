
using System.Collections.Generic;
using System.Threading.Tasks;
using Library_Api.Entities;
using Library_Api.Models;

namespace Library_Api.Services
{
    public interface IBookService
    {
    Task<List<BookModel>> GetBooksAsync();
    Task<List<BookModel>> GetBookAsync(string name);
    Task<BookModel> AddBook(Book entity);
    Task<bool> Delete (int id);
    }
}

