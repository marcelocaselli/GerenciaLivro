using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;

namespace GerenciaLivro.Application.Services
{
    public interface ILoanService
    {
        ResultViewModel<List<LoanViewModel>> GetAll(string search = "");
        ResultViewModel<LoanViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateLoanInputModel model);
        ResultViewModel Update(UpdateLoanInputModel model);
        ResultViewModel Delete(int id);
    }
}
