using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using MediatR;

namespace GerenciaLivro.Application.Queries.GetLoanById
{
    public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
    {
        private readonly ILoanRepository _repository;
        public GetLoanByIdHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetDetailsById(request.Id);
            var model = LoanViewModel.FromEntity(loan);

            if (model == null)
            {
                return ResultViewModel<LoanViewModel>.Error("Empréstimo não existe.");
            }

            return ResultViewModel<LoanViewModel>.Success(model);
        }
    }
}
