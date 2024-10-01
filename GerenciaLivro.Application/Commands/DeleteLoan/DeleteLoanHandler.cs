using GerenciaLivro.Application.Models;
using GerenciaLivro.Core.Repositories;
using MediatR;

namespace GerenciaLivro.Application.Commands.DeleteLoan
{
    public class DeleteLoanHandler : IRequestHandler<DeleteLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _repository;
        public DeleteLoanHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetDetailsById(request.Id);
            if (loan == null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }

            await _repository.Delete(loan.Id);

            return ResultViewModel.Success();
        }
    }
}

