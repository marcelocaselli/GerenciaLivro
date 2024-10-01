using GerenciadorLivro.Core.Entities;
using GerenciaLivro.Core.Repositories;
using GerenciaLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly GerenciadorLivroDbContext _context;
        public BookRepository(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task Delete(int id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAll()
        {
            var books = await _context.Books.ToListAsync();

            return books;
        }

        public async Task<Book?> GetDetailsById(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(x => x.Id == id);            
        }

        public async Task UpDate(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
