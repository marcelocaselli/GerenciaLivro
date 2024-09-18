using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Commands.DeleteLoan
{
    public class DeleteLoanHandler : IRequestHandler<DeleteLoanCommand, ResultViewModel>
    {
        private readonly GerenciadorLivroDbContext _context;
        public DeleteLoanHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (loan == null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}

