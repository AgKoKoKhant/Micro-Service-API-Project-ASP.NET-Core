using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Alpha.ApiGateWay
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        // This method gets called by the runtime. Use this method to add services to the container.

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _environment = env;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
            services.AddCors();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors(cors =>
            //{
            //    cors.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .SetIsOriginAllowed(x => true)
            //        .AllowCredentials();
            //});
            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to Alpha Gateway");
                });
            });
            app.UseOcelot().Wait();


        }

    }
}