using Alpha.ServiceB.API.Events;
using Alpha.ServiceB.Infrastructure;
using Alpha.Shared.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//infrastructure// extension class all in one
builder.Services.AddInfrastructure();

//log
builder.Host.UseSerilog((hostContext, Services, LoggerConfiguration) =>

{
    LoggerConfiguration
        .ReadFrom.Configuration(hostContext.Configuration)
        .ReadFrom.Services(Services)
        .Enrich.FromLogContext();
});
builder.Host.ConfigureAppConfiguration(config =>
{
    config.SetBasePath(Directory.GetCurrentDirectory());
    config.AddJsonFile("Configs/LogSettings.json", optional: true, reloadOnChange: true);
});
//RabbitMQ
var consumerList = QueueConfiguration.CreateDefaultMappings();
var massTransitConfig = builder.Configuration.GetSection("MassTransitConfig").Get<MassTransitConfig>();
builder.Services.AddConfiguredMassTransit(massTransitConfig, consumerList);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

app.UseAuthorization();
app.MapControllers();
//app.MapRazorPages();

app.Run();
