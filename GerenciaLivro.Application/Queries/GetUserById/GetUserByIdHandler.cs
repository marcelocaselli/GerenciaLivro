using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public GetUserByIdHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Id);
            var model = UserViewModel.FromEntity(user);

            if (model == null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuário não encontrado.");
            }

            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}
