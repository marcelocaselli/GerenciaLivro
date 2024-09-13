using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;

namespace GerenciaLivro.Application.Services
{
    public class BookService : IBookService
    {
        private readonly GerenciadorLivroDbContext _context;
        public BookService(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public ResultViewModel<List<BookViewModel>> GetAll(string search = "")
        {
            var books = _context.Books.ToList();
            var model = books.Select(BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(model);
        }

        public ResultViewModel<BookViewModel> GetById(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            var model = BookViewModel.FromEntity(book);

            if (book == null)
            {
                return ResultViewModel<BookViewModel>.Error("Livro não encontrado.");
            }
            return ResultViewModel<BookViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateBookInputModel model)
        {
            var book = model.ToEntity();
            _context.Books.Add(book);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(book.Id);
        }

        public ResultViewModel Update(UpdateBookInputModel model)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == model.IdBook);

            if (book is null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }

            book.Update(model.Title, model.Author, model.Isbn, model.YearOfPublication);
            _context.Books.Update(book);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

    }
}
