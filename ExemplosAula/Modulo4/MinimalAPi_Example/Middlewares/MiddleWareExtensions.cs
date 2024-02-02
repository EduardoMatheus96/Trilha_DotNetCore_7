using Modulo4.LinhaDeMontagem;

namespace MiddleWare.Extensions;
public static class MiddleWareExtensions
{
    public static IApplicationBuilder UseAddCabecalhoMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<AddCabecalhoMiddleware>();
    }
    public static IApplicationBuilder UseRequestDurationMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<RequestDurationMiddleware>();
    }
    public static IApplicationBuilder UseJsonMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<JsonMiddleware>();
    }
}
