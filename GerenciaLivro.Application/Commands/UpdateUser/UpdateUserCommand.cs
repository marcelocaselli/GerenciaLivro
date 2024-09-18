using GerenciaLivro.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaLivro.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
