using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ResultViewModel<BookViewModel>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public GetBookByIdHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == request.Id);

            var model = BookViewModel.FromEntity(book);

            if (book == null)
            {
                return ResultViewModel<BookViewModel>.Error("Livro não encontrado.");
            }
            return ResultViewModel<BookViewModel>.Success(model);
        }
    }



}
