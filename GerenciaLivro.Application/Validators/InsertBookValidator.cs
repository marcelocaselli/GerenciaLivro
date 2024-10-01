using FluentValidation;
using GerenciaLivro.Application.Commands.InsertBook;
using System.Data;

namespace GerenciaLivro.Application.Validators
{
    public class InsertBookValidator : AbstractValidator<InsertBookCommand>
    {
        public InsertBookValidator() 
        {
            RuleFor(x => x.Title)
                .MaximumLength(100)
                .MinimumLength(5) 
                    .WithMessage("Tamanho entre 5 e 100 caracteres.");

            RuleFor(x => x.Author)
                .MaximumLength(100)
                .MinimumLength(3)
                    .WithMessage("Tamanho entre 5 e 100 caracteres.");

            RuleFor(x => x.Isbn)
                .MaximumLength(100)
                .MinimumLength(3)
                    .WithMessage("Tamanho entre 5 e 100 caracteres.");


        }
    }
}
