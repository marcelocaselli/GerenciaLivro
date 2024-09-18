using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
    {
        private readonly GerenciadorLivroDbContext _context;
        public UpdateBookHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == request.IdBook);

            if (book is null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }

            book.Update(request.Title, request.Author, request.Isbn, request.YearOfPublication);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
