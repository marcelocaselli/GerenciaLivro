using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using MediatR;

namespace GerenciaLivro.Application.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _repository;
        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetDetailsById(request.IdBook);

            if (book is null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }

            book.Update(request.Title, request.Author, request.Isbn, request.YearOfPublication);

            await _repository.UpDate(book);

            return ResultViewModel.Success();
        }
    }
}
