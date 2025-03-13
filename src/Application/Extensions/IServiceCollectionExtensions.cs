using System.Reflection;
using FreelaFlowApi.Application.Interfaces;

namespace FreelaFlowApi.Application.Extensions;
public static class IServiceCollectionExtensions
{
    public static void RegisterRepositoriesAndServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var types = assembly.GetTypes()
            .Where(t => !t.IsInterface && !t.IsAbstract)
            .ToList();

        foreach (var type in types)
        {
            if (type == typeof(Infrastructure.Clients.FirebaseAuthClient))
                System.Console.WriteLine("Found AuthService");
            foreach (var @interface in type.GetInterfaces())
            {
                if (@interface == typeof(IAuthClient))
                    System.Console.WriteLine("Found AuthService");
                    
                if (@interface == typeof(ITransient))
                    services.AddTransient(type);
                else if (@interface == typeof(IScoped))
                    services.AddScoped(type);
                else if (typeof(ITransient).IsAssignableFrom(@interface))
                    services.AddTransient(@interface, type);
                else if (typeof(IScoped).IsAssignableFrom(@interface))
                    services.AddScoped(@interface, type);
            }
        }
    }
}