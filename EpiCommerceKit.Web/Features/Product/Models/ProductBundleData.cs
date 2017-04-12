using EPiServer.Commerce.Catalog.DataAnnotations;
using EpiCommerceKit.Web.Features.Product.Models.Abstracts;

namespace EpiCommerceKit.Web.Features.Product.Models
{
    [CatalogContentType(
        DisplayName = "Product Bundle", 
        GUID = "bfa7f867-f0b6-4045-ba8b-203a8894e8d3",
        MetaClassName = "ProductBundleData")]
    public class ProductBundleData : CoreBundleData { }
}