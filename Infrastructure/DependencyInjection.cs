using Application.Common.Interfaces.Persistence;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseInMemoryDatabase("LibraryDB");
            });
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
