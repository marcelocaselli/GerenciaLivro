using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;

namespace GerenciaLivro.Application.Commands.InsertLoan
{
    public class InsertLoanHandler : IRequestHandler<InsertLoanCommand, ResultViewModel<int>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public InsertLoanHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = request.ToEntity();
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(loan.Id);
        }
    }
}
