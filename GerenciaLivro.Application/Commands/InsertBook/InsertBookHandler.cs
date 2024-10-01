using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using MediatR;

namespace GerenciaLivro.Application.Commands.InsertBook
{
    public class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
    {
        private readonly IBookRepository _repository;
        public InsertBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();

            await _repository.Add(book); 

            return ResultViewModel<int>.Success(book.Id);
        }
    }
}
