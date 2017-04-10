using EpiCommerceKit.Web.Features.Product.Models.Abstracts;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace EpiCommerceKit.Web.Features.Product.Models
{
    [CatalogContentType(
        DisplayName = "Product Item", 
        GUID = "8a9d4d14-b9af-429d-b1e4-ca10918d0804",
        MetaClassName = "ProductItemData")]
    public class ProductItemData : CoreItemData { }
}