using EpiCommerceKit.Web.Features.Product.Models;
using EpiCommerceKit.Web.Features.Product.ViewModels.Abstracts;
using EPiServer.Commerce.Catalog.ContentTypes;
using Mediachase.Commerce;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Product.ViewModels
{
    public class ProductPackageViewModel : ProductViewModelBase
    {
        public ProductPackageData Package { get; set; }
        public Money? DiscountedPrice { get; set; }
        public Money ListingPrice { get; set; }
        public IEnumerable<CatalogContentBase> Entries { get; set; }
        public bool IsAvailable { get; set; }
    }
}