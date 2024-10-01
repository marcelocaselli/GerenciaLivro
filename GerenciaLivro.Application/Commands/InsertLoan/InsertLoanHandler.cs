using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;

namespace GerenciaLivro.Application.Commands.InsertLoan
{
    public class InsertLoanHandler : IRequestHandler<InsertLoanCommand, ResultViewModel<int>>
    {
        private readonly ILoanRepository _repository;
        public InsertLoanHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = request.ToEntity();

            await _repository.Add(loan);

            return ResultViewModel<int>.Success(loan.Id);
        }
    }
}
