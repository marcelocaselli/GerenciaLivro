using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Queries.GetAllLoans
{
    public class GetAllLoanHandler : IRequestHandler<GetAllLoanQuery, ResultViewModel<List<LoanViewModel>>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public GetAllLoanHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
        {
            var loans = await _context.Loans
               .Include(x => x.Book)
               .Include(x => x.User)
               .ToListAsync();

            var model = loans.Select(LoanViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanViewModel>>.Success(model);
        }
    }
}
