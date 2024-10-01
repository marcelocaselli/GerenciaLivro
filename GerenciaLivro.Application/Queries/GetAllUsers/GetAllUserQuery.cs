using GerenciaLivro.Application.Models;
using MediatR;

namespace GerenciaLivro.Application.Queries.GetAllUsers
{
    public class GetAllUserQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {

    }
}
