using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly GerenciadorLivroDbContext _context;
        public LoanService(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public ResultViewModel<List<LoanViewModel>> GetAll(string search = "")
        {
            var loans = _context.Loans
               .Include(x => x.Book)
               .Include(x => x.User)
               .ToList();

            var model = loans.Select(LoanViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanViewModel>>.Success(model);
        }

        public ResultViewModel<LoanViewModel> GetById(int id)
        {
            var loan = _context.Loans.SingleOrDefault(x => x.Id == id);
            var model = LoanViewModel.FromEntity(loan);

            if(model == null)
            {
                return ResultViewModel<LoanViewModel>.Error("Empréstimo não existe.");
            }

            return ResultViewModel<LoanViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateLoanInputModel model)
        {
            var loan = model.ToEntity();
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(loan.Id);
        }

        public ResultViewModel Update(UpdateLoanInputModel model)
        {
            var loan = _context.Loans.SingleOrDefault(x => x.Id == model.IdLoan);

            if (loan is null)
            {
                return ResultViewModel.Error("Empréstimo não existe.");
            }

            loan.Update(model.IdUser, model.IdBook, model.ReturnDate);
            _context.Loans.Update(loan);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var loan = _context.Loans.SingleOrDefault(x => x.Id == id);

            if(loan is null)
            {
                return ResultViewModel.Error("Empréstim não localizado.");
            }

            _context.Loans.Remove(loan);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
