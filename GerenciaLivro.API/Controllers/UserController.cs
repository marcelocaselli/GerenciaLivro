using GerenciaLivro.Application.Commands.DeleteUser;
using GerenciaLivro.Application.Commands.InsertUser;
using GerenciaLivro.Application.Commands.UpdateUser;
using GerenciaLivro.Application.Queries.GetAllUsers;
using GerenciaLivro.Application.Queries.GetUserById;
using GerenciaLivro.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMediator _mediator;
        public UserController(IUserService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        //GET api/users
        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllUserQuery();
            
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        //GETById api/users/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        //POST api/users
        [HttpPost]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        //PUT api/users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            return NoContent();
        }

        //DELETE api/users/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
