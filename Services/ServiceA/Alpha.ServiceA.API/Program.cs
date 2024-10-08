using Alpha.ServiceA.API.Events.Publishers;
using Alpha.ServiceA.Infrastructure;
using Alpha.ServiceA.Interface;
using Alpha.Shared.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();

// Register ICommonPublisher with the DI container
//builder.Services.AddTransient<IServiceA, ServiceAOperation>();// dependency injection
builder.Services.AddTransient<ICommonPublisher, CommonPublisher>();
//Configure Serial Log
builder.Host.UseSerilog((hostContext, services, loggerConfiguration) =>
{
    // Use the Serilog configuration defined in the application config. e.g. the appsettings.json file.
    loggerConfiguration
        .ReadFrom.Configuration(hostContext.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext();
});

builder.Host.ConfigureAppConfiguration(config =>
{
    config.SetBasePath(Directory.GetCurrentDirectory());
    config.AddJsonFile("Configs/LogSettings.json", optional: true, reloadOnChange: true);
});


// Configure DbContext with connection string and migrations assembly
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("Alpha.ServiceA.Infrastructure")));

// Register ServiceAOperation as IServiceA
builder.Services.AddScoped<IServiceA, ServiceAOperation>();

// Add additional infrastructure services
builder.Services.AddInfrastructure();

//RabbitMQ
var consumerList = QueueConfiguration.CreateDefaultMappings();
var massTransitConfig = builder.Configuration.GetSection("MassTransitConfig").Get<MassTransitConfig>();
builder.Services.AddConfiguredMassTransit(massTransitConfig, consumerList);

var app = builder.Build();

// Ensure database is created and apply any pending migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
