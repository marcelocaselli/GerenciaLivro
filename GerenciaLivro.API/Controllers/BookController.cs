using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Services;
using GerenciaLivro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly GerenciadorLivroDbContext _context;
        private readonly IBookService _service;
        public BookController(GerenciadorLivroDbContext context, IBookService service)
        {
            _context = context;
            _service = service;
        }
       
        //GET api/books
        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        //GETById api/books/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //POST api/books
        [HttpPost]
        public IActionResult Post(CreateBookInputModel model)
        {
            var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        //PUT api/books/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBookInputModel model)
        {
            var result = _service.Update(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //DELETE api/books/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
