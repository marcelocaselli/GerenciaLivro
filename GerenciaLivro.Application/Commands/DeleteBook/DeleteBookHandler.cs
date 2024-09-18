using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Commands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly GerenciadorLivroDbContext _context;
        public DeleteBookHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (book == null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
