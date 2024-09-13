using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Services;
using GerenciaLivro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly GerenciadorLivroDbContext _context;
        private readonly IUserService _service;
        public UserController(GerenciadorLivroDbContext context, IUserService service)
        {
            _context = context;
            _service = service;
        }

        //GET api/users
        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        //GETById api/users/id
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

        //POST api/users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        //PUT api/users/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserInputModel model)
        {
            var result = _service.Update(model);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            return NoContent();
        }

        //DELETE api/users/id
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
