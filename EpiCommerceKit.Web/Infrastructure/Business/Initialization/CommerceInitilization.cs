using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Logging;
using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Commerce.Routing;

namespace EpiCommerceKit.Web.Infrastructure.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(global::EPiServer.Commerce.Initialization.InitializationModule))]
    public class CommerceInitilization : IInitializableModule, IConfigurableModule
    {
        private ILogger _log = LogManager.GetLogger();

        public void Initialize(InitializationEngine context)
        {
            MapRoutes(RouteTable.Routes);
            
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            GlobalFilters.Filters.Add(ServiceLocator.Current.GetInstance<PageContextActionFilter>());           
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }

        private static void MapRoutes(RouteCollection routes)
        {
            CatalogRouteHelper.MapDefaultHierarchialRouter(routes, true);
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            
        }
    }
}