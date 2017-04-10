using EpiCommerceKit.Web.Features.Product.Models;
using EpiCommerceKit.Web.Features.Shared.Models;
using EpiCommerceKit.Web.Features.Shared.ViewModels.Interfaces;
using EpiCommerceKit.Web.Features.Start.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System.Linq;
using System.Web.Routing;

namespace EpiCommerceKit.Web.Infrastructure.Business
{
    public class PageViewContextFactory
    {
        private readonly IContentLoader _contentLoader;     
        private readonly UrlResolver _urlResolver;
        private ILayoutModel _layoutModel;

        public PageViewContextFactory(IContentLoader contentLoader, UrlResolver urlResolver)
        {
            _contentLoader = contentLoader;
            _urlResolver = urlResolver;
        }

        public virtual ILayoutModel CreateLayoutModel(ContentReference currentContentLink, RequestContext requestContext)
        {
            var startPage = _contentLoader.Get<HomePageData>(ContentReference.StartPage);
            var currentContent = _contentLoader.Get<IContent>(currentContentLink);

            _layoutModel = ServiceLocator.Current.GetInstance<ILayoutModel>();

            //_layoutModel.SearchPageRouteValues = requestContext.GetPageRoute(startPage.SiteSettings.SearchPageLink)

            if (currentContent is ProductItemData)
            {
                var product = currentContent as ProductItemData;
                // Populate the meta data
                _layoutModel.PageTitle = (product.SeoInformation.Title != null) ? 
                    product.SeoInformation.Title + " " + 
                    Helpers.SiteHelper.SiteSettings.PageTitleSeparator + " " + 
                    Helpers.SiteHelper.SiteSettings.PageTitleBase 
                    : 
                    product.DisplayName + " " + 
                    Helpers.SiteHelper.SiteSettings.PageTitleSeparator + " " + 
                    Helpers.SiteHelper.SiteSettings.PageTitleBase;

                _layoutModel.MetaDescription = product.SeoInformation.Description;
            }
            else if (currentContent is SitePageData)
            {
                var page = currentContent as SitePageData;
                // Populate the meta data
                _layoutModel.PageTitle = page.PageTitle;
                _layoutModel.MetaDescription = page.SeoDescription;
            }

            return _layoutModel;
        }

        public virtual IContent GetSection(ContentReference contentLink)
        {
            var currentContent = _contentLoader.Get<IContent>(contentLink);

            if (currentContent.ParentLink != null && currentContent.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
            {
                return currentContent;
            }

            return _contentLoader.GetAncestors(contentLink)
                .OfType<PageData>()
                .SkipWhile(x => x.ParentLink == null || !x.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
                .FirstOrDefault();
        }
    }
}