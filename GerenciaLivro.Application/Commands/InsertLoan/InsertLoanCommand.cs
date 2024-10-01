using GerenciadorLivro.Core.Entities;
using GerenciaLivro.Application.Models;
using MediatR;

namespace GerenciaLivro.Application.Commands.InsertLoan
{
    public class InsertLoanCommand : IRequest<ResultViewModel<int>>
    {
        public int IdBook { get; set; }
        public int IdUser { get; set; }
        public DateTime LoanDate { get; set; }

        public Loan ToEntity()
            => new(IdBook, IdUser, LoanDate);
    }
}


