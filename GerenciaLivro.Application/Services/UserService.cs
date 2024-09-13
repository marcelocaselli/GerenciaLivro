using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;

namespace GerenciaLivro.Application.Services
{
    public class UserService : IUserService
    {
        private readonly GerenciadorLivroDbContext _context;
        public UserService(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
       
        public ResultViewModel<List<UserViewModel>> GetAll(string search = "")
        {
            var users = _context.Users.ToList();
            var model = users.Select(UserViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(model);
        }

        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            var model = UserViewModel.FromEntity(user);

            if (model == null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuário não encontrado.");
            }

            return ResultViewModel<UserViewModel>.Success(model); 
                
        }

        public ResultViewModel<int> Insert(CreateUserInputModel model)
        {
            var user = model.ToEntity();
            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(user.Id);
        }

        public ResultViewModel Update(UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == model.IdUser);

            if (user is null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }

            user.Update(model.Name, model.Email, model.BirthDate);
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
