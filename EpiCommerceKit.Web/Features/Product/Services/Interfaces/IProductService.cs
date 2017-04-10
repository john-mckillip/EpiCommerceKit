using EpiCommerceKit.Web.Features.Product.Models.Abstracts;
using EpiCommerceKit.Web.Features.Product.ViewModels;
using EPiServer.Commerce.Catalog.ContentTypes;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Product.Services.Interfaces
{
    public interface IProductService
    {
        ProductViewModel GetProductViewModel(ProductContent product);
        ProductViewModel GetProductViewModel(VariationContent variation);
        string GetSiblingVariantCodeBySize(string siblingCode, string size);
        IEnumerable<CoreItemData> GetVariations(CoreProductData currentContent);
        IEnumerable<ProductViewModel> GetVariationsAndPricesForProducts(IEnumerable<ProductContent> products);
    }
}
