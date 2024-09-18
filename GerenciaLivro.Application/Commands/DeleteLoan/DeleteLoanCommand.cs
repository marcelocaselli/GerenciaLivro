using GerenciaLivro.Application.Models;
using MediatR;

namespace GerenciaLivro.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<ResultViewModel>
    {
        public DeleteLoanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

