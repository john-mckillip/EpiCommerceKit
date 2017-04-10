// using DbLocalizationProvider; //ToDo: Need to instll this package
using EpiCommerceKit.Web.Features.Start.Pages;
using EpiCommerceKit.Web.Models.Features.Start.Blocks;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace EpiCommerceKit.Web.Infrastructure.Business.Helpers
{
    public static class SiteHelper
    {
        //public static string Translate(Expression<Func<object>> resource)
        //{
        //    return EPiServer.Framework.Localization.LocalizationService.Current.GetString(resource);
        //}

        public static HomePageData Homepage
        {
            get
            {
                if (ContentReference.StartPage != null)
                {
                    return ServiceLocator.Current.GetInstance<IContentLoader>().Get<HomePageData>(ContentReference.StartPage);
                }

                return null;
            }
        }

        public static SiteSettingsData SiteSettings
        {
            get
            {
                if (Homepage != null)
                {
                    return Homepage.SiteSettings;
                }

                return null;
            }
        }
    }
}