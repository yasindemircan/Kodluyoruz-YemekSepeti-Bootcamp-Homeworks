using System;
using Library_Api.Entities;
using Library_Api.Models;
using Library_Api.Services;

namespace Library_Api.Extensions
{
    public static class mappingExtensions
    {
        public static BookModel BookExtensions(this Book book){
            return new BookModel{
                Id = book.Id,
                Name = book.Name,
                NumberOfPage = book.NumberOfPage
                };
        }
         public static AuthorModel AuthorExtensions(this Author author){
            return new AuthorModel{
                Id = author.Id,
                FullName = string.Concat(author.Name," ",author.LastName),
                BirthDate = author.BirthDate
                };
        }
        
         
    }
}
