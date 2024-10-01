using GerenciadorLivro.Core.Entities;

namespace GerenciaLivro.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book?> GetDetailsById(int id);
        Task<int> Add(Book book);
        Task UpDate(Book book);    
        Task Delete(int id);
    }
}
