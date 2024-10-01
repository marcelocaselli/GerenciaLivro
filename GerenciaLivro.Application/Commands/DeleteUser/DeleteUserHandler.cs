using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public DeleteUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetDetailsById(request.Id);
            if (user == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }
            
            await _repository.Delete(user.Id);

            return ResultViewModel.Success();
        }
    }
}

