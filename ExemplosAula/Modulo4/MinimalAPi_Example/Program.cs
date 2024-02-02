using MiddleWare.Extensions;
using Modulo4.LinhaDeMontagem;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LinhaDeMontagemDescricao>();

var app = builder.Build();
//app.UseHttpsRedirection();

app.UseRequestDurationMiddleware();
app.UseAddCabecalhoMiddleware();
// app.UseJsonMiddleware();

app.Run();
