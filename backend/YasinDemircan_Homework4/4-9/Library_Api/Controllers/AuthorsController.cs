using System;
using System.Threading.Tasks;
using Library_Api.Entities;
using Library_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAuthorsAsync();
            if (authors == null)
                return NoContent();
            return Ok(authors);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAuthor(string name)
        {
            var author = await _authorService.GetAuthorAsync(name);
            if (author == null)
                return NoContent();
            return Ok(author);
        }
        [HttpPost]
        [ProducesResponseType(200)]

        public async Task<ActionResult> Post([FromBody] Author author)
        {
            var newAuthor = await _authorService.AddAuthor(author);
            return Ok(newAuthor.FullName + " Added");
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]

        public async Task<ActionResult> Delete(int id)
        {
            await _authorService.Delete(id);
            return Ok(id + "Silindi");
        }

    }
}
