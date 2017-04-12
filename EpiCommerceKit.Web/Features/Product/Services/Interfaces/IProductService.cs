using EpiCommerceKit.Web.Features.Product.Models;
using EpiCommerceKit.Web.Features.Product.ViewModels;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Product.Services.Interfaces
{
    public interface IProductService
    {
        ProductViewModel GetProductViewModel(EntryContentBase entry);
        IEnumerable<ProductViewModel> GetProductViewModels(IEnumerable<ContentReference> entryLinks);
        string GetSiblingVariantCodeBySize(string siblingCode, string size);
        IEnumerable<ProductItemData> GetVariations(ProductData currentContent);
        
    }
}
