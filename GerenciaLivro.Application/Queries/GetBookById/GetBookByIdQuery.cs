using GerenciaLivro.Application.Models;
using MediatR;

namespace GerenciaLivro.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<ResultViewModel<BookViewModel>>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
