using EpiCommerceKit.Web.Features.Product.Models;
using EpiCommerceKit.Web.Features.Product.ViewModels.Abstracts;
using EPiServer.Commerce.Catalog.ContentTypes;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Product.ViewModels
{
    public class ProductBundleViewModel : ProductViewModelBase
    {
        public ProductBundleData Bundle { get; set; }
        public IEnumerable<EntryContentBase> Entries { get; set; }
    }
}