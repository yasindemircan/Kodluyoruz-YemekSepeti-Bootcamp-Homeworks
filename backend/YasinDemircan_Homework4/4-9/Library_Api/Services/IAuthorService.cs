using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library_Api.Entities;
using Library_Api.Models;

namespace Library_Api.Services
{
    public interface IAuthorService
    {
    Task<List<AuthorModel>> GetAuthorsAsync();
    Task<List<AuthorModel>> GetAuthorAsync(string name);
    Task<AuthorModel> AddAuthor(Author entity);
    Task<bool> Delete (int id);
    }
}
