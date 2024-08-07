using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Alpha.ApiGateWay
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _environment = env;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

            // Define the CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins(
                        "http://localhost:5010", // Origin for Alpha.ApiGateWay
                        "http://localhost:5013", // Origin for Alpha.ServiceB.API
                        "https://localhost:7236" // Add other origins as needed
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigins");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to Alpha Gateway");
                });
            });

            await app.UseOcelot();
        }
    }
}
