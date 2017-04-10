using EpiCommerceKit.Web.Features.Shared.Controllers.Abstracts;
using EpiCommerceKit.Web.Features.Shared.Models;
using EpiCommerceKit.Web.Infrastructure.Business;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace EpiCommerceKit.Web.Features.Shared.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : BasePageController<SitePageData>
    {
        private readonly PageViewContextFactory _contextFactory;


        public DefaultPageController(PageViewContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public ActionResult Index(SitePageData currentPage, int? page)
        {
            var model = CreateModel(currentPage);
            model.PageNumber = page ?? 1;

            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var pageUrl = urlResolver.GetVirtualPath(currentPage.ContentLink);
            model.PageURL = pageUrl.VirtualPath;

            return GetView(currentPage, model);
        }

        //public ActionResult Forbidden() => DisplayErrorPage(Site.SiteSettings.Forbidden, 403);

        //public ActionResult NotFound()
        //{

        //    Response.StatusCode = 404;

        //    return DisplayErrorPage(Site.SiteSettings.PageNotFound, 404);
        //}

        //public ActionResult ServerError()
        //{
        //    Response.StatusCode = 500;

        //    try
        //    {
        //        return DisplayErrorPage(Site.SiteSettings.ServerError, 500);
        //    }
        //    catch (Exception) { }

        //    return View("~/Views/Shared/Errors/500.cshtml");
        //}

        //private ActionResult DisplayErrorPage(ContentReference errorPageLink, int errorCode)
        //{
        //    // Get ErrorPage
        //    Response.StatusCode = errorCode;
        //    SitePageData errorPage = !ContentReference.IsNullOrEmpty(errorPageLink) ? errorPageLink.GetContent<SitePageData>() : null;

        //    if (errorPage == null)
        //        throw new NullReferenceException($"No {errorCode} page has been set in the global settings.");

        //    var model = CreateModel(errorPage);

        //    // Set RoutingConstants.NodeKey so EPi's extension method RequestContext.GetContentLink() will work
        //    //ControllerContext.RequestContext.SetContentLink(notFoundPage.ContentLink);
        //    RequestContextExtension.SetContentLink(ControllerContext.RequestContext, errorPageLink);
        //    ControllerContext.RouteData.DataTokens[RoutingConstants.NodeKey] = errorPageLink;

        //    return GetView(errorPage, model);
        //}
    }

    public class ReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public string[] ErrorCodes { get; set; }
    }
}