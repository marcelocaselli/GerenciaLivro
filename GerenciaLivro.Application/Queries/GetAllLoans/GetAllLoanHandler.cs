using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Queries.GetAllLoans
{
    public class GetAllLoanHandler : IRequestHandler<GetAllLoanQuery, ResultViewModel<List<LoanViewModel>>>
    {
        private readonly ILoanRepository _repository;
        public GetAllLoanHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
        {
            var loans = await _repository.GetAll();
               
            var model = loans.Select(LoanViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanViewModel>>.Success(model);
        }
    }
}
