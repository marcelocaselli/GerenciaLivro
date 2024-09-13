using GerenciaLivro.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciaLivro.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
