using FluentValidation;
using GerenciaLivro.Application.Commands.InsertUser;

namespace GerenciaLivro.Application.Validators
{
    public class InsertUserValidator : AbstractValidator<InsertUserCommand>
    {
        public InsertUserValidator() 
        {
            RuleFor(x => x.Name)
                .MaximumLength(100)
                .MinimumLength(3)
                    .WithMessage("Tamanho entre 5 e 100 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage("Email inválido.");

            RuleFor(x => x.BirthDate)
                .Must(x => x < DateTime.Now.AddYears(12))
                    .WithMessage("Deve ser maior que 12 anos.");
        }
    }
}
