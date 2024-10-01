using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaLivro.Application.Commands.UpdateLoan
{
    public class UpdateLoanHandler : IRequestHandler<UpdateLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _repository;
        public UpdateLoanHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetDetailsById(request.IdLoan);

            if (loan is null)
            {
                return ResultViewModel.Error("Empréstimo não existe.");
            }

            loan.Update(request.IdUser, request.IdBook);

            await _repository.Update(loan);

            return ResultViewModel.Success();
        }
    }
}
