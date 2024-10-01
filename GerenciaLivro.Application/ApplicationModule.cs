﻿using GerenciaLivro.Application.Commands.InsertBook;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaLivro.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers (this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertBookCommand>());

            return services;
        }
    }
}
