using GerenciaLivro.Application.Models;
using MediatR;

namespace GerenciaLivro.Application.Queries.GetAllBooks
{
    public class GetAllBookQuery : IRequest<ResultViewModel<List<BookViewModel>>>
    {

    }    
}

