using Alpha.ServiceA.Interface;
using Microsoft.Extensions.DependencyInjection;


namespace Alpha.ServiceA.Infrastructure
{
    public static class ServiceRegisteration
    {

        /// Dependency Injection Extension Function (this >> D code ko u thone prml)
        /// <param name="services"></param>
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IServiceA, ServiceAOperation>();
        }
    }
}
