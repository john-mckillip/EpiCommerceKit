using EPiServer.Commerce.Catalog.DataAnnotations;
using EpiCommerceKit.Web.Features.Product.Models.Abstracts;

namespace EpiCommerceKit.Web.Features.Product.Models
{
    [CatalogContentType(
        DisplayName = "Product Package", 
        GUID = "147717c8-a179-47f1-9f7f-5c09a89d127a",
        MetaClassName = "PackageData")]
    public class ProductPackageData : CorePackageData { }
}