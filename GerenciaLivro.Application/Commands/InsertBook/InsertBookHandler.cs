using GerenciaLivro.Application.Models;
using GerenciaLivro.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaLivro.Application.Commands.InsertBook
{
    public class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
    {
        private readonly GerenciadorLivroDbContext _context;
        public InsertBookHandler(GerenciadorLivroDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(book.Id);
        }
    }
}
