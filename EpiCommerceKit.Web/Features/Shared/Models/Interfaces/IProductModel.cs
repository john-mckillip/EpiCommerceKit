using Mediachase.Commerce;

namespace EpiCommerceKit.Web.Features.Shared.Models.Interfaces
{
    public interface IProductModel
    {
        string Brand { get; set; }
        string Code { get; set; }
        string DisplayName { get; set; }
        Money? DiscountedPrice { get; set; }
        string ImageUrl { get; set; }
        Money PlacedPrice { get; set; }
        string Url { get; set; }
        bool IsAvailable { get; set; }
    }
}
