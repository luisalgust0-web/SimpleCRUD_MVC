using SimpleCRUD_MVC.Business.Services;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Data.Repositorys;
using SimpleCRUD_MVC.Data.Repositorys.Interfaces;
using System.Runtime.CompilerServices;

namespace SimpleCRUD_MVC.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection Configuration(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));
            serviceCollection.AddScoped(typeof(IGeneralService<>), typeof(GeneralService<>));
            return serviceCollection;
        }
    }
}
