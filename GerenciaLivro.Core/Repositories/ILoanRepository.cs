using GerenciadorLivro.Core.Entities;

namespace GerenciaLivro.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAll();
        Task<Loan?> GetDetailsById(int id);
        Task<int> Add(Loan loan);
        Task Update(Loan loan);
        Task Delete(int id);
    }
}
