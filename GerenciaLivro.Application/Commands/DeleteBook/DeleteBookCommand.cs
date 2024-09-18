using GerenciaLivro.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaLivro.Application.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<ResultViewModel>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

