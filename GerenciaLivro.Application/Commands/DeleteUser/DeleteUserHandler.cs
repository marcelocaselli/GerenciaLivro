using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly GerenciadorLivroDbContext _context;
        public DeleteUserHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}

