using System.Web.Routing;

namespace EpiCommerceKit.Web.Features.Shared.ViewModels.Interfaces
{
    public interface ILayoutModel
    {
        RouteValueDictionary SearchPageRouteValues { get; set; }

        string PageTitle { get; set; }

        string MetaDescription { get; set; }
    }
}
