using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Commands.UpdateLoan
{
    public class UpdateLoanHandler : IRequestHandler<UpdateLoanCommand, ResultViewModel>
    {
        private readonly GerenciadorLivroDbContext _context;
        public UpdateLoanHandler(GerenciadorLivroDbContext context)
        {
            _context = context;            
        }
        public async Task<ResultViewModel> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(x => x.Id == request.IdLoan);

            if (loan is null)
            {
                return ResultViewModel.Error("Empréstimo não existe.");
            }

            loan.Update(request.IdUser, request.IdBook, request.ReturnDate);
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
