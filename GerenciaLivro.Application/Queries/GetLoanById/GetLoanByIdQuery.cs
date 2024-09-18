﻿using GerenciadorLivro.Application.Models;
using GerenciaLivro.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
