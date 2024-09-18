using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly GerenciadorLivroDbContext _context;
        public UpdateUserHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.IdUser);

            if (user is null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }

            user.Update(request.Name, request.Email, request.BirthDate);
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
