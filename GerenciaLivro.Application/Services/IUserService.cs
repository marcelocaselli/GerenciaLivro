using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;

namespace GerenciaLivro.Application.Services
{
    public interface IUserService
    {
        ResultViewModel<List<UserViewModel>> GetAll(string search = "");
        ResultViewModel<UserViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateUserInputModel model);
        ResultViewModel Update(UpdateUserInputModel model);
        ResultViewModel Delete(int id);
    }
}
