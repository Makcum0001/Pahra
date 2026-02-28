using Scalar.AspNetCore;
using Pahra.Application.Extensions;
using Pahra.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddLogging(c =>
{
    c.AddConsole();
    c.AddDebug();
});

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            // В режиме разработки разрешаем всё. Для production стоит указать конкретный origin фронтенда.
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseRouting();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(c =>
    {
        c.Title = "Pahra API";
    });
}

app.MapControllers();

app.Run();
