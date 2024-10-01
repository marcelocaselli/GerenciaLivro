using GerenciaLivro.Application.Models;
using MediatR;

namespace GerenciaLivro.Application.Queries.GetLoanById
{
    public class GetLoanByIdQuery : IRequest<ResultViewModel<LoanViewModel>>
    {
        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
