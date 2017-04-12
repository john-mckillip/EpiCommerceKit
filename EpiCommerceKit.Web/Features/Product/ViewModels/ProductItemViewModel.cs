using EpiCommerceKit.Web.Features.Product.Models;
using EpiCommerceKit.Web.Features.Product.ViewModels.Abstracts;
using Mediachase.Commerce;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EpiCommerceKit.Web.Features.Product.ViewModels
{
    public class ProductItemViewModel : ProductViewModelBase
    {
        public ProductData Product { get; set; }
        public Money? DiscountedPrice { get; set; }
        public Money ListingPrice { get; set; }
        public ProductItemData Variant { get; set; }
        public IList<SelectListItem> Colors { get; set; }
        public IList<SelectListItem> Sizes { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public bool IsAvailable { get; set; }
    }
}