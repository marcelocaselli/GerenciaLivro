using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Queries.GetAllBooks
{
    public class GetAllBookHandler : IRequestHandler<GetAllBookQuery, ResultViewModel<List<BookViewModel>>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public GetAllBookHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books.ToListAsync();
            var model = books.Select(BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(model);
        }
    } 
}

