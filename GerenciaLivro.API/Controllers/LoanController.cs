using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Application.Services;
using GerenciaLivro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoanController : ControllerBase
    {
        private readonly GerenciadorLivroDbContext _context;
        private readonly ILoanService _service;
        public LoanController(GerenciadorLivroDbContext context, ILoanService service)
        {
            _context = context;
            _service = service;
        }

        //GET api/loans
        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        //GETById api/loans/id
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

        //POST api/loans
        [HttpPost]
        public IActionResult Post(CreateLoanInputModel model)
        {
            var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data}, model);
             
        }

        //Update api/loans/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateLoanInputModel model)
        {
            var result = _service.Update(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

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
