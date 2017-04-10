using EpiCommerceKit.Web.Features.Shared.Models.Interfaces;
using Mediachase.Commerce;

namespace EpiCommerceKit.Web.Features.Product.ViewModels
{
    public class ProductViewModel : IProductModel
    {
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Brand { get; set; }
        public Money? DiscountedPrice { get; set; }
        public Money PlacedPrice { get; set; }
        public string Code { get; set; }
        public bool IsAvailable { get; set; }
        public string MarketFilter { get; set; }
    }
}