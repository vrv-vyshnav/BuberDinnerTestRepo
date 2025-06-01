using BuberDinner.Application;
using BuberDinner.infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddOpenApi();
    builder.Services.AddControllers();
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)   ;
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

