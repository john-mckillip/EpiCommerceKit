using EPiServer.Commerce.Catalog.DataAnnotations;
using EpiCommerceKit.Web.Features.Product.Models.Abstracts;

namespace EpiCommerceKit.Web.Features.Product.Models
{
    [CatalogContentType(
        DisplayName = "Product", 
        GUID = "3c951ec6-368f-4df5-85ed-4baf28e432b9",
        MetaClassName = "ProductData")]
    public class ProductData : CoreProductData { }
}