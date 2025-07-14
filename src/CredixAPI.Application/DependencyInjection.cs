using CredixAPI.Application.AutoMapper;
using CredixAPI.Application.UseCases.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CredixAPI.Application;

public static class DependencyInjection
{
    public static  void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping)); 
    }
    
    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUseCase, RegisterUseCase>();

    }
}