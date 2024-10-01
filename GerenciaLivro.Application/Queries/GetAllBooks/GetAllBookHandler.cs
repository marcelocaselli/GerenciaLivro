using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using MediatR;

namespace GerenciaLivro.Application.Queries.GetAllBooks
{
    public class GetAllBookHandler : IRequestHandler<GetAllBookQuery, ResultViewModel<List<BookViewModel>>>
    {
        private readonly IBookRepository _repository;
        public GetAllBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAll();

            var model = books.Select(BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(model);
        }
    } 
}

