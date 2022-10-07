using System.Reflection;
using hack4good.BLL.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace hack4good.BLL;

public static class DI
{
    public static IServiceCollection AddBLL(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ISessionHolder, SessionHolder>();

        return services;
    }
}