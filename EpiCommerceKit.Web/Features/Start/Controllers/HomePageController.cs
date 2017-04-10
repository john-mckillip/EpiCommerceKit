using EpiCommerceKit.Web.Features.Shared.ViewModels;
using EpiCommerceKit.Web.Features.Start.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;

namespace EpiCommerceKit.Web.Controllers
{
    public class HomePageController : PageController<HomePageData>
    {
        public ActionResult Index(HomePageData currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            //string url = Site.SiteSettings.Logo.GetUrl();

            return View(model);
        }
    }
}