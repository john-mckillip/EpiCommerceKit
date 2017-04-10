using EPiServer.ServiceLocation;
using Mediachase.Commerce.Core;
using System;

namespace EpiCommerceKit.Web.Infrastructure.Facades
{
    [ServiceConfiguration(typeof(AppContextFacade), Lifecycle = ServiceInstanceScope.Singleton)]
    public class AppContextFacade
    {
        public virtual Guid ApplicationId
        {
            get { return AppContext.Current.ApplicationId; }
        }
    }    
}