using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Queries.GetLoanById
{
    public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public GetLoanByIdHandler(GerenciadorLivroDbContext context)
        {
            _context = context;   
        }
        public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(x => x.Id == request.Id);
            var model = LoanViewModel.FromEntity(loan);

            if (model == null)
            {
                return ResultViewModel<LoanViewModel>.Error("Empréstimo não existe.");
            }

            return ResultViewModel<LoanViewModel>.Success(model);
        }
    }
}
