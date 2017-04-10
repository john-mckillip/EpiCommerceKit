using EpiCommerceKit.Web.Features.Shared.ViewModels.Interfaces;
using System.Web.Routing;

namespace EpiCommerceKit.Web.Features.Shared.ViewModels
{
    [EPiServer.ServiceLocation.ServiceConfiguration(typeof(ILayoutModel))]
    public class LayoutModel : ILayoutModel
    {
        public RouteValueDictionary SearchPageRouteValues { get; set; }

        public string PageTitle { get; set; }

        public string MetaDescription { get; set; }
    }
}