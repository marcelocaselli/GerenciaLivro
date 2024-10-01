using GerenciaLivro.Application.Models;
using MediatR;

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

