using GerenciaLivro.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaLivro.Application.Commands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<ResultViewModel>
    {
        public int IdLoan { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
