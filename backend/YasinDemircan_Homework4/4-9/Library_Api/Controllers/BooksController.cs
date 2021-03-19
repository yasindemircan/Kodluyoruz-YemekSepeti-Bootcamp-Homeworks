using System;
using System.Threading.Tasks;
using Library_Api.Entities;
using Library_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BooksController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
         [HttpGet]
        [ProducesResponseType(200)]
         [ProducesResponseType(204)]
        public async Task <IActionResult> GetBooks(){
           var books = await _bookService.GetBooksAsync();
           if(books == null)
            return NoContent();
        return Ok(books); 
        }
         [HttpGet("{name}")]
          [ProducesResponseType(200)]
         [ProducesResponseType(204)]
        public async Task <IActionResult> GetBook(string name){
            var book = await _bookService.GetBookAsync(name);
            if(book == null)
                return NoContent();
            return Ok(book);
        }
        [HttpPost]
        [ProducesResponseType(200)]
            public async Task <ActionResult> Post([FromBody] Book book)
            {
                var newBook = await _bookService.AddBook(book);
                return Ok(newBook.Name+" Added");
            }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        
            public async Task <ActionResult> Delete(int id)
            {
                await _bookService.Delete(id);
                return Ok(id +"Silindi");
            }

    }
}
