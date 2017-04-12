using EpiCommerceKit.Web.Features.Product.Models;
using EpiCommerceKit.Web.Features.Product.ViewModelFactories;
using EpiCommerceKit.Web.Infrastructure.Facades;
using EPiServer.Web.Mvc;
using System.Web.Mvc;

namespace EpiCommerceKit.Web.Features.Product.Controllers
{
    public class ProductController : ContentController<ProductData>
    {
        private readonly bool _isInEditMode;
        private readonly CatalogEntryViewModelFactory _viewModelFactory;

        public ProductController(IsInEditModeAccessor isInEditModeAccessor, CatalogEntryViewModelFactory viewModelFactory)
        {
            _isInEditMode = isInEditModeAccessor();
            _viewModelFactory = viewModelFactory;
        }

        [HttpGet]
        public ActionResult Index(ProductData currentContent, string variationCode = "", bool useQuickview = false)
        {
            var viewModel = _viewModelFactory.Create(currentContent, variationCode);

            if (_isInEditMode && viewModel.Variant == null)
            {
                var emptyViewName = "ProductWithoutEntries";
                return Request.IsAjaxRequest() ? PartialView(emptyViewName, viewModel) : (ActionResult)View(emptyViewName, viewModel);
            }

            if (viewModel.Variant == null)
            {
                return HttpNotFound();
            }

            if (useQuickview)
            {
                return PartialView("_Quickview", viewModel);
            }

            //ToDo: Figure out a solution for these without Episerver Recommendations package
            //viewModel.AlternativeProducts = this.GetAlternativeProductsRecommendations();
            //viewModel.CrossSellProducts = this.GetCrossSellProductsRecommendations();

            return Request.IsAjaxRequest() ? PartialView(viewModel) : (ActionResult)View(viewModel);
        }

        [HttpPost]
        public ActionResult SelectVariant(ProductData currentContent, string color, string size, bool useQuickview = false)
        {
            var variant = _viewModelFactory.SelectVariant(currentContent, color, size);
            if (variant != null)
            {
                return RedirectToAction("Index", new { variationCode = variant.Code, useQuickview = useQuickview });
            }

            return HttpNotFound();

        }
    }
}