using EpiCommerceKit.Web.Features.Shared.Models;
using EpiCommerceKit.Web.Features.Shared.ViewModels;
using EpiCommerceKit.Web.Features.Shared.ViewModels.Interfaces;
using EPiServer;
using EPiServer.Core;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using System;
using System.Net;
using System.Web.Mvc;

namespace EpiCommerceKit.Web.Features.Shared.Controllers.Abstracts
{
    public abstract class BasePageController<T> : PageController<T> where T : SitePageData
    {
        /// <summary>
        /// Creates a PageViewModel where the type parameter is the type of the page.
        /// </summary>
        /// <remarks>
        /// Used to create models of a specific type without the calling method having to know that type.
        /// </remarks>
        protected static IPageViewModel<SitePageData> CreateModel(SitePageData page)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<SitePageData>;
        }

        protected ActionResult GetView(SitePageData currentPage, object model) => 
            View(string.Format("~/Views/Pages/{0}/Index.cshtml", currentPage.GetOriginalType().Name), model);

        protected bool IsMember()
        {
            //ContactRepository contactRepository = new ContactRepository();
            //var contactInformation = contactRepository.Get();

            //return contactInformation?.Member == true;
            return false;
        }

        /// <summary>
        /// Sets unauthorized is user doesn't have read access.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var pageRouteHelper = ServiceLocator.Current.GetInstance<IPageRouteHelper>();
            var pageReference = pageRouteHelper.Page;

            //Check if user doesn't have authorisation to the content
            if (!pageReference.QueryAccess().HasFlag(AccessLevel.Read))
            {
                // Check if the user is logged in
                var context = filterContext.HttpContext;
                if (context.User != null && context.User.Identity != null && context.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                    //throw new HttpException(403, "Forbidden");
                }
            }
        }

        protected static string GetViewPath(SitePageData page) => string.Format("~/Views/Pages/{0}/Index.cshtml", page.GetOriginalType().Name);
    }
}