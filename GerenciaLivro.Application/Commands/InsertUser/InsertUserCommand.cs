using GerenciadorLivro.Core.Entities;
using GerenciaLivro.Application.Models;
using MediatR;

namespace GerenciaLivro.Application.Commands.InsertUser
{
    public class InsertUserCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public User ToEntity()
            => new(Name, Email, BirthDate);
    }
}
