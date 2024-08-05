
namespace Alpha.ApiGateWay
{
    public class Program

    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
            config.AddJsonFile($"ocelot.json", true, true);
        })
         .ConfigureWebHostDefaults(webBuilder =>
                {
            webBuilder.UseStartup<Startup>();
        });
    }
}