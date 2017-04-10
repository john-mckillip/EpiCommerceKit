using EpiCommerceKit.Web.Features.Start.Pages;
using EpiCommerceKit.Web.Models.Features.Start.Blocks;
using EPiServer;
using EPiServer.Core;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System.Web.Routing;

namespace EpiCommerceKit.Web.Infrastructure.Business.Extensions
{
    public static class Site
    {
        public static HomePageData Homepage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IContentLoader>().Get<HomePageData>(ContentReference.StartPage);
            }
        }

        public static SiteSettingsData SiteSettings
        {
            get
            {
                return Homepage.SiteSettings;
            }
        }

        public static RouteValueDictionary GetPageRoute(this RequestContext requestContext, ContentReference contentLink)
        {
            var values = new RouteValueDictionary();
            values[RoutingConstants.NodeKey] = contentLink;
            values[RoutingConstants.LanguageKey] = ContentLanguage.PreferredCulture.Name;
            return values;
        }
    }
}