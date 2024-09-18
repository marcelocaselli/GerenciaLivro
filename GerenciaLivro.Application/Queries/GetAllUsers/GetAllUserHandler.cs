using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Queries.GetAllUsers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ResultViewModel<List<UserViewModel>>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public GetAllUserHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync();
            var model = users.Select(UserViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(model);
        }
    }
}
