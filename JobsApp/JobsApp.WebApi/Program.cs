using JobsApp.DAL;
using JobsApp.DAL.Context;
using JobsApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = Environment.GetEnvironmentVariable("connection_string");

        builder.Services.AddDbContext<AppPgContext>(options => options.UseNpgsql(
            connectionString
            ));

        var optionsBuilder = new DbContextOptionsBuilder<AppPgContext>()
            .UseNpgsql(connectionString);

        builder.Services.AddSingleton<IContextFactory>(new ContextFactory(optionsBuilder.Options));
        builder.Services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}