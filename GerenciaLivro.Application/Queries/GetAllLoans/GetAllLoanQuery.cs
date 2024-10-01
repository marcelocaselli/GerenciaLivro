using GerenciaLivro.Application.Models;
using MediatR;

namespace GerenciaLivro.Application.Queries.GetAllLoans
{
    public class GetAllLoanQuery : IRequest<ResultViewModel<List<LoanViewModel>>>
    {

    }
}
