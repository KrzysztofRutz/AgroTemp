using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AgroTemp.Presentation;

public static class Extensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => { c.EnableAnnotations(); });

        services.AddControllers();
        
        return services;
    }

    public static IApplicationBuilder UsePresentation(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        //app.UseHttpsRedirection();

        app.MapControllers();

        return app;
    }
}
