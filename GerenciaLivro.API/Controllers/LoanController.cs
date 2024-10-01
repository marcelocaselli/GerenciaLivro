using GerenciaLivro.Application.Commands.DeleteLoan;
using GerenciaLivro.Application.Commands.InsertLoan;
using GerenciaLivro.Application.Commands.UpdateLoan;
using GerenciaLivro.Application.Queries.GetAllLoans;
using GerenciaLivro.Application.Queries.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET api/loans
        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllLoanQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        //GETById api/loans/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetLoanByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //POST api/loans
        [HttpPost]
        public async Task<IActionResult> Post(InsertLoanCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data}, command);
             
        }

        //Update api/loans/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateLoanCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _mediator.Send(new DeleteLoanCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            return NoContent();
        }
    }
}
