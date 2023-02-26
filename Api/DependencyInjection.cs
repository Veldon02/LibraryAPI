using Api.Mapping;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            services.AddMapping();
            services.AddSwaggerGen();

            return services;
        }
    }
}
