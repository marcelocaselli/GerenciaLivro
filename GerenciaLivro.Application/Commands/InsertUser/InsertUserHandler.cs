using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;

namespace GerenciaLivro.Application.Commands.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public InsertUserHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
