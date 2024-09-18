using GerenciadorLivro.Core.Entities;
using GerenciaLivro.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaLivro.Application.Commands.InsertBook
{
    public class InsertBookCommand : IRequest<ResultViewModel<int>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime YearOfPublication { get; set; }

        public Book ToEntity()
            => new(Title, Author, Isbn, YearOfPublication);
    }
}
