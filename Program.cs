using Maiara;
using Maiara.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Folha de pagamento");

app.MapPost("/maiara/funcionarios/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapGet("/maiara/funcionarios/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound();

});

app.MapPost("/maiara/folhas/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext ctx) =>
{
    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);
});

app.MapGet("/maiara/folhas/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Folhas.Any())
    {
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.NotFound();

});

app.MapGet("/maiara/folhas/buscar/{cpf}/{mes}/{ano}", ([FromRoute] double cpf, int mes, int ano, [FromServices] AppDataContext ctx) =>
{
    Folha? folha = ctx.Folhas.Find(cpf, mes, ano);
    if (folha is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(folha);

});

app.Run();
