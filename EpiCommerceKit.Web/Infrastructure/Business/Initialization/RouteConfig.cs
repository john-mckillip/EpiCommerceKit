using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Routing;

namespace EpiCommerceKit.Web.Infrastructure.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RouteConfig : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {

            RegisterRoutes(RouteTable.Routes);
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }

        private void RegisterRoutes(RouteCollection routeCollection)
        {
            
        }
    }
}