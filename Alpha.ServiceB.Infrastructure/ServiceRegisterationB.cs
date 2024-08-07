using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha.ServiceB.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Alpha.ServiceB.Infrastructure
{
    public static class ServiceRegisterationB
    {
        /// <summary>
        /// Dependency Injection Extension Function (this >> D code ko u thone prml)
        /// </summary>
        /// <param name="services"></param>

       public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IServiceB,ServiceBOperation>(); //Dependency Injection
        }
    }
}
