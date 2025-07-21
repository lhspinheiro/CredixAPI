using CredixAPI.Application.AutoMapper;
using CredixAPI.Application.UseCases.Register;
using CredixAPI.Infrastructure.Consumer.Bus;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CredixAPI.Application;

public static class DependencyInjection
{
    public static  void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
        AddRabbitMQService(services);
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping)); 
    }
    
    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUseCase, RegisterUseCase>();

    }

    private static void AddRabbitMQService(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<LoansEventConsumer>();
            
            busConfigurator.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri("amqp://localhost:5672"), host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
}