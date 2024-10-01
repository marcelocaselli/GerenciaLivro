using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciaLivro.Application.Commands.InsertBook;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaLivro.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddHandlers (this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertBookCommand>());

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertBookCommand>();

            return services;
        }
    }
}
