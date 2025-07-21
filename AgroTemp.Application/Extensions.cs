using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using AgroTemp.Application.Commands.Probes.AddProbe;
using AgroTemp.Application.Commands.Probes.UpdateProbe;
using AgroTemp.Application.Commands.Users.AddUser;
using AgroTemp.Application.Commands.Users.UpdateUser;
using AgroTemp.Application.Commands.Silos.AddSilo;
using AgroTemp.Application.Commands.Silos.UpdateSilo;
using AgroTemp.Application.Commands.ReadingModules.AddReadingModule;
using AgroTemp.Application.Commands.ReadingModules.UpdateReadingModule;
using AgroTemp.Application.Configuration.Validation;
using AgroTemp.Application.Middlewares;
using Microsoft.AspNetCore.Builder;
using AgroTemp.Application.Commands.Alarms.AddAlarm;
using AgroTemp.Application.Commands.Alarms.UpdateAlarm;
using AgroTemp.Application.Commands.Users.UpdateLogin;
using AgroTemp.Application.Commands.Users.UpdatePassword;
using AgroTemp.Application.Commands.Users.UpdateUserParameters;

namespace AgroTemp.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(executingAssembly));
        services.AddAutoMapper(executingAssembly);

        services.AddScoped<IValidator<AddAlarmCommand>, AddAlarmCommandValidation>();
        services.AddScoped<IValidator<UpdateAlarmCommand>, UpdateAlarmCommandValidation>();

        services.AddScoped<IValidator<AddProbeCommand>, AddProbeCommandValidation>();
        services.AddScoped<IValidator<UpdateProbeCommand>, UpdateProbeCommandValidation>();

        services.AddScoped<IValidator<AddUserCommand>, AddUserCommandValidation>();
        services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidation>();

        services.AddScoped<IValidator<AddSiloCommand>, AddSiloCommandValidation>();
        services.AddScoped<IValidator<UpdateSiloCommand>, UpdateSiloCommandValidation>();

        services.AddScoped<IValidator<AddReadingModuleCommand>, AddReadingModuleCommandValidation>();
        services.AddScoped<IValidator<UpdateReadingModuleCommand>, UpdateReadingModuleCommandValidation>();

        services.AddScoped<IValidator<UpdateLoginCommand>, UpdateLoginCommandValidation>();
        services.AddScoped<IValidator<UpdatePasswordCommand>, UpdatePasswordCommandValidation>();
        services.AddScoped<IValidator<UpdateUserParametersCommand>, UpdateUserParametersCommandValidation>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        services.AddTransient<ExceptionHandlingMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseApllication(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}
