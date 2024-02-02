using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Modulo4.LinhaDeMontagem;

public class AddCabecalhoMiddleware
{
    private readonly RequestDelegate _next;
    public AddCabecalhoMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add("X-Request-Time", DateTime.UtcNow.ToString());
            context.Response.Headers.Add("X-Request-IP", context.Connection.RemoteIpAddress!.ToString());
            return Task.CompletedTask;
        });
        await _next(context);
    }
}

public class RequestDurationMiddleware
{
    private readonly RequestDelegate _next;

    public RequestDurationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        context.Response.OnStarting(() =>
        {
            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            context.Response.WriteAsync($"X-Request-Duration {stopwatch.ElapsedTicks} microsegundos");
            return Task.CompletedTask;
        });

    }
}

public class JsonMiddleware
{
    private readonly RequestDelegate _next;
    // private readonly HttpClient _httpClient;

    public JsonMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var json = JsonSerializer.Serialize(new { Message = ex.Message });
            // await _httpClient.PostAsync("https://example.com/endpoint", new StringContent(json));
            throw;
        }
    }
}



public class LinhaDeMontagemDescricao
{
    public List <(string,string)> descricao = new List<(string,string)>();
    public string Cor { get; set; }
    public void AdicionarEtapa(string etapa, string descricao)
    {
        this.descricao.Add((etapa, descricao));
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int i = 1;
        foreach (var item in descricao)
        {
            sb.AppendLine($"Etapa {i++}: {item.Item1} - {item.Item2}<br>");
        }
        return sb.ToString();
    }
}
