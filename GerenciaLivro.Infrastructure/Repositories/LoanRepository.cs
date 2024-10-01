using GerenciadorLivro.Core.Entities;
using GerenciaLivro.Core.Repositories;
using GerenciaLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly GerenciadorLivroDbContext _context;
        public LoanRepository(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            return loan.Id;
        }

        public async Task Delete(int id)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(x => x.Id == id);

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAll()
        {
            var loans = await _context.Loans.ToListAsync();

            return loans;
        }

        public async Task<Loan?> GetDetailsById(int id)
        {
            return await _context.Loans.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}
