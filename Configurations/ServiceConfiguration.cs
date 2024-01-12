using SimpleCRUD_MVC.Business.Services;
using SimpleCRUD_MVC.Business.Services.Base;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace SimpleCRUD_MVC.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection Configuration(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            serviceCollection.AddScoped<ProductService, ProductService>();
            serviceCollection.AddScoped<OrderItemService, OrderItemService>();
            return serviceCollection;
        }
    }
}
