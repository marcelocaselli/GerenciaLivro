using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;

namespace GerenciaLivro.Application.Services
{
    public interface IBookService
    {
        ResultViewModel<List<BookViewModel>> GetAll(string search = "");
        ResultViewModel<BookViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateBookInputModel model);
        ResultViewModel Update(UpdateBookInputModel model);
        ResultViewModel Delete(int id);
    }
}
